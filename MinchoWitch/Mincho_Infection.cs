using Verse;

//xml에서 <li>HediffCompProperties 가 아니라, 걍 스타트업과 동시에 comp에 추가해주는거, 하드코딩이라 범용성은 조금 낮아짐.
namespace MinchoWitch
{
    [StaticConstructorOnStartup]
    public static class Mincho_Infection
    {
        static Mincho_Infection()
        {
            MinchoWitchDefOf.Mincho_Infection.comps.Add(new HediffCompProperties()
            {
                compClass = typeof(HediffComp_MinchoInfection)
            });
        }
    }

    [StaticConstructorOnStartup]
    public static class Mincho_Infection_Instant
    {
        static Mincho_Infection_Instant()
        {
            MinchoWitchDefOf.Mincho_Infection_Instant.comps.Add(new HediffCompProperties()
            {
                compClass = typeof(HediffComp_MinchoInfection_Instant)
            });
        }
    }
}
