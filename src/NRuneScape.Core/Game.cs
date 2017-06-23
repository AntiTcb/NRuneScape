namespace NRuneScape
{
    public enum Game
    {
        [GERoute("itemdb_oldschool"), HiscoreRoute("hiscore_oldschool")]
        OldSchool,
        [GERoute("itemdb_rs"), HiscoreRoute("hiscore")]
        RuneScape3
    } 
}
