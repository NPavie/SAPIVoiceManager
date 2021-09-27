using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoicesManagementLibrary {
    public static class VoicesRegistryParser {

        /// <summary>
        /// Parse the current SAPI and SAPI OneCore registries to get 
        /// the full list of accessible voices for the system on the
        /// current architecture used to launch the software.
        /// </summary>
        /// <returns></returns>
        public static List<Voice> ParseRegistry() {
            // Open registry keys
            RegistryKey SAPIOneCoreTokens = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Speech_OneCore\Voices\Tokens");
            RegistryKey SAPITokens = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Speech\Voices\Tokens");

            List<Voice> fullList = new List<Voice>();
            if (SAPIOneCoreTokens != null) {
                foreach (string voiceToken in SAPIOneCoreTokens.GetSubKeyNames()) {
                    fullList.Add(new Voice(SAPIOneCoreTokens.OpenSubKey(voiceToken)));
                }
            }
            if (SAPITokens != null) {
                foreach (string voiceToken in SAPITokens.GetSubKeyNames()) {
                    fullList.Add(new Voice(SAPITokens.OpenSubKey(voiceToken)));
                }
            }

            List<Voice> filtered = new List<Voice>();
            // filter voice list to delete voices copies
            foreach (Voice item in fullList) {
                if (!filtered.Contains(item)) {
                    filtered.Add(item);
                }
            }

            return filtered;
        }

        public static void ExportToJSON(List<Voice> voices, string jsonPath, bool replaceFile = false) {
            // if json file already exists and replaceFile is false,
            // - retrieve the previous list,
            // - update the list
            // - do the export

            string finalList = "";


            string temp = Path.GetTempFileName();
            File.WriteAllText(temp, finalList);
            File.Move(temp, jsonPath);
        }

        /// <summary>
        /// Parse an export
        /// </summary>
        /// <param name="jsonPath"></param>
        /// <param name="previousList"></param>
        /// <returns></returns>
        public static List<Voice> ParseExportFile(string jsonPath, List<Voice> previousList = null) {
            List<Voice> result = previousList != null ? previousList  : new List<Voice>();

            return result;
        }

        public static void UpdateRegistry(List<Voice> voices, RegistryKey voicesTokensRootKey) {
           
        }


    }
}
