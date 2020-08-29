using Garam_RaceAddon;
using RimWorld;
using Verse;


namespace MinchoWitch
{
    [DefOf]
    public static class MinchoWitchDefOf
    {
        public static RaceAddonThingDef Mincho_ThingDef = new RaceAddonThingDef();
        public static RaceAddonThingDef MinchoWitch = new RaceAddonThingDef();
        public static RaceAddonPawnKindDef Mincho_WildMan_Infection = new RaceAddonPawnKindDef();
        public static RaceAddonPawnKindDef Mincho_Colonist_Infection = new RaceAddonPawnKindDef();
        public static RaceAddonPawnKindDef Mincho_NPC_Infection = new RaceAddonPawnKindDef();
        public static RaceAddonPawnKindDef Mincho_Animal_Infection = new RaceAddonPawnKindDef();
        public static SoundDef Pawn_Mincho_Death = new SoundDef();
        public static HediffDef Mincho_Infection = new HediffDef();
        public static HediffDef Mincho_Infection_Instant = new HediffDef();
        public static ThingDef Mincho_Filth_BloodDef = new ThingDef(); //나중에민초모드껄로
        public static GameConditionDef MinchoFallout;
        static MinchoWitchDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MinchoWitchDefOf));
        }
    }
}