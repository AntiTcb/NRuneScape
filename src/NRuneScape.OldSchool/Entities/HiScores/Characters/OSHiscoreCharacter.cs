using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CharacterModel = NRuneScape.OldSchool.API.HiscoreCharacter;

namespace NRuneScape.OldSchool
{
    public class OSHiscoreCharacter : OSCharacter, IOSHiscoreCharacter, IUpdateable
    {                                                                
        /// <summary> Returns a collection of activity hiscores. </summary>
        public IReadOnlyCollection<OSActivityHiscore> Activities => _activities.Values.ToImmutableArray();
        /// <summary> Returns a collection of skill hiscores. </summary>
        public IReadOnlyCollection<OSSkillHiscore> Skills => _skills.Values.ToImmutableArray();

        /// <summary> Gets the Bounty Hunter - Hunter hiscore for this character. </summary>
        public OSActivityHiscore BountyHunterHunter => _activities[OSActivity.BountyHunterHunter];
        /// <summary> Gets the Bounty Hunter - Rogue hiscore for this character. </summary>
        public OSActivityHiscore BountyHunterRogue => _activities[OSActivity.BountyHunterRogue];
        /// <summary> Gets the Clue Scrolls - All hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsAll => _activities[OSActivity.ClueScrollsAll];
        /// <summary> Gets the Clue Scrolls - Easy hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsEasy => _activities[OSActivity.ClueScrollsEasy];
        /// <summary> Gets the Clue Scrolls - Elite hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsElite => _activities[OSActivity.ClueScrollsElite];
        /// <summary> Gets the Clue Scrolls - Hard hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsHard => _activities[OSActivity.ClueScrollsHard];
        /// <summary> Gets the Clue Scrolls - Master hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsMaster => _activities[OSActivity.ClueScrollsMaster];
        /// <summary> Gets the Clue Scrolls - Medium hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsMedium => _activities[OSActivity.ClueScrollsMedium];
        /// <summary> Gets the Last Man Standing - Rank hiscore for this character. </summary>
        public OSActivityHiscore LastManStandingRank => _activities[OSActivity.LastManStandingRank];

        /// <summary> Gets the Agility hiscore for this character. </summary>
        public OSSkillHiscore Agility => _skills[OSSkill.Agility];
        /// <summary> Gets the Attack hiscore for this character. </summary>
        public OSSkillHiscore Attack => _skills[OSSkill.Attack];
        /// <summary> Gets the Construction hiscore for this character. </summary>
        public OSSkillHiscore Construction => _skills[OSSkill.Construction];
        /// <summary> Gets the Cooking hiscore for this character. </summary>
        public OSSkillHiscore Cooking => _skills[OSSkill.Cooking];
        /// <summary> Gets the Crafting hiscore for this character. </summary>
        public OSSkillHiscore Crafting => _skills[OSSkill.Crafting];
        /// <summary> Gets the Defence hiscore for this character. </summary>
        public OSSkillHiscore Defence => _skills[OSSkill.Defence];
        /// <summary> Gets the Farming hiscore for this character. </summary>
        public OSSkillHiscore Farming => _skills[OSSkill.Farming];
        /// <summary> Gets the Firemaking hiscore for this character. </summary>
        public OSSkillHiscore Firemaking => _skills[OSSkill.Firemaking];
        /// <summary> Gets the Fishing hiscore for this character. </summary>
        public OSSkillHiscore Fishing => _skills[OSSkill.Fishing];
        /// <summary> Gets the Fletching hiscore for this character. </summary>
        public OSSkillHiscore Fletching => _skills[OSSkill.Fletching];
        /// <summary> Gets the Herblore hiscore for this character. </summary>
        public OSSkillHiscore Herblore => _skills[OSSkill.Herblore];
        /// <summary> Gets the Hitpoints hiscore for this character. </summary>
        public OSSkillHiscore Hitpoints => _skills[OSSkill.Hitpoints];
        /// <summary> Gets the Hunter hiscore for this character. </summary>
        public OSSkillHiscore Hunter => _skills[OSSkill.Hunter];
        /// <summary> Gets the Magic hiscore for this character. </summary>
        public OSSkillHiscore Magic => _skills[OSSkill.Magic];
        /// <summary> Gets the Mining hiscore for this character. </summary>
        public OSSkillHiscore Mining => _skills[OSSkill.Mining];
        /// <summary> Gets the Overall hiscore for this character. </summary>
        public OSSkillHiscore Overall => _skills[OSSkill.Overall];
        /// <summary> Gets the Prayer hiscore for this character. </summary>
        public OSSkillHiscore Prayer => _skills[OSSkill.Prayer];
        /// <summary> Gets the Ranged hiscore for this character. </summary>
        public OSSkillHiscore Ranged => _skills[OSSkill.Ranged];
        /// <summary> Gets the Runecraft hiscore for this character. </summary>
        public OSSkillHiscore Runecraft => _skills[OSSkill.Runecraft];
        /// <summary> Gets the Slayer hiscore for this character. </summary>
        public OSSkillHiscore Slayer => _skills[OSSkill.Slayer];
        /// <summary> Gets the Smithing hiscore for this character. </summary>
        public OSSkillHiscore Smithing => _skills[OSSkill.Smithing];
        /// <summary> Gets the Strength hiscore for this character. </summary>
        public OSSkillHiscore Strength => _skills[OSSkill.Strength];
        /// <summary> Gets the Thieving hiscore for this character. </summary>
        public OSSkillHiscore Thieving => _skills[OSSkill.Thieving];
        /// <summary> Gets the Woodcutting hiscore for this character. </summary>
        public OSSkillHiscore Woodcutting => _skills[OSSkill.Woodcutting];

