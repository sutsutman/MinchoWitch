using System;
using Verse;
using RimWorld;
using MinchoWitch_Psycast;

namespace MinchoWitch_TryFirePsycast
{
	// Token: 0x02000AD3 RID: 2771
	public class CompAbilityEffect_TryFirePsycast : CompAbilityEffect
	{

		public new CompProperties_AbilityTryFirePsycast Props
		{
			get
			{
				return (CompProperties_AbilityTryFirePsycast)this.props;
			}
		}


		public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
		{
			IncidentParms incParm = new IncidentParms();
			base.Apply(target, dest);
			Map map = this.parent.pawn.Map;
			Props.incidentDef.Worker.TryExecute(incParm);
		}
	}
}
