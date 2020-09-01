using CommandLine;

namespace Origami
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(opt =>
                {
                    GeneratorFacade.Generate(opt.JsonFile, opt.OutputXlsxFile);
                });
        }

    }
}
