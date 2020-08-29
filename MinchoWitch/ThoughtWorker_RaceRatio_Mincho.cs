using RimWorld;
using Verse;

namespace MinchoWitch
{
    //민초가 민초마녀를 탐지
    public class ThoughtWorker_RaceRatio_Mincho : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn pawn)
        {
            ThoughtState result;
            float num = (float)pawn.Map.mapPawns.FreeColonistsSpawned.FindAll((Pawn x) => x.def == MinchoWitchDefOf.MinchoWitch).Count;
            if (!pawn.IsColonist || pawn.def != MinchoWitchDefOf.Mincho_ThingDef)
            {
                result = ThoughtState.Inactive;
            }
            else if (num >= 1f)
            {
                result = ThoughtState.ActiveAtStage(0);
            }
            else
            {
                result = ThoughtState.Inactive;
            }
            return result;
        }
    }
}
