using System;
using System.IO;
using System.Text.Json;

namespace Origami
{
    class Program
    {
        static string jsonFile =
            "/Users/sdhaksh5/Desktop/cmr_dbs_export_managed_instance.json";
        static void Main(string[] args)
        {
            var json = File.OpenRead(jsonFile);
            var document = JsonDocument.Parse(json);


        }
    }
}
