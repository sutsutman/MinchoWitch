using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using RimWorld;
using MinchoWitch_Infection;

namespace MinchoWitch_MinchoFallout
{
    public class IncidentWorker_MinchoFallout : IncidentWorker_MakeGameCondition
	{
		// Token: 0x06003CEA RID: 15594 RVA: 0x001427DC File Offset: 0x001409DC
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