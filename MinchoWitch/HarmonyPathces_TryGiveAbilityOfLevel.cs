using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HarmonyLib;
using RimWorld;
using Verse;

namespace MinchoWitch
{
    public static class HarmonyPathces_TryGiveAbilityOfLevel
    {
        static HarmonyPathces_TryGiveAbilityOfLevel()
        {
            //@" 뒤에 종족 전용 초능력 이름 추가, defname에 언더바 사용시 이름을 제대로 인식하지 못하니, 언더바를 쓰지 말거나 세이브에서 초능력 이름을 확인.
            var MinchoWithchability = @"
                                FrozenBeam,
                                MinchoBeam,
                                MassMinchoBeam,
								MinchoFallout
								SummonMinchoGolemManhunterPermanent,
								SummonMinchoGolemBerserk";
            var matches = Regex.Matches(MinchoWithchability, "[a-zA-Z]+");
            MinchoWithchabilityStrings = new HashSet<string>();
            foreach (var match in matches)
                MinchoWithchabilityStrings.Add(((Match)match).Value);
        }
        public static HashSet<string> MinchoWithchabilityStrings;
    }
    [StaticConstructorOnStartup]
    public class HarmonyPatch
    {
        static HarmonyPatch()
        {
            var harmony = new Harmony("com.minchoWitch.sutsut");
            var original = AccessTools.Method(typeof(Hediff_Psylink), nameof(Hediff_Psylink.TryGiveAbilityOfLevel));
            var prefix = AccessTools.Method(typeof(HarmonyPatch), nameof(HarmonyPatch.prefix_TryGiveAbilityOfLevel));
            harmony.Patch(original, new HarmonyMethod(prefix));
        }
        static bool prefix_TryGiveAbilityOfLevel(Pawn ___pawn, int abilityLevel)
        {
            string str = "LetterLabelPsylinkLevelGained".Translate() + ": " + ___pawn.LabelShortCap;
            string text = ((abilityLevel == 1) ? "LetterPsylinkLevelGained_First" : "LetterPsylinkLevelGained_NotFirst").Translate(___pawn.Named("USER"));
            var pawnDefType = ___pawn.def.defName;

            //A code
            // 민초마녀 이외의 종족이 종족 전용 초능력을 얻지 못하게 하는 부분입니다.
            if (!pawnDefType.Equals("MinchoWitch") && !___pawn.abilities.abilities.Any((Ability ability) => ability.def.level == abilityLevel))
            {
                var abilityDef = (from ability in DefDatabase<AbilityDef>.AllDefs
                                      //위에서 만든 HashSet 이외에서 고르게 합니다
                                  where !HarmonyPathces_TryGiveAbilityOfLevel.MinchoWithchabilityStrings.Contains(ability.defName)
                                  where ability.level == abilityLevel
                                  select ability).RandomElement<AbilityDef>();
                ___pawn.abilities.GainAbility(abilityDef);
                text += "\n\n" + "LetterPsylinkLevelGained_PsycastLearned".Translate(___pawn.Named("USER"), abilityLevel, abilityDef.LabelCap);

            }

            //B code
            // 민초마녀 종족이 종족 전용 초능력만을 얻게 하는 부분입니다.
            else if (pawnDefType.Equals("MinchoWitch") && !___pawn.abilities.abilities.Any((Ability ability) => ability.def.level == abilityLevel))
            {
                var abilityDef = (from ability in DefDatabase<AbilityDef>.AllDefs
                                      //위에서 만든 HashSet 에서 고르게 합니다
                                  where HarmonyPathces_TryGiveAbilityOfLevel.MinchoWithchabilityStrings.Contains(ability.defName)
                                  where ability.level == abilityLevel
                                  select ability).RandomElement<AbilityDef>();
                ___pawn.abilities.GainAbility(abilityDef);
                text += "\n\n" + "LetterPsylinkLevelGained_PsycastLearned".Translate(___pawn.Named("USER"), abilityLevel, abilityDef.LabelCap);

            }
            //C code
            if (PawnUtility.ShouldSendNotificationAbout(___pawn))
            {
                Find.LetterStack.ReceiveLetter(str, text, LetterDefOf.PositiveEvent, ___pawn, null, null, null, null);
                return false;
            }

            //D code
            else
                return false;

        }
    }
}