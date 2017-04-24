using System;

namespace NRuneScape.OldSchool
{
    public static class HiScoreExtensions
    {
        public static OSActivity ToOSRSActivity(this int index)
        {
            switch (index)
            {
                case 24: return OSActivity.ClueScrollsEasy;
                case 25: return OSActivity.ClueScrollsMedium;
                case 26: return OSActivity.ClueScrollsAll;
                case 27: return OSActivity.BountyHunterRogue;
                case 28: return OSActivity.BountyHunterHunter;
                case 29: return OSActivity.ClueScrollsHard;
                case 30: return OSActivity.LastManStandingRank;
                case 31: return OSActivity.ClueScrollsElite;
                case 32: return OSActivity.ClueScrollsMaster;
                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

        public static string ToActivityName(this OSActivity activity)
        {
            switch (activity)
            {
                case OSActivity.ClueScrollsEasy: return "Clue Scrolls (Easy)";
                case OSActivity.ClueScrollsMedium: return "Clue Scrolls (Medium)";
                case OSActivity.ClueScrollsHard: return "Clue Scrolls (Hard)";
                case OSActivity.ClueScrollsElite: return "Clue Scrolls (Elite)";
                case OSActivity.ClueScrollsMaster: return "Clue Scrolls (Master)";
                case OSActivity.ClueScrollsAll: return "Clue Scrolls (All)";
                case OSActivity.BountyHunterRogue: return "Bounty Hunter - Rogue";
                case OSActivity.BountyHunterHunter: return "Bounty Hunter - Hunter";
                case OSActivity.LastManStandingRank: return "LMS - Rank";
                default: throw new ArgumentOutOfRangeException(nameof(activity));
            }
        }

        public static OSSkill ToOSRSSkill(this int index)
        {
            switch (index)
            {
                case 0: return OSSkill.Overall;
                case 1: return OSSkill.Attack;
                case 2: return OSSkill.Defence;
                case 3: return OSSkill.Strength;
                case 4: return OSSkill.Hitpoints;
                case 5: return OSSkill.Ranged;
                case 6: return OSSkill.Prayer;
                case 7: return OSSkill.Magic;
                case 8: return OSSkill.Cooking;
                case 9: return OSSkill.Woodcutting;
                case 10: return OSSkill.Fletching;
                case 11: return OSSkill.Fishing;
                case 12: return OSSkill.Firemaking;
                case 13: return OSSkill.Crafting;
                case 14: return OSSkill.Smithing;
                case 15: return OSSkill.Mining;
                case 16: return OSSkill.Herblore;
                case 17: return OSSkill.Agility;
                case 18: return OSSkill.Thieving;
                case 19: return OSSkill.Slayer;
                case 20: return OSSkill.Farming;
                case 21: return OSSkill.Runecraft;
                case 22: return OSSkill.Hunter;
                case 23: return OSSkill.Construction;
                default: throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
    }
}