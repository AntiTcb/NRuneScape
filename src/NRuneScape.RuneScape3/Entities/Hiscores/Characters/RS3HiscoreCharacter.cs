using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CharacterModel = NRuneScape.RuneScape3.API.HiscoreCharacter;

namespace NRuneScape.RuneScape3
{
    public class RS3HiscoreCharacter : RS3Character, IRS3HiscoreCharacter, IUpdateable
    {
        /// <summary> Gets the game mode for this character. </summary>
        public GameMode GameMode { get; }
        /// <summary> Returns a collection of activity hiscores. </summary>
        public IReadOnlyDictionary<Activity, ActivityHiscore> Activities => _activities;
        /// <summary> Returns a collection of skill hiscores. </summary>
        public IReadOnlyDictionary<Skill, SkillHiscore> Skills => _skills;

        /// <summary> Gets the Bounty Hunter hiscore for this character. </summary>
        public ActivityHiscore BountyHunter => _activities[Activity.BountyHunter];
        /// <summary> Gets the Bounty Hunter Rogues hiscore for this character. </summary>
        public ActivityHiscore BountyHunterRogues => _activities[Activity.BountyHunterRogues];
        /// <summary> Gets the Dominion Tower hiscore for this character. </summary>
        public ActivityHiscore DominionTower => _activities[Activity.DominionTower];
        /// <summary> Gets the Crucible hiscore for this character. </summary>
        public ActivityHiscore Crucible => _activities[Activity.Crucible];
        /// <summary> Gets the Castle Wars hiscore for this character. </summary>
        public ActivityHiscore CastleWars => _activities[Activity.CastleWars];
        /// <summary> Gets the Barbarian Assault - Attacker hiscore for this character. </summary>
        public ActivityHiscore BarbarianAssaultAttacker => _activities[Activity.BarbarianAssaultAttacker];
        /// <summary> Gets the Barbarian Assault - Defender hiscore for this character. </summary>
        public ActivityHiscore BarbarianAssaultDefender => _activities[Activity.BarbarianAssaultDefender];
        /// <summary> Gets the Barbarian Assault - Collector hiscore for this character. </summary>
        public ActivityHiscore BarbarianAssaultCollector => _activities[Activity.BarbarianAssaultCollector];
        /// <summary> Gets the Barbarian Assault - Healer hiscore for this character. </summary>
        public ActivityHiscore BarbarianAssaultHealer => _activities[Activity.BarbarianAssaultHealer];
        /// <summary> Gets the Duel Tournament hiscore for this character. </summary>
        public ActivityHiscore DuelTournament => _activities[Activity.DuelTournament];
        /// <summary> Gets the Mobilising Armies hiscore for this character. </summary>
        public ActivityHiscore MobilisingArmies => _activities[Activity.MobilisingArmies];
        /// <summary> Gets the Conquest hiscore for this character. </summary>
        public ActivityHiscore Conquest => _activities[Activity.Conquest];
        /// <summary> Gets the Fist of Guthix hiscore for this character. </summary>
        public ActivityHiscore FistOfGuthix => _activities[Activity.FistOfGuthix];
        /// <summary> Gets the Gielinor Games: Resource Race hiscore for this character. </summary>
        public ActivityHiscore GielinorGamesResourceRace => _activities[Activity.GielinorGamesResourceRace];
        /// <summary> Gets the Gielinor Games: Athletics hiscore for this character. </summary>
        public ActivityHiscore GielinorGamesAthletics => _activities[Activity.GielinorGamesAthletics];
        /// <summary> Gets the World Event 2: Armadyl Lifetime Contribution hiscore for this character. </summary>
        public ActivityHiscore ArmadylContribution => _activities[Activity.ArmadylContribution];
        /// <summary> Gets the World Event 2: Bandos Lifetime Contribution hiscore for this character. </summary>
        public ActivityHiscore BandosContribution => _activities[Activity.BandosContribution];
        /// <summary> Gets the World Event 2: Armadyl PVP kills hiscore for this character. </summary>
        public ActivityHiscore ArmadylPVP => _activities[Activity.ArmadylPVP];
        /// <summary> Gets the World Event 2: Bandos PVP kills hiscore for this character. </summary>
        public ActivityHiscore BandosPVP => _activities[Activity.BandosPVP];
        /// <summary> Gets the Heist Guard Level hiscore for this character. </summary>
        public ActivityHiscore HeistGuard => _activities[Activity.HeistGuard];
        /// <summary> Gets the Heist Robber Level hiscore for this character. </summary>
        public ActivityHiscore HeistRobber => _activities[Activity.HeistRobber];
        /// <summary> Gets the Cabbage Facepunch: 5 Game Average hiscore for this character. </summary>
        public ActivityHiscore CabbageFacepunch => _activities[Activity.CababgeFacepunch];
        /// <summary> Gets the April Fools 2015: Cow Tipping hiscore for this character. </summary>
        public ActivityHiscore AprilFoolsCowTipping => _activities[Activity.AprilFoolsCowTipping];
        /// <summary> Gets the April Fools 2015: Rat Kills hiscore for this character. </summary>
        public ActivityHiscore AprilFoolsRatKills => _activities[Activity.AprilFoolsRatKills];

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
        /// <summary> Gets the Divination hiscore for this character. </summary>
        public SkillHiscore Divination => _skills[Skill.Divination];
        /// <summary> Gets the Dungeoneering hiscore for this character. </summary>
        public SkillHiscore Dungeoneering => _skills[Skill.Dungeoneering];
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
        /// <summary> Gets the Invention hiscore for this character. </summary>
        public SkillHiscore Invention => _skills[Skill.Invention];
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
        /// <summary> Gets the Summoning hiscore for this character. </summary>
        public SkillHiscore Summoning => _skills[Skill.Summoning];
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

        internal RS3HiscoreCharacter(RS3RestClient client, CharacterModel model) : base(client)
        {
            Name = model.Name;
            GameMode = model.GameMode;
            Update(model);
        }

        internal static RS3HiscoreCharacter Create(RS3RestClient client, CharacterModel model)
            => new RS3HiscoreCharacter(client, model);

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
