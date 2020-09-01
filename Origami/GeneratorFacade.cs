using System.IO;
using System.Linq;
using Origami.Models;
using System.Text.Json;
using System.Collections.Generic;
using System.Data;

namespace Origami
{
    public static class GeneratorFacade
    {
        /// <summary>
        /// This method is intentionally using file stream operations and 
        /// doesn't pass any filestream or paths to the Generate method it
        /// calls.
        /// </summary>
        /// <param name="opt"></param>
        public static void Generate(Options opt)
        {
            var assesment = GetAssesment(opt.JsonFile);
            var table = Generate(assesment);
            DMAResultsWriter.WriteExcel(table, opt.OutputXlsxFile);

        }

        /// <summary>
        /// This method is intentionally writtent to facilitate testing. 
        /// </summary>
        /// <param name="assesment"></param>
        /// <returns></returns>
        public static DataTable Generate(Assesment assesment)
        {
            if (assesment.Databases == null)
                throw new InvalidDataException("No databases to evaluate");

            var root = new List<object[]>();
            foreach (var db in assesment.Databases)
            {
                Add(assesment, db, root);
            }

            var table = DataTableCreator.Create(root);
            return table;
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
