using System;
using RimWorld;

namespace MinchoWitch
{
    public class IncidentWorker_MinchoFallout : IncidentWorker_MakeGameCondition
    {
        protected override bool CanFireNowSub(IncidentParms parms)
        {
            if (!base.CanFireNowSub(parms))
            {
                return false;
            }

            return false;
        }

        internal static void TryExecute(object incParm)
        {
            throw new NotImplementedException();
        }
    }
}