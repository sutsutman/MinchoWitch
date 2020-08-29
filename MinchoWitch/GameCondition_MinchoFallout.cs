﻿using System.Collections.Generic;
using RimWorld;
using UnityEngine;
using Verse;

namespace MinchoWitch
{
    public class GameCondition_MinchoFallout : GameCondition
    {
        public override int TransitionTicks
        {
            get
            {
                return 5000;
            }
        }
        public override void Init()
        {
            LessonAutoActivator.TeachOpportunity(ConceptDefOf.ForbiddingDoors, OpportunityType.Critical);
            LessonAutoActivator.TeachOpportunity(ConceptDefOf.AllowedAreas, OpportunityType.Critical);
        }
        public override void GameConditionTick()
        {
            List<Map> affectedMaps = base.AffectedMaps;
            if (Find.TickManager.TicksGame % 3451 == 0)
            {
                for (int i = 0; i < affectedMaps.Count; i++)
                {
                    this.DoPawnsToxicDamage(affectedMaps[i]);
                }
            }
            for (int j = 0; j < this.overlays.Count; j++)
            {
                for (int k = 0; k < affectedMaps.Count; k++)
                {
                    this.overlays[j].TickOverlay(affectedMaps[k]);
                }
            }
        }
        private void DoPawnsToxicDamage(Map map)
        {
            List<Pawn> allPawnsSpawned = map.mapPawns.AllPawnsSpawned;
            for (int i = 0; i < allPawnsSpawned.Count; i++)
            {
                GameCondition_MinchoFallout.DoPawnToxicDamage(allPawnsSpawned[i]);
            }
        }
        public static void DoPawnToxicDamage(Pawn p)
        {
            if (p.Spawned && p.Position.Roofed(p.Map))
            {
                return;
            }
            if (!p.RaceProps.IsFlesh)
            {
                return;
            }
            float num = 0.028758334f;
            num *= p.GetStatValue(StatDefOf.ToxicSensitivity, true);
            if (num != 0f)
            {
                float num2 = Mathf.Lerp(0.85f, 1.15f, Rand.ValueSeeded(p.thingIDNumber ^ 74374237));
                num *= num2;
                HealthUtility.AdjustSeverity(p, MinchoWitchDefOf.Mincho_Infection, num);
            }
        }
        public override void GameConditionDraw(Map map)
        {
            for (int i = 0; i < this.overlays.Count; i++)
            {
                this.overlays[i].DrawOverlay(map);
            }
        }
        public override float SkyTargetLerpFactor(Map map)
        {
            return GameConditionUtility.LerpInOutValue(this, (float)this.TransitionTicks, 0.5f);
        }
        public override SkyTarget? SkyTarget(Map map)
        {
            return new SkyTarget?(new SkyTarget(0.85f, this.ToxicFalloutColors, 1f, 1f));
        }
        public override float AnimalDensityFactor(Map map)
        {
            return 0f;
        }
        public override float PlantDensityFactor(Map map)
        {
            return 0f;
        }
        public override bool AllowEnjoyableOutsideNow(Map map)
        {
            return false;
        }
        public override List<SkyOverlay> SkyOverlays(Map map)
        {
            return this.overlays;
        }
        private const float MaxSkyLerpFactor = 0.5f;
        private const float SkyGlow = 0.85f;
        //셰이더에선 컬러값이 벡터, 그냥 255 곱하기 해주면 됨
        private SkyColorSet ToxicFalloutColors = new SkyColorSet(new ColorInt(0, 255, 255).ToColor, new ColorInt(130, 60, 35).ToColor, new Color(0.7f, 0.6f, 0.8f), 0.85f);
        private List<SkyOverlay> overlays = new List<SkyOverlay>
            {
                new WeatherOverlay_Fallout()
            };
        public const int CheckInterval = 3451;
        private const float ToxicPerDay = 0.5f;
        private const float PlantKillChance = 0.0065f;
        private const float CorpseRotProgressAdd = 3000f;
    }
}