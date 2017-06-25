using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterModel = NRuneScape.OldSchool.API.HiscoreCharacter;

namespace NRuneScape.OldSchool
{
    public class OSHiscoreCharacter : OSCharacter, IOSHiscoreCharacter, IUpdateable
    {                                                                
        /// <summary> Returns a collection of activity hiscores. </summary>
        public IReadOnlyDictionary<Activity, OSActivityHiscore> Activities => _activities;
        /// <summary> Returns a collection of skill hiscores. </summary>
        public IReadOnlyDictionary<Skill, OSSkillHiscore> Skills => _skills;

        /// <summary> Gets the Bounty Hunter - Hunter hiscore for this character. </summary>
        public OSActivityHiscore BountyHunterHunter => _activities[Activity.BountyHunterHunter];
        /// <summary> Gets the Bounty Hunter - Rogue hiscore for this character. </summary>
        public OSActivityHiscore BountyHunterRogue => _activities[Activity.BountyHunterRogue];
        /// <summary> Gets the Clue Scrolls - All hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsAll => _activities[Activity.ClueScrollsAll];
        /// <summary> Gets the Clue Scrolls - Easy hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsEasy => _activities[Activity.ClueScrollsEasy];
        /// <summary> Gets the Clue Scrolls - Elite hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsElite => _activities[Activity.ClueScrollsElite];
        /// <summary> Gets the Clue Scrolls - Hard hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsHard => _activities[Activity.ClueScrollsHard];
        /// <summary> Gets the Clue Scrolls - Master hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsMaster => _activities[Activity.ClueScrollsMaster];
        /// <summary> Gets the Clue Scrolls - Medium hiscore for this character. </summary>
        public OSActivityHiscore ClueScrollsMedium => _activities[Activity.ClueScrollsMedium];
        /// <summary> Gets the Last Man Standing - Rank hiscore for this character. </summary>
        public OSActivityHiscore LastManStandingRank => _activities[Activity.LastManStandingRank];

        /// <summary> Gets the Agility hiscore for this character. </summary>
        public OSSkillHiscore Agility => _skills[Skill.Agility];
        /// <summary> Gets the Attack hiscore for this character. </summary>
        public OSSkillHiscore Attack => _skills[Skill.Attack];
        /// <summary> Gets the Construction hiscore for this character. </summary>
        public OSSkillHiscore Construction => _skills[Skill.Construction];
        /// <summary> Gets the Cooking hiscore for this character. </summary>
        public OSSkillHiscore Cooking => _skills[Skill.Cooking];
        /// <summary> Gets the Crafting hiscore for this character. </summary>
        public OSSkillHiscore Crafting => _skills[Skill.Crafting];
        /// <summary> Gets the Defence hiscore for this character. </summary>
        public OSSkillHiscore Defence => _skills[Skill.Defence];
        /// <summary> Gets the Farming hiscore for this character. </summary>
        public OSSkillHiscore Farming => _skills[Skill.Farming];
        /// <summary> Gets the Firemaking hiscore for this character. </summary>
        public OSSkillHiscore Firemaking => _skills[Skill.Firemaking];
        /// <summary> Gets the Fishing hiscore for this character. </summary>
        public OSSkillHiscore Fishing => _skills[Skill.Fishing];
        /// <summary> Gets the Fletching hiscore for this character. </summary>
        public OSSkillHiscore Fletching => _skills[Skill.Fletching];
        /// <summary> Gets the Herblore hiscore for this character. </summary>
        public OSSkillHiscore Herblore => _skills[Skill.Herblore];
        /// <summary> Gets the Hitpoints hiscore for this character. </summary>
        public OSSkillHiscore Hitpoints => _skills[Skill.Hitpoints];
        /// <summary> Gets the Hunter hiscore for this character. </summary>
        public OSSkillHiscore Hunter => _skills[Skill.Hunter];
        /// <summary> Gets the Magic hiscore for this character. </summary>
        public OSSkillHiscore Magic => _skills[Skill.Magic];
        /// <summary> Gets the Mining hiscore for this character. </summary>
        public OSSkillHiscore Mining => _skills[Skill.Mining];
        /// <summary> Gets the Overall hiscore for this character. </summary>
        public OSSkillHiscore Overall => _skills[Skill.Overall];
        /// <summary> Gets the Prayer hiscore for this character. </summary>
        public OSSkillHiscore Prayer => _skills[Skill.Prayer];
        /// <summary> Gets the Ranged hiscore for this character. </summary>
        public OSSkillHiscore Ranged => _skills[Skill.Ranged];
        /// <summary> Gets the Runecraft hiscore for this character. </summary>
        public OSSkillHiscore Runecraft => _skills[Skill.Runecraft];
        /// <summary> Gets the Slayer hiscore for this character. </summary>
        public OSSkillHiscore Slayer => _skills[Skill.Slayer];
        /// <summary> Gets the Smithing hiscore for this character. </summary>
        public OSSkillHiscore Smithing => _skills[Skill.Smithing];
        /// <summary> Gets the Strength hiscore for this character. </summary>
        public OSSkillHiscore Strength => _skills[Skill.Strength];
        /// <summary> Gets the Thieving hiscore for this character. </summary>
        public OSSkillHiscore Thieving => _skills[Skill.Thieving];
        /// <summary> Gets the Woodcutting hiscore for this character. </summary>
        public OSSkillHiscore Woodcutting => _skills[Skill.Woodcutting];

        private ConcurrentDictionary<Activity, OSActivityHiscore> _activities;
        private ConcurrentDictionary<Skill, OSSkillHiscore> _skills;

        /// <summary> Updates all hiscores for this character. </summary>          
        public async Task UpdateAsync()
        {
            var updatedModel = await RuneScape.ApiClient.GetCharacterAsync(Name, EnumUtils.GetRoute(GameMode));
            Update(updatedModel);
        }                              

        internal OSHiscoreCharacter(OldSchoolRestClient client, CharacterModel model) : base(client)
        {
            Name = model.Name;
            GameMode = model.GameMode;
            Update(model);
        }

        internal static OSHiscoreCharacter Create(OldSchoolRestClient client, CharacterModel model)
        {
            return new OSHiscoreCharacter(client, model);
        }

        internal void Update(CharacterModel model)
        {
            _skills = model.Skills;
            _activities = model.Activities;
        }

        //IHiscoreChracter
        IReadOnlyDictionary<int, IActivityHiscore> IHiscoreCharacter.Activities 
            => Activities.ToDictionary(x => (int)x.Key, x => x.Value as IActivityHiscore);
        IReadOnlyDictionary<int, ISkillHiscore> IHiscoreCharacter.Skills 
            => Skills.ToDictionary(x => (int)x.Key, x => x.Value as ISkillHiscore);
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
