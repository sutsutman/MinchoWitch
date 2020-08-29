using RimWorld;
using Verse;

namespace MinchoWitch
{
    public class CompAbilityEffect_Spawn_ManhunterPermanent : CompAbilityEffect
    {
        public new CompProperties_AbilitySpawn Props
        {
            get
            {
                return (CompProperties_AbilitySpawn)this.props;
            }
        }
        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            Pawn pawn = PawnGenerator.GeneratePawn(PawnKindDef.Named("MinchoGolem"), null);
            pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, null, true, false, null, false);
            base.Apply(target, dest);
            GenSpawn.Spawn(pawn, target.Cell, this.parent.pawn.Map, WipeMode.Vanish);
            pawn.mindState.mentalStateHandler.TryStartMentalState(MentalStateDefOf.ManhunterPermanent, null, true, false, null, false);
        }
        public override bool Valid(LocalTargetInfo target, bool throwMessages = false)
        {
            if (target.Cell.Filled(this.parent.pawn.Map))
            {
                if (throwMessages)
                {
                    Messages.Message("AbilityOccupiedCells".Translate(this.parent.def.LabelCap), target.ToTargetInfo(this.parent.pawn.Map), MessageTypeDefOf.RejectInput, false);
                }
                return false;
            }
            return true;
        }
    }
}
