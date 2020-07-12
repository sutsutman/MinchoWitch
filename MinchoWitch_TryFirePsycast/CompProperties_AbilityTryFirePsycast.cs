using System;
using Verse;
using RimWorld;

namespace MinchoWitch_TryFirePsycast
{
	// Token: 0x02000AC6 RID: 2758
	public class CompProperties_AbilityTryFirePsycast : CompProperties_AbilityEffect
	{
		public CompProperties_AbilityTryFirePsycast()
		{
			this.compClass = typeof(CompAbilityEffect_TryFirePsycast);
		}
	// Token: 0x04002607 RID: 9735
		public IncidentDef incidentDef;
	}
}