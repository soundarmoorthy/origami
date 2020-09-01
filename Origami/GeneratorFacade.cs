using System.IO;
using System.Linq;
using Origami.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace Origami
{
    public static class GeneratorFacade
    {
        public static void Generate(Options opt)
        {
            var assesment = GetAssesment(opt.JsonFile);

            var root = new List<object[]>();
            foreach (var db in assesment.Databases)
            {
                Add(assesment, db, root);
            }

            var table = DataTableCreator.Create(root);
            DMAResultsWriter.WriteExcel(table, opt.OutputXlsxFile);

        }

        private static Assesment GetAssesment(string sourceFile)
        {
            var json = File.ReadAllText(sourceFile);
            var assesment = JsonSerializer.Deserialize<Assesment>(json);
            return assesment;
        }

        private static void Add(Assesment assesment, Database db,
            List<object[]> root)
        {
            var recomList = db.AssessmentRecommendations;
            if (!recomList.Any())
            {
                root.Add(new object[] { assesment, db });
                return;
            }

            foreach (var rec in recomList)
            {
                Add(assesment, db, rec, root);
            }
        }

        private static void Add(Assesment assesment,
            Database db, AssessmentRecommendation recom,
            List<object[]> root)
        {
            var impactedObjs = recom.ImpactedObjects;
            if (!impactedObjs.Any())
            {
                root.Add(new object[] { assesment, db, recom });
                return;
            }

            foreach (var impacted in impactedObjs)
            {
                Add(assesment, db, recom, impacted, root);
            }
        }

        private static void Add(Assesment assesment, Database db,
            AssessmentRecommendation recom,
            ImpactedObject impacted, List<object[]> root)
        {
            var list = impacted.SuggestedFixes;
            if (!list.Any())
            {
                root.Add(new object[] { assesment, db, recom, impacted });
                return;
            }

            foreach (var fix in list)
            {
                root.Add(new object[] { assesment, db, recom, impacted, fix });
            }
        }
    }
}
