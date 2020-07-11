using Garam_RaceAddon;
using System;
using System.Reflection;
using Verse;

namespace MinchoWitch_Infection
{
	[StaticConstructorOnStartup]
	public static class Mincho_Infection
	{
		static Mincho_Infection()
		{
			MinchoWitch_InfectionDefOf.Mincho_Infection.comps.Add(new HediffCompProperties()
			{
				compClass = typeof(MinchoInfectionHediffComp)
			});
		}
	}
}
