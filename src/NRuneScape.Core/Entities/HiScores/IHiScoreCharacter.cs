using System.Collections.Generic;

namespace NRuneScape
{
    public interface IHiScoreCharacter : ICharacter
    {
        IReadOnlyCollection<IActivityHiScore> Activites { get; }
        ISkillHiScore Agility { get; }
        ISkillHiScore Attack { get; }
        ISkillHiScore Construction { get; }
        ISkillHiScore Cooking { get; }
        ISkillHiScore Crafting { get; }
        ISkillHiScore Defence { get; }
        ISkillHiScore Farming { get; }
        ISkillHiScore Firemaking { get; }
        ISkillHiScore Fishing { get; }
        ISkillHiScore Fletching { get; }
        ISkillHiScore Herblore { get; }
        ISkillHiScore Hitpoints { get; }
        ISkillHiScore Hunter { get; }
        ISkillHiScore Magic { get; }
        ISkillHiScore Mining { get; }
        ISkillHiScore Overall { get; }
        ISkillHiScore Prayer { get; }
        ISkillHiScore Ranged { get; }
        ISkillHiScore Runecraft { get; }
        IReadOnlyCollection<ISkillHiScore> Skills { get; }
        ISkillHiScore Slayer { get; }
        ISkillHiScore Smithing { get; }
        ISkillHiScore Strength { get; }
        ISkillHiScore Thieving { get; }
        ISkillHiScore Woodcutting { get; }
    }
}