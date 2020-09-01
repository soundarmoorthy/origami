using System.Collections.Generic;

namespace Origami.Models
{
    [Order(6)]
    public class SuggestedFix
    {
        public string OrginalStatement { get; set; }
        public string CorrectedStatement { get; set; }
    }


    [Order(5)]
    public class ImpactedObject
    {
        public string Name { get; set; }
        public string ObjectType { get; set; }
        public string ImpactDetail { get; set; }
        public IList<SuggestedFix> SuggestedFixes { get; set; }
    }


    [Order(4)]
    public class AssessmentRecommendation
    {
        public string CompatibilityLevel { get; set; }
        public string Category { get; set; }
        public string Severity { get; set; }
        public string ChangeCategory { get; set; }
        public string FeatureParityCategory { get; set; }
        public string RuleId { get; set; }
        public string Title { get; set; }
        public string Impact { get; set; }
        public string Recommendation { get; set; }
        public string MoreInfo { get; set; }
        public IList<ImpactedObject> ImpactedObjects { get; set; }
    }

    [Order(2)]
    public class Database
    {
        public string Status { get; set; }
        public IList<AssessmentRecommendation> AssessmentRecommendations { get; set; }
        public string Name { get; set; }
        public double SizeMB { get; set; }
        public string ServerVersion { get; set; }
        public string ServerEdition { get; set; }
        public string CompatibilityLevel { get; set; }
        public string ServerName { get; set; }
    }


    [Order(3)]
    public class ServerInstance
    {
        public string ServerName { get; set; }
        public string Version { get; set; }
        public string Status { get; set; }
        public IList<AssessmentRecommendation> AssessmentRecommendations { get; set; }
    }


    [Order(7)]
    public class DmaVersion
    {
        string Version { get; set; }
    }


    [Order(1)]
    public class Assesment
    {
        public string Name { get; set; }
        public IList<Database> Databases { get; set; }
        public IList<ServerInstance> ServerInstances { get; set; }
        public string SourcePlatform { get; set; }
        public string Status { get; set; }
        public string TargetPlatform { get; set; }
        public DmaVersion DmaVersion { get; set; }
    }
}
