using CSharpFunctionalExtensions;
using System.ComponentModel.DataAnnotations;

namespace UUSTAbiturientChance.Core.Models;

public class Applicant
{
    [Key]
    public string UniqueCode { get; set; }

    [Required]
    public int PCode { get; set; }
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
        string uniqueCode,
        int pCode,
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
        UniqueCode = uniqueCode;
        PCode = pCode;
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

    public static Result<Applicant> Create(
        string uniqueCode,
        int pCode,
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
        return Result.Success(new Applicant(
            uniqueCode,
            pCode,
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
            priority));
    }
}
