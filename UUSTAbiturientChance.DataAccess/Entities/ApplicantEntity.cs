namespace UUSTAbiturientChance.Application.Srvices.Entities;

public class ApplicantEntity
{
    public Guid Id { get; set; }
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
    public ICollection<string> AppliedPrograms = new List<string>();
}
