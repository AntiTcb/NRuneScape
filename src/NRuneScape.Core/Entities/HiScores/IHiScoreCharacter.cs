using System.Collections.Generic;

namespace NRuneScape
{
    /// <summary>
    /// The base interface for a character's hiscore values. 
    /// </summary>
    public interface IHiscoreCharacter : ICharacter
    {
        /// <summary> Returns a dictionary of the activity hiscores for this character. </summary>
        IReadOnlyDictionary<int, IActivityHiscore> Activities { get; }
        /// <summary> Returns a dictionary of the activity hiscores for this character. </summary>
        IReadOnlyDictionary<int, ISkillHiscore> Skills { get; }

        /// <summary> Gets the Agility hiscore for this character. </summary>
        ISkillHiscore Agility { get; }
        /// <summary> Gets the Attack hiscore for this character. </summary>
        ISkillHiscore Attack { get; }
        /// <summary> Gets the Construction hiscore for this character. </summary>
        ISkillHiscore Construction { get; }
        /// <summary> Gets the Cooking hiscore for this character. </summary>
        ISkillHiscore Cooking { get; }
        /// <summary> Gets the Crafting hiscore for this character. </summary>
        ISkillHiscore Crafting { get; }
        /// <summary> Gets the Defence hiscore for this character. </summary>
        ISkillHiscore Defence { get; }
        /// <summary> Gets the Farming hiscore for this character. </summary>
        ISkillHiscore Farming { get; }
        /// <summary> Gets the Firemaking hiscore for this character. </summary>
        ISkillHiscore Firemaking { get; }
        /// <summary> Gets the Fishing hiscore for this character. </summary>
        ISkillHiscore Fishing { get; }
        /// <summary> Gets the Fletching hiscore for this character. </summary>
        ISkillHiscore Fletching { get; }
        /// <summary> Gets the Herblore hiscore for this character. </summary>
        ISkillHiscore Herblore { get; }
        /// <summary> Gets the Hitpoints hiscore for this character. </summary>
        ISkillHiscore Hitpoints { get; }
        /// <summary> Gets the Hunter hiscore for this character. </summary>
        ISkillHiscore Hunter { get; }
        /// <summary> Gets the Magic hiscore for this character. </summary>
        ISkillHiscore Magic { get; }
        /// <summary> Gets the Mining hiscore for this character. </summary>
        ISkillHiscore Mining { get; }
        /// <summary> Gets the Overall hiscore for this character. </summary>
        ISkillHiscore Overall { get; }
        /// <summary> Gets the Prayer hiscore for this character. </summary>
        ISkillHiscore Prayer { get; }
        /// <summary> Gets the Ranged hiscore for this character. </summary>
        ISkillHiscore Ranged { get; }
        /// <summary> Gets the Runecraft hiscore for this character. </summary>
        ISkillHiscore Runecraft { get; }
        /// <summary> Gets the Slayer hiscore for this chracter. </summary>
        ISkillHiscore Slayer { get; }
        /// <summary> Gets the Smithing hiscore for this character. </summary>
        ISkillHiscore Smithing { get; }
        /// <summary> Gets the Strength hiscore for this character. </summary>
        ISkillHiscore Strength { get; }
        /// <summary> Gets the Thieving hiscore for this character. </summary>
        ISkillHiscore Thieving { get; }
        /// <summary> Gets the Woodcutting hiscore for this character. </summary>
        ISkillHiscore Woodcutting { get; }
    }
}