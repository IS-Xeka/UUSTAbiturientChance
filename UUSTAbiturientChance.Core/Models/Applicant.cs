using System.ComponentModel.DataAnnotations;

namespace UUSTAbiturientChance.Core.Models;

public class Applicant
{
    public Guid Id { get; set; }

    [Required]
    public int PCode { get; set; }
    public string UniqueCode { get; set; }
    public bool HasNoEntranceTests { get; set; }
    public int TotalCompetitiveScore { get; set; }
    public int TotalEntranceTestsScore { get; set; }
    public int MathAlgebraGeometryScore { get; set; }
    public int InformatcPhysicScore { get; set; }
    public int RussianLanguageScore { get; set; }
    public int IndividualAchievementsScore { get; set; }
    public bool HasFirstPriorityRightArticle { get; set; }
    public bool HasSecondPriorityRightArticle { get; set; }
    public bool HasEnrollmentConsent { get; set; } = false;
    public int Priority { get; set; }

    private readonly List<string> _appliedPrograms  = new();
    public IReadOnlyCollection<string> AppliedPrograms => _appliedPrograms.AsReadOnly();

    public Applicant(
        Guid id,
        int pCode,
        string uniqueCode,
        bool hasNoEntranceTests,
        int totalCompetitiveScore,
        int totalEntranceTestsScore,
        int mathScore,
        int physicsScore,
        int russianScore,
        int achievementsScore,
        bool hasFirstPriorityRightArticle,
        bool hasSecondPriorityRightArticle,
        bool hasEnrollmentConsent,
        int priority)
    {
        Id = id;
        PCode = pCode;
        UniqueCode = uniqueCode;
        HasNoEntranceTests = hasNoEntranceTests;
        TotalCompetitiveScore = totalCompetitiveScore;
        TotalEntranceTestsScore = totalEntranceTestsScore;
        MathAlgebraGeometryScore = mathScore;
        InformatcPhysicScore = physicsScore;
        RussianLanguageScore = russianScore;
        IndividualAchievementsScore = achievementsScore;
        HasFirstPriorityRightArticle = hasFirstPriorityRightArticle;
        HasSecondPriorityRightArticle = hasSecondPriorityRightArticle;
        HasEnrollmentConsent = hasEnrollmentConsent;
        Priority = priority;
    }

    public static Applicant Create(
        Guid id,
        int pCode,
        string uniqueCode,
        bool hasNoEntranceTests,
        int totalCompetitiveScore,
        int totalEntranceTestsScore,
        int mathScore,
        int physicsScore,
        int russianScore,
        int achievementsScore,
        bool hasFirstPriorityRightArticle,
        bool hasSecondPriorityRightArticle,
        bool hasEnrollmentConsent,
        int priority)
    {
        return new Applicant(
            id,
            pCode,
            uniqueCode,
            hasNoEntranceTests,
            totalCompetitiveScore,
            totalEntranceTestsScore,
            mathScore,
            physicsScore,
            russianScore,
            achievementsScore,
            hasFirstPriorityRightArticle,
            hasSecondPriorityRightArticle,
            hasEnrollmentConsent,
            priority);
    }
}
