using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CharacterModel = NRuneScape.OldSchool.API.HiscoreCharacter;

namespace NRuneScape.OldSchool
{
    public class OSHiscoreCharacter : OSCharacter, IOSHiscoreCharacter
    {
        public IReadOnlyCollection<OSActivityHiscore> Activities => _activities.Values.ToImmutableArray();
        public IReadOnlyCollection<OSSkillHiscore> Skills => _skills.Values.ToImmutableArray();

        public OSActivityHiscore BountyHunterHunter => _activities[OSActivity.BountyHunterHunter];
        public OSActivityHiscore BountyHunterRogue => _activities[OSActivity.BountyHunterRogue];
        public OSActivityHiscore ClueScrollsAll => _activities[OSActivity.ClueScrollsAll];
        public OSActivityHiscore ClueScrollsEasy => _activities[OSActivity.ClueScrollsEasy];
        public OSActivityHiscore ClueScrollsElite => _activities[OSActivity.ClueScrollsElite];
        public OSActivityHiscore ClueScrollsHard => _activities[OSActivity.ClueScrollsHard];
        public OSActivityHiscore ClueScrollsMaster => _activities[OSActivity.ClueScrollsMaster];
        public OSActivityHiscore ClueScrollsMedium => _activities[OSActivity.ClueScrollsMedium];
        public OSActivityHiscore LastManStandingRank => _activities[OSActivity.LastManStandingRank];

        public OSSkillHiscore Agility => _skills[OSSkill.Agility];
        public OSSkillHiscore Attack => _skills[OSSkill.Attack];
        public OSSkillHiscore Construction => _skills[OSSkill.Construction];
        public OSSkillHiscore Cooking => _skills[OSSkill.Cooking];
        public OSSkillHiscore Crafting => _skills[OSSkill.Crafting];
        public OSSkillHiscore Defence => _skills[OSSkill.Defence];
        public OSSkillHiscore Farming => _skills[OSSkill.Farming];
        public OSSkillHiscore Firemaking => _skills[OSSkill.Firemaking];
        public OSSkillHiscore Fishing => _skills[OSSkill.Fishing];
        public OSSkillHiscore Fletching => _skills[OSSkill.Fletching];
        public OSSkillHiscore Herblore => _skills[OSSkill.Herblore];
        public OSSkillHiscore Hitpoints => _skills[OSSkill.Hitpoints];
        public OSSkillHiscore Hunter => _skills[OSSkill.Hunter];
        public OSSkillHiscore Magic => _skills[OSSkill.Magic];
        public OSSkillHiscore Mining => _skills[OSSkill.Mining];
        public OSSkillHiscore Overall => _skills[OSSkill.Overall];
        public OSSkillHiscore Prayer => _skills[OSSkill.Prayer];
        public OSSkillHiscore Ranged => _skills[OSSkill.Ranged];
        public OSSkillHiscore Runecraft => _skills[OSSkill.Runecraft];
        public OSSkillHiscore Slayer => _skills[OSSkill.Slayer];
        public OSSkillHiscore Smithing => _skills[OSSkill.Smithing];
        public OSSkillHiscore Strength => _skills[OSSkill.Strength];
        public OSSkillHiscore Thieving => _skills[OSSkill.Thieving];
        public OSSkillHiscore Woodcutting => _skills[OSSkill.Woodcutting];

        private ConcurrentDictionary<OSActivity, OSActivityHiscore> _activities;
        private ConcurrentDictionary<OSSkill, OSSkillHiscore> _skills;

        public override async Task UpdateAsync()
        {
            var updatedModel = await RuneScape.ApiClient.GetCharacterAsync(Name, GameMode);
            Update(updatedModel);
        }                              

        internal OSHiscoreCharacter(OSRSClient client, CharacterModel model) : base(client)
        {
            Name = model.Name;
            GameMode = model.Skills.Values.First().GameMode;
            Update(model);
        }

        internal static OSCharacter Create(OSRSClient client, CharacterModel model)
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
