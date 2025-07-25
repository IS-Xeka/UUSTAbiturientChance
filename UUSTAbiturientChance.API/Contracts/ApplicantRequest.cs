﻿namespace UUSTAbiturientChance.API.Contracts;

public record ApplicantRequest(
    string UniqueCode,
    int PCode,
    bool HasNoEntranceTests,
    int TotalCompetitiveScore,
    int TotalEntranceTestsScore,
    int MathScore,
    int InfPhysicsScore,
    int RussianScore,
    int AchievementsScore,
    bool HasFirstPriorityRightArticle,
    bool HasSecondPriorityRightArticle,
    bool HasEnrollmentConsent,
    int Priority
    );
