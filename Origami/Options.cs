using CommandLine;

namespace Origami
{
    public class Options
    {
        //[Option('v', "verbose", Required = false,
        //    HelpText = Consts.VerboseMessage)]
        //public bool Verbose { get; set; }

        [Option('i', "input_json_file", Required = true,
            HelpText = Consts.JsonFileDesc)]
        public string JsonFile { get; set; }

        [Option('o', "output_xlsx_file", Required = true,
            HelpText = Consts.XlsxFileDesc)]
        public string OutputXlsxFile { get; set; }

    }
}