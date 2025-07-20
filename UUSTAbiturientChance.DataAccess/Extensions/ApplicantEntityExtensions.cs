using UUSTAbiturientChance.Application.Srvices.Entities;
using UUSTAbiturientChance.Core.Models;

namespace UUSTAbiturientChance.DataAccess.Extensions;

public static class ApplicantEntityExtensions
{
    public static Applicant ToDomain(this ApplicantEntity applicantEntity)
    {
        return Applicant.Create(
            applicantEntity.UniqueCode,
            applicantEntity.PCode,
            applicantEntity.HasNoEntranceTests,
            applicantEntity.TotalCompetitiveScore,
            applicantEntity.TotalEntranceTestsScore,
            applicantEntity.MathAlgebraGeometryScore,
            applicantEntity.InformatcPhysicScore,
            applicantEntity.RussianLanguageScore,
            applicantEntity.IndividualAchievementsScore,
            applicantEntity.HasFirstPriorityRightArticle,
            applicantEntity.HasSecondPriorityRightArticle,
            applicantEntity.HasEnrollmentConsent,
            applicantEntity.Priority
            ).Value;
    }
}