        private ConcurrentDictionary<OSActivity, OSActivityHiscore> _activities;
        private ConcurrentDictionary<OSSkill, OSSkillHiscore> _skills;

        /// <summary> Updates all hiscores for this character. </summary>          
        public async Task UpdateAsync()
        {
            var updatedModel = await RuneScape.ApiClient.GetCharacterAsync(Name, GameMode);
            Update(updatedModel);
        }                              

        internal OSHiscoreCharacter(OSClient client, CharacterModel model) : base(client)
        {
            Name = model.Name;
            GameMode = model.Skills.Values.First().GameMode;
            Update(model);
        }

        internal static OSCharacter Create(OSClient client, CharacterModel model)
        {
            return new OSHiscoreCharacter(client, model);
        }

        internal void Update(CharacterModel model)
        {
            _skills = model.Skills;
            _activities = model.Activities;
        }

        //IHiscoreChracter
        IReadOnlyCollection<IActivityHiscore> IHiscoreCharacter.Activities => Activities;
        IReadOnlyCollection<ISkillHiscore> IHiscoreCharacter.Skills => Skills;
        ISkillHiscore IHiscoreCharacter.Agility => Agility;
        ISkillHiscore IHiscoreCharacter.Attack => Attack;
        ISkillHiscore IHiscoreCharacter.Construction => Construction;
        ISkillHiscore IHiscoreCharacter.Cooking => Cooking;
        ISkillHiscore IHiscoreCharacter.Crafting => Crafting;
        ISkillHiscore IHiscoreCharacter.Defence => Defence;
        ISkillHiscore IHiscoreCharacter.Farming => Farming;
        ISkillHiscore IHiscoreCharacter.Firemaking => Firemaking;
        ISkillHiscore IHiscoreCharacter.Fishing => Fishing;
        ISkillHiscore IHiscoreCharacter.Fletching => Fletching;
        ISkillHiscore IHiscoreCharacter.Herblore => Herblore;
        ISkillHiscore IHiscoreCharacter.Hitpoints => Hitpoints;
        ISkillHiscore IHiscoreCharacter.Hunter => Hunter;
        ISkillHiscore IHiscoreCharacter.Magic => Magic;
        ISkillHiscore IHiscoreCharacter.Mining => Mining;
        ISkillHiscore IHiscoreCharacter.Overall => Overall;
        ISkillHiscore IHiscoreCharacter.Prayer => Prayer;
        ISkillHiscore IHiscoreCharacter.Ranged => Ranged;
        ISkillHiscore IHiscoreCharacter.Runecraft => Runecraft;
        ISkillHiscore IHiscoreCharacter.Slayer => Slayer;
        ISkillHiscore IHiscoreCharacter.Smithing => Smithing;
        ISkillHiscore IHiscoreCharacter.Strength => Strength;
        ISkillHiscore IHiscoreCharacter.Thieving => Thieving;
        ISkillHiscore IHiscoreCharacter.Woodcutting => Woodcutting;
    }
}
