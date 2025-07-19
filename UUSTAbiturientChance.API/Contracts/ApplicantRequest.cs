namespace UUSTAbiturientChance.API.Contracts;

public record ApplicantRequest(
    int PCode,
    string UniqueCode,
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
