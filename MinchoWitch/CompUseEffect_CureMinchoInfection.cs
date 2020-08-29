using RimWorld;
using Verse;

namespace MinchoWitch
{
    public class CompUseEffect_CureMinchoInfection : CompUseEffect
    {
        public override void DoEffect(Pawn usedBy)
        {
            base.DoEffect(usedBy);
            if (usedBy.health.hediffSet.HasHediff(MinchoWitchDefOf.Mincho_Infection, false))
            {
                usedBy.health.hediffSet.GetFirstHediffOfDef(MinchoWitchDefOf.Mincho_Infection, false).Heal(1f);
            }
        }
    }
}
