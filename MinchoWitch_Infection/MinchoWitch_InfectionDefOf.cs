using System;
using RimWorld;
using Verse;
using Garam_RaceAddon;


namespace MinchoWitch_Infection
{
	[DefOf]
	public static class MinchoWitch_InfectionDefOf
	{
		public static RaceAddonPawnKindDef Mincho_Colonist = new RaceAddonPawnKindDef();
		public static RaceAddonPawnKindDef Mincho_WildMan = new RaceAddonPawnKindDef();
		public static SoundDef Pawn_Mincho_Death = new SoundDef();
		public static RaceAddonThingDef Mincho_ThingDef = new RaceAddonThingDef();
		public static HediffDef Mincho_Infection = new HediffDef();
		public static ThingDef Mincho_Filth_BloodDef = new ThingDef();
		static MinchoWitch_InfectionDefOf()
		{
			DefOfHelper.EnsureInitializedInCtor(typeof(MinchoWitch_InfectionDefOf));
		}
	}
}