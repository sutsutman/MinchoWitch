using Verse;

namespace MinchoWitch
{
    public class HediffComp_MinchoInfection : HediffComp
    {
        private bool finalStage = false;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            float severity = this.parent.Severity;
            bool isFinalStage = severity >= 0.75f && !this.finalStage;
            if (isFinalStage)
            {
                this.parent.comps.RemoveAll((HediffComp x) => x is HediffComp_TendDuration);
                this.finalStage = true;
            }
            bool isPassedMinchoTrans = severity >= 1f;
            if (isPassedMinchoTrans)
            {
                MinchoGenerator.ConvertToMincho(base.Pawn, this.parent);
            }
        }
    }

    //아래는 초능력이든 add hediff 든 0.5f 로만 주니 필요
    public class HediffComp_MinchoInfection_Instant : HediffComp
    {

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);
            float severity = this.parent.Severity;
            bool isPassedMinchoTrans = severity >= 0.1f;
            if (isPassedMinchoTrans)
            {
                MinchoGenerator.ConvertToMincho(base.Pawn, this.parent);
            }
        }
    }
}
