using System.Diagnostics;
using CharacterModel = NRuneScape.OldSchool.API.Character;

namespace NRuneScape.OldSchool
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Threading.Tasks;

    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OSRSCharacter : RestEntity, IOSRSCharacter, IHiScoreCharacter
    {
        public OSRSGameMode AccountType { get; private set; }
        public IReadOnlyCollection<OSRSActivityHiScore> Activities => _activities.Values.ToImmutableArray();
        public IReadOnlyCollection<OSRSSkillHiScore> Skills => _skills.Values.ToImmutableArray();

        public string Name { get; private set; }

        public OSRSActivityHiScore BountyHunterHunter => _activities[OSRSActivity.BountyHunterHunter];
        public OSRSActivityHiScore BountyHunterRogue => _activities[OSRSActivity.BountyHunterRogue];
        public OSRSActivityHiScore ClueScrollsAll => _activities[OSRSActivity.ClueScrollsAll];
        public OSRSActivityHiScore ClueScrollsEasy => _activities[OSRSActivity.ClueScrollsEasy];
        public OSRSActivityHiScore ClueScrollsElite => _activities[OSRSActivity.ClueScrollsElite];
        public OSRSActivityHiScore ClueScrollsHard => _activities[OSRSActivity.ClueScrollsHard];
        public OSRSActivityHiScore ClueScrollsMaster => _activities[OSRSActivity.ClueScrollsMaster];
        public OSRSActivityHiScore ClueScrollsMedium => _activities[OSRSActivity.ClueScrollsMedium];
        public OSRSActivityHiScore LastManStandingRank => _activities[OSRSActivity.LastManStandingRank];

        public OSRSSkillHiScore Agility => _skills[OSRSSkill.Agility];
        public OSRSSkillHiScore Attack => _skills[OSRSSkill.Attack];
        public OSRSSkillHiScore Construction => _skills[OSRSSkill.Construction];
        public OSRSSkillHiScore Cooking => _skills[OSRSSkill.Cooking];
        public OSRSSkillHiScore Crafting => _skills[OSRSSkill.Crafting];
        public OSRSSkillHiScore Defence => _skills[OSRSSkill.Defence];
        public OSRSSkillHiScore Farming => _skills[OSRSSkill.Farming];
        public OSRSSkillHiScore Firemaking => _skills[OSRSSkill.Firemaking];
        public OSRSSkillHiScore Fishing => _skills[OSRSSkill.Fishing];
        public OSRSSkillHiScore Fletching => _skills[OSRSSkill.Fletching];
        public OSRSSkillHiScore Herblore => _skills[OSRSSkill.Herblore];
        public OSRSSkillHiScore Hitpoints => _skills[OSRSSkill.Hitpoints];
        public OSRSSkillHiScore Hunter => _skills[OSRSSkill.Hunter];
        public OSRSSkillHiScore Magic => _skills[OSRSSkill.Magic];
        public OSRSSkillHiScore Mining => _skills[OSRSSkill.Mining];
        public OSRSSkillHiScore Overall => _skills[OSRSSkill.Overall];
        public OSRSSkillHiScore Prayer => _skills[OSRSSkill.Prayer];
        public OSRSSkillHiScore Ranged => _skills[OSRSSkill.Ranged];
        public OSRSSkillHiScore Runecraft => _skills[OSRSSkill.Runecraft];
        public OSRSSkillHiScore Slayer => _skills[OSRSSkill.Slayer];
        public OSRSSkillHiScore Smithing => _skills[OSRSSkill.Smithing];
        public OSRSSkillHiScore Strength => _skills[OSRSSkill.Strength];
        public OSRSSkillHiScore Thieving => _skills[OSRSSkill.Thieving];
        public OSRSSkillHiScore Woodcutting => _skills[OSRSSkill.Woodcutting];

        IReadOnlyCollection<IActivityHiScore> IHiScoreCharacter.Activites => Activities;
        ISkillHiScore IHiScoreCharacter.Agility => Agility;
        ISkillHiScore IHiScoreCharacter.Attack => Attack;
        ISkillHiScore IHiScoreCharacter.Construction => Construction;
        ISkillHiScore IHiScoreCharacter.Cooking => Cooking;
        ISkillHiScore IHiScoreCharacter.Crafting => Crafting;
        ISkillHiScore IHiScoreCharacter.Defence => Defence;
        ISkillHiScore IHiScoreCharacter.Farming => Farming;
        ISkillHiScore IHiScoreCharacter.Firemaking => Firemaking;
        ISkillHiScore IHiScoreCharacter.Fishing => Fishing;
        ISkillHiScore IHiScoreCharacter.Fletching => Fletching;
        ISkillHiScore IHiScoreCharacter.Herblore => Herblore;
        ISkillHiScore IHiScoreCharacter.Hitpoints => Hitpoints;
        ISkillHiScore IHiScoreCharacter.Hunter => Hunter;
        ISkillHiScore IHiScoreCharacter.Magic => Magic;
        ISkillHiScore IHiScoreCharacter.Mining => Mining;
        ISkillHiScore IHiScoreCharacter.Overall => Overall;
        ISkillHiScore IHiScoreCharacter.Prayer => Prayer;
        ISkillHiScore IHiScoreCharacter.Ranged => Ranged;
        ISkillHiScore IHiScoreCharacter.Runecraft => Runecraft;
        IReadOnlyCollection<ISkillHiScore> IHiScoreCharacter.Skills => Skills;
        ISkillHiScore IHiScoreCharacter.Slayer => Slayer;
        ISkillHiScore IHiScoreCharacter.Smithing => Smithing;
        ISkillHiScore IHiScoreCharacter.Strength => Strength;
        ISkillHiScore IHiScoreCharacter.Thieving => Thieving;
        ISkillHiScore IHiScoreCharacter.Woodcutting => Woodcutting;

        private ConcurrentDictionary<OSRSActivity, OSRSActivityHiScore> _activities;
        private ConcurrentDictionary<OSRSSkill, OSRSSkillHiScore> _skills;

        internal OSRSCharacter(OSRSClient client, CharacterModel model) : base(client)
        {
            Name = model.Name;
            AccountType = model.Skills.Values.First().GameMode;
            Update(model);
        }

        public OSRSActivityHiScore GetActivityHiScore(OSRSActivity activity) => _activities[activity];

        public OSRSSkillHiScore GetSkillHiScore(OSRSSkill skill) => _skills[skill];

        public Task UpdateAsync()
        {
            throw new NotImplementedException();
        }

        internal static OSRSCharacter Create(OSRSClient client, CharacterModel model)
        {
            return new OSRSCharacter(client, model);
        }

        internal void Update(CharacterModel model)
        {
            _skills = model.Skills;
            _activities = model.Activities;
        }

        private string DebuggerDisplay => $"({Name} | {AccountType})";
    }
}