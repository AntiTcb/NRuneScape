using System;

namespace NRuneScape.OldSchool
{
    public static class HiScoreExtensions
    {
        public static OSRSActivity GetActivityByIndex(this int index)
        {
            switch (index)
            {
                case 24: return OSRSActivity.ClueScrollsEasy;
                case 25: return OSRSActivity.ClueScrollsMedium;
                case 26: return OSRSActivity.ClueScrollsAll;
                case 27: return OSRSActivity.BountyHunterRogue;
                case 28: return OSRSActivity.BountyHunterHunter;
                case 29: return OSRSActivity.ClueScrollsHard;
                case 30: return OSRSActivity.LastManStandingRank;
                case 31: return OSRSActivity.ClueScrollsElite;
                case 32: return OSRSActivity.ClueScrollsMaster;
                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public static string GetFullActivityName(this OSRSActivity activity)
        {
            switch (activity)
            {
                case OSRSActivity.ClueScrollsEasy: return "Clue Scrolls (Easy)";
                case OSRSActivity.ClueScrollsMedium: return "Clue Scrolls (Medium)";
                case OSRSActivity.ClueScrollsHard: return "Clue Scrolls (Hard)";
                case OSRSActivity.ClueScrollsElite: return "Clue Scrolls (Elite)";
                case OSRSActivity.ClueScrollsMaster: return "Clue Scrolls (Master)";
                case OSRSActivity.ClueScrollsAll: return "Clue Scrolls (All)";
                case OSRSActivity.BountyHunterRogue: return "Bounty Hunter - Rogue";
                case OSRSActivity.BountyHunterHunter: return "Bounty Hunter - Hunter";
                case OSRSActivity.LastManStandingRank: return "LMS - Rank";
                default: throw new ArgumentOutOfRangeException(nameof(activity));
            }
        }

        public static OSRSSkill GetSkillByIndex(this int index)
        {
            switch (index)
            {
                case 0: return OSRSSkill.Overall;
                case 1: return OSRSSkill.Attack;
                case 2: return OSRSSkill.Defence;
                case 3: return OSRSSkill.Strength;
                case 4: return OSRSSkill.Hitpoints;
                case 5: return OSRSSkill.Ranged;
                case 6: return OSRSSkill.Prayer;
                case 7: return OSRSSkill.Magic;
                case 8: return OSRSSkill.Cooking;
                case 9: return OSRSSkill.Woodcutting;
                case 10: return OSRSSkill.Fletching;
                case 11: return OSRSSkill.Fishing;
                case 12: return OSRSSkill.Firemaking;
                case 13: return OSRSSkill.Crafting;
                case 14: return OSRSSkill.Smithing;
                case 15: return OSRSSkill.Mining;
                case 16: return OSRSSkill.Herblore;
                case 17: return OSRSSkill.Agility;
                case 18: return OSRSSkill.Thieving;
                case 19: return OSRSSkill.Slayer;
                case 20: return OSRSSkill.Farming;
                case 21: return OSRSSkill.Runecraft;
                case 22: return OSRSSkill.Hunter;
                case 23: return OSRSSkill.Construction;
                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
    }
}