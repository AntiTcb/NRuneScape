using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterModel = NRuneScape.OldSchool.API.HiscoreCharacter;

namespace NRuneScape.OldSchool
{
    public class OSHiscoreCharacter : OSCharacter, IOSHiscoreCharacter, IUpdateable
    {
        /// <summary> Gets the game mode for this character. </summary>
        public GameMode GameMode { get; }
        /// <summary> Returns a collection of activity hiscores. </summary>
        public IReadOnlyDictionary<Activity, ActivityHiscore> Activities => _activities;
        /// <summary> Returns a collection of skill hiscores. </summary>
        public IReadOnlyDictionary<Skill, SkillHiscore> Skills => _skills;

        /// <summary> Gets the Bounty Hunter - Hunter hiscore for this character. </summary>
        public ActivityHiscore BountyHunter => _activities[Activity.BountyHunter];
        /// <summary> Gets the Bounty Hunter - Rogue hiscore for this character. </summary>
        public ActivityHiscore BountyHunterRogue => _activities[Activity.BountyHunterRogue];

        /// <summary> Gets the Clue Scrolls - All hiscore for this character. </summary>
        public ActivityHiscore ClueScrollsAll => _activities[Activity.ClueScrollsAll];
        /// <summary> Gets the Clue Scrolls - Easy hiscore for this character. </summary>
        public ActivityHiscore ClueScrollsEasy => _activities[Activity.ClueScrollsEasy];
        /// <summary> Gets the Clue Scrolls - Elite hiscore for this character. </summary>
        public ActivityHiscore ClueScrollsElite => _activities[Activity.ClueScrollsElite];
        /// <summary> Gets the Clue Scrolls - Hard hiscore for this character. </summary>
        public ActivityHiscore ClueScrollsHard => _activities[Activity.ClueScrollsHard];
        /// <summary> Gets the Clue Scrolls - Master hiscore for this character. </summary>
        public ActivityHiscore ClueScrollsMaster => _activities[Activity.ClueScrollsMaster];
        /// <summary> Gets the Clue Scrolls - Medium hiscore for this character. </summary>
        public ActivityHiscore ClueScrollsMedium => _activities[Activity.ClueScrollsMedium];
        /// <summary> Gets the Last Man Standing - Rank hiscore for this character. </summary>
        public ActivityHiscore LastManStandingRank => _activities[Activity.LastManStanding];

        /// <summary> Gets the Agility hiscore for this character. </summary>
        public SkillHiscore Agility => _skills[Skill.Agility];
        /// <summary> Gets the Attack hiscore for this character. </summary>
        public SkillHiscore Attack => _skills[Skill.Attack];
        /// <summary> Gets the Construction hiscore for this character. </summary>
        public SkillHiscore Construction => _skills[Skill.Construction];
        /// <summary> Gets the Cooking hiscore for this character. </summary>
        public SkillHiscore Cooking => _skills[Skill.Cooking];
        /// <summary> Gets the Crafting hiscore for this character. </summary>
        public SkillHiscore Crafting => _skills[Skill.Crafting];
        /// <summary> Gets the Defence hiscore for this character. </summary>
        public SkillHiscore Defence => _skills[Skill.Defence];
        /// <summary> Gets the Farming hiscore for this character. </summary>
        public SkillHiscore Farming => _skills[Skill.Farming];
        /// <summary> Gets the Firemaking hiscore for this character. </summary>
        public SkillHiscore Firemaking => _skills[Skill.Firemaking];
        /// <summary> Gets the Fishing hiscore for this character. </summary>
        public SkillHiscore Fishing => _skills[Skill.Fishing];
        /// <summary> Gets the Fletching hiscore for this character. </summary>
        public SkillHiscore Fletching => _skills[Skill.Fletching];
        /// <summary> Gets the Herblore hiscore for this character. </summary>
        public SkillHiscore Herblore => _skills[Skill.Herblore];
        /// <summary> Gets the Hitpoints hiscore for this character. </summary>
        public SkillHiscore Hitpoints => _skills[Skill.Hitpoints];
        /// <summary> Gets the Hunter hiscore for this character. </summary>
        public SkillHiscore Hunter => _skills[Skill.Hunter];
        /// <summary> Gets the Magic hiscore for this character. </summary>
        public SkillHiscore Magic => _skills[Skill.Magic];
        /// <summary> Gets the Mining hiscore for this character. </summary>
        public SkillHiscore Mining => _skills[Skill.Mining];
        /// <summary> Gets the Overall hiscore for this character. </summary>
        public SkillHiscore Overall => _skills[Skill.Overall];
        /// <summary> Gets the Prayer hiscore for this character. </summary>
        public SkillHiscore Prayer => _skills[Skill.Prayer];
        /// <summary> Gets the Ranged hiscore for this character. </summary>
        public SkillHiscore Ranged => _skills[Skill.Ranged];
        /// <summary> Gets the Runecraft hiscore for this character. </summary>
        public SkillHiscore Runecraft => _skills[Skill.Runecraft];
        /// <summary> Gets the Slayer hiscore for this character. </summary>
        public SkillHiscore Slayer => _skills[Skill.Slayer];
        /// <summary> Gets the Smithing hiscore for this character. </summary>
        public SkillHiscore Smithing => _skills[Skill.Smithing];
        /// <summary> Gets the Strength hiscore for this character. </summary>
        public SkillHiscore Strength => _skills[Skill.Strength];
        /// <summary> Gets the Thieving hiscore for this character. </summary>
        public SkillHiscore Thieving => _skills[Skill.Thieving];
        /// <summary> Gets the Woodcutting hiscore for this character. </summary>
        public SkillHiscore Woodcutting => _skills[Skill.Woodcutting];

        private ConcurrentDictionary<Activity, ActivityHiscore> _activities;
        private ConcurrentDictionary<Skill, SkillHiscore> _skills;

        /// <summary> Updates all hiscores for this character. </summary>
        public async Task UpdateAsync()
        {
            var updatedModel = await RuneScape.ApiClient.GetCharacterAsync(Name, EnumUtils.GetRoute(GameMode), RequestOptions.Default);
            Update(updatedModel);
        }

        internal OSHiscoreCharacter(OSRestClient client, CharacterModel model) : base(client)
        {
            Name = model.Name;
            GameMode = model.GameMode;
            Update(model);
        }

        internal static OSHiscoreCharacter Create(OSRestClient client, CharacterModel model)
            => new OSHiscoreCharacter(client, model);

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
