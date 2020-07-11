﻿using System;
using System.Linq;
using RimWorld;
using Verse;

namespace MinchoWitch_Psycast
{
    // Token: 0x0200023C RID: 572
    public class Hediff_MinchoWitchPsylink : Hediff_ImplantWithLevel
    {
        // Token: 0x06001002 RID: 4098 RVA: 0x0005CB42 File Offset: 0x0005AD42
        public override void PostAdd(DamageInfo? dinfo)
        {
            base.PostAdd(dinfo);
            this.TryGiveAbilityOfLevel(this.level);
            Pawn_PsychicEntropyTracker psychicEntropy = this.pawn.psychicEntropy;
            if (psychicEntropy == null)
            {
                return;
            }
            psychicEntropy.Notify_GainedPsylink();
        }

        // Token: 0x06001003 RID: 4099 RVA: 0x0005CB6C File Offset: 0x0005AD6C
        public override void ChangeLevel(int levelOffset)
        {
            if (levelOffset > 0)
            {
                float num = Math.Min((float)levelOffset, this.def.maxSeverity - (float)this.level);
                int num2 = 0;
                while ((float)num2 < num)
                {
                    int abilityLevel = this.level + 1 + num2;
                    this.TryGiveAbilityOfLevel(abilityLevel);
                    Pawn_PsychicEntropyTracker psychicEntropy = this.pawn.psychicEntropy;
                    if (psychicEntropy != null)
                    {
                        psychicEntropy.Notify_GainedPsylink();
                    }
                    num2++;
                }
            }
            base.ChangeLevel(levelOffset);
        }

        // Token: 0x06001004 RID: 4100 RVA: 0x0005CBD4 File Offset: 0x0005ADD4
        public void TryGiveAbilityOfLevel(int abilityLevel)
        {
            string str = "LetterLabelPsylinkLevelGained".Translate() + ": " + this.pawn.LabelShortCap;
            string text = ((abilityLevel == 1) ? "LetterPsylinkLevelGained_First" : "LetterPsylinkLevelGained_NotFirst").Translate(this.pawn.Named("USER"));
            if (!this.pawn.abilities.abilities.Any((Ability a) => a.def.level == abilityLevel))
            {
                Type abilityClass = typeof(Psycast);
                AbilityDef abilityDef = (from a in DefDatabase<AbilityDef>.AllDefs
                                         where a.level == abilityLevel && a.abilityClass == abilityClass
                                         select a).RandomElement<AbilityDef>();
                this.pawn.abilities.GainAbility(abilityDef);
                text += "\n\n" + "LetterPsylinkLevelGained_PsycastLearned".Translate(this.pawn.Named("USER"), abilityLevel, abilityDef.LabelCap);
            }
            if (PawnUtility.ShouldSendNotificationAbout(this.pawn))
            {
                Find.LetterStack.ReceiveLetter(str, text, LetterDefOf.PositiveEvent, this.pawn, null, null, null, null);
            }
        }

        // Token: 0x06001005 RID: 4101 RVA: 0x0005CD15 File Offset: 0x0005AF15
        public override void PostRemoved()
        {
            base.PostRemoved();
            Pawn_NeedsTracker needs = this.pawn.needs;
            if (needs == null)
            {
                return;
            }
            needs.AddOrRemoveNeedsAsAppropriate();
        }
    }
}
