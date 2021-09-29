using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

using VoicesManagementLibrary;
using CommandLine;

namespace VoiceExporter {
    class Program {

        class Options {
            [Option('o', "output", Required = false, HelpText = "Set the output directory or file.")]
            public string OutputPath { get; set; }
        }
        static void Main(string[] args) {
            string outputPath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "voices_" + (IntPtr.Size == 4 ? "x86" : "x64") + ".json"
            );

            Parser.Default.ParseArguments<Options>(args).WithParsed(o => {
                if(o.OutputPath != null) {
                    outputPath = o.OutputPath;
                    if (Directory.Exists(outputPath) || outputPath.EndsWith("/") || outputPath.EndsWith("\\")) {
                        outputPath = Path.Combine(
                            outputPath,
                            "voices_" + (IntPtr.Size == 4 ? "x86" : "x64") + ".json"
                        );
                    }
                }
            });

            string finalList = VoicesRegistryManagement.SerializeVoices();
            string temp = Path.GetTempFileName();
            File.WriteAllText(temp, finalList);


            Console.WriteLine(outputPath);

            // make output hierarchy
            if (!Directory.Exists(Path.GetDirectoryName(outputPath))) {
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            }
            if (File.Exists(outputPath)) {
                File.Delete(outputPath);
            }
            
            File.Move(temp, outputPath);

        }

    }
}
