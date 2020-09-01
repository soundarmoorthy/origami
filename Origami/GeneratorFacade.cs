using System.IO;
using System.Linq;
using Origami.Models;
using System.Text.Json;
using System.Collections.Generic;

namespace Origami
{
    public static class GeneratorFacade
    {
        public static void Generate(string sourceFile, string destFile)
        {
            var obj = assesment(sourceFile);

            var root = new List<object[]>();
            foreach (var db in obj.Databases)
            {
                Add(db, root);
            }

        }

        private static Assesment assesment(string sourceFile)
        {
            var json = File.ReadAllText(sourceFile);
            var assesment = JsonSerializer.Deserialize<Assesment>(json);
            return assesment;
        }

        private static void Add(Database db,
            List<object[]> root)
        {
            var list = db.AssessmentRecommendations;
            if (!list.Any())
            {
                root.Add(new object[] { db });
                return;
            }

            foreach (var l in list)
            {
                Add(db, l, root);
            }
        }

        private static void Add(Database db, AssessmentRecommendation l,
            List<object[]> root)
        {
            var list = l.ImpactedObjects;
            if (!list.Any())
            {
                root.Add(new object[] { db, l });
                return;
            }

            foreach (var obj in list)
            {
                Add(db, l, obj, root);
            }
        }

        private static void Add(Database db, AssessmentRecommendation l,
            ImpactedObject obj, List<object[]> root)
        {
            var list = obj.SuggestedFixes;
            if (!list.Any())
            {
                root.Add(new object[] { db, l, obj });
                return;
            }

            foreach (var fix in list)
            {
                root.Add(new object[] { db, l, obj, fix });
            }
        }

    }
}
