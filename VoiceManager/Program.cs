using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

using VoicesManagementLibrary;

namespace VoiceImporter {
    static class Program {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Launch both voice exporter to retrieve voice list
            string x86exporter = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Exporters",
                "x86",
                "VoiceExporter.exe"
            );
            string x64exporter = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "Exporters",
                "x64",
                "VoiceExporter.exe"
            );

            string defaultOutputExportx86 = Path.Combine
                (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "_exports",
                "export" + System.DateTime.Now.ToBinary().ToString()+ "_x86.json"
                );

            string defaultOutputExportx64 = Path.Combine
                (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "_exports",
                "export"+System.DateTime.Now.ToBinary().ToString() + "_x64.json"
                );

            string backup = Path.Combine
                (Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "_backups",
                "backup_" + System.DateTime.Now.ToBinary().ToString() + "_" + (IntPtr.Size == 4 ? "x86" : "x64") + ".json"
                );


            if (!Directory.Exists(Path.GetDirectoryName(defaultOutputExportx64))) {
                Directory.CreateDirectory(Path.GetDirectoryName(defaultOutputExportx64));
            }
            if (!Directory.Exists(Path.GetDirectoryName(backup))) {
                Directory.CreateDirectory(Path.GetDirectoryName(backup));
            }
            string debug = "";
            string error = "";

            Process exportingx86 = new Process();
            exportingx86.StartInfo.FileName = x86exporter;
            exportingx86.StartInfo.Arguments = "-o " + defaultOutputExportx86;
            exportingx86.StartInfo.CreateNoWindow = true;
            exportingx86.StartInfo.UseShellExecute = false;
            exportingx86.StartInfo.RedirectStandardOutput = true;
            exportingx86.StartInfo.RedirectStandardError = true;
            exportingx86.OutputDataReceived += (sender, args) => {
                debug += args.Data;
            };
            exportingx86.ErrorDataReceived += (sender, args) => {
                error += args.Data;
            };

            if (exportingx86.Start()) {
                exportingx86.BeginOutputReadLine();
                exportingx86.BeginErrorReadLine();
                exportingx86.WaitForExit();
            }

            Process exportingx64 = new Process();
            exportingx64.StartInfo.FileName = x64exporter;
            exportingx64.StartInfo.Arguments = "-o " + defaultOutputExportx64;
            exportingx64.StartInfo.CreateNoWindow = true;
            exportingx64.StartInfo.UseShellExecute = false;
            exportingx64.StartInfo.RedirectStandardOutput = true;
            exportingx64.StartInfo.RedirectStandardError = true;
            exportingx64.OutputDataReceived += (sender, args) => {
                debug += args.Data;
            };
            exportingx64.ErrorDataReceived += (sender, args) => {
                error += args.Data;
            };
            if (exportingx64.Start()) {
                exportingx64.BeginOutputReadLine();
                exportingx64.BeginErrorReadLine();
                exportingx64.WaitForExit();
            }

            // current voice list installed on the SAPI default registry
            List<Voice> installed = VoicesRegistryManagement.ParseVoices(VoicesRegistryManagement.VoiceTokensRoot.SAPI);
            File.WriteAllText(backup, VoicesRegistryManagement.SerializeVoices(VoicesRegistryManagement.VoiceTokensRoot.SAPI));
            // exporter results
            List<Voice> available = VoicesRegistryManagement.DeserializeVoices(File.ReadAllText(defaultOutputExportx86));
            foreach (Voice item in VoicesRegistryManagement.DeserializeVoices(File.ReadAllText(defaultOutputExportx64))) {
                if (!available.Contains(item)) {
                    available.Add(item);
                }
            }

            Application.Run(new VoicesManagerForm(installed, available));
        }
    }
}
