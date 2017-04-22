using System;
using System.Collections.Generic;

namespace NRuneScape.OldSchool
{
    public interface IOSRSCharacter : ICharacter
    {
        OSRSGameMode AccountType { get; }
        IReadOnlyCollection<OSRSActivityHiScore> Activities { get; }
        OSRSActivityHiScore BountyHunterHunter { get; }
        OSRSActivityHiScore BountyHunterRogue { get; }
        OSRSActivityHiScore ClueScrollsAll { get; }
        OSRSActivityHiScore ClueScrollsEasy { get; }
        OSRSActivityHiScore ClueScrollsElite { get; }
        OSRSActivityHiScore ClueScrollsHard { get; }
        OSRSActivityHiScore ClueScrollsMaster { get; }
        OSRSActivityHiScore ClueScrollsMedium { get; }
        OSRSActivityHiScore LastManStandingRank { get; }
        IReadOnlyCollection<OSRSSkillHiScore> Skills { get; }

        OSRSActivityHiScore GetActivityHiScore(OSRSActivity activity);

        OSRSSkillHiScore GetSkillHiScore(OSRSSkill skill);
    }
}