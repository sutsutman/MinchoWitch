using RimWorld;
using Verse;

namespace MinchoWitch
{
    //민초마녀가 민초를 감지
    public class ThoughtWorker_RaceRatio_MinchoWitch : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn pawn)
        {
            ThoughtState result;
            if (!pawn.IsColonist || pawn.def != MinchoWitchDefOf.MinchoWitch)
            {
                result = ThoughtState.Inactive;
            }
            else
            {
                float num = (float)pawn.Map.mapPawns.FreeColonistsSpawned.FindAll((Pawn x) => x.def == MinchoWitchDefOf.Mincho_ThingDef).Count;
                if (num < 1f)
                {
                    result = ThoughtState.ActiveAtStage(0);
                }
                else if (num < 3f)
                {
                    result = ThoughtState.ActiveAtStage(1);
                }
                else if (num < 5f)
                {
                    result = ThoughtState.ActiveAtStage(2);
                }
                else if (num < 7f)
                {
                    result = ThoughtState.ActiveAtStage(3);
                }
                else
                {
                    result = ThoughtState.ActiveAtStage(4);
                }
            }
            return result;
        }
    }
}