namespace NRuneScape.RuneScape3
{
    public interface IRS3HiscoreCharacter : IHiscoreCharacter
    {
        SkillHiscore Divination { get; }
        SkillHiscore Dungeoneering { get; }
        SkillHiscore Invention { get; }
        SkillHiscore Summoning { get; }

        ActivityHiscore BountyHunter { get; }
        ActivityHiscore BountyHunterRogues { get; }
        ActivityHiscore DominionTower { get; }
        ActivityHiscore Crucible { get; }
        ActivityHiscore CastleWars { get; }
        ActivityHiscore BarbarianAssaultAttacker { get; }
        ActivityHiscore BarbarianAssaultDefender { get; }
        ActivityHiscore BarbarianAssaultCollector { get; }
        ActivityHiscore BarbarianAssaultHealer { get; }
        ActivityHiscore DuelTournament { get; }
        ActivityHiscore MobilisingArmies { get; }
        ActivityHiscore Conquest { get; }
        ActivityHiscore FistOfGuthix { get; }
        ActivityHiscore GielinorGamesResourceRace { get; }
        ActivityHiscore GielinorGamesAthletics { get; } 
        ActivityHiscore ArmadylContribution { get; }
        ActivityHiscore BandosContribution{ get; }
        ActivityHiscore ArmadylPVP { get; }
        ActivityHiscore BandosPVP { get; }
        ActivityHiscore HeistGuard { get; }
        ActivityHiscore HeistRobber { get; }
        ActivityHiscore CabbageFacepunch { get; }
        ActivityHiscore AprilFoolsCowTipping { get; }
        ActivityHiscore AprilFoolsRatKills{ get; }
    }
}
