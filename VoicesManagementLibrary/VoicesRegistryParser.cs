using Microsoft.Win32;
using Newtonsoft.Json;
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
           
            List<Voice> sapiVoice = ParseRegistry(@"SOFTWARE\Microsoft\Speech\Voices\Tokens");
            // append onecore voices
            foreach (Voice oneCoreVoice in ParseRegistry(@"SOFTWARE\Microsoft\Speech_OneCore\Voices\Tokens")) {
                if (!sapiVoice.Contains(oneCoreVoice)) {
                    sapiVoice.Add(oneCoreVoice);
                }
            }

            return sapiVoice;
        }
        
        /// <summary>
        /// Parse a voices path in registry
        /// </summary>
        /// <param name="HKLMPath"></param>
        /// <returns></returns>
        public static List<Voice> ParseRegistry(string HKLMPath) {
            // Open registry keys
            RegistryKey voiceTokens = Registry.LocalMachine.OpenSubKey(HKLMPath);

            List<Voice> result = new List<Voice>();
            
            if (voiceTokens != null) {
                foreach (string voiceToken in voiceTokens.GetSubKeyNames()) {
                    result.Add(new Voice(voiceTokens.OpenSubKey(voiceToken)));
                }
            }

            return result;
        }

        public static string SerializeRegistry() {
            return JsonConvert.SerializeObject(ParseRegistry());
        }

        public static List<Voice> DeserializeRegistry(string json) {
            return JsonConvert.DeserializeObject<List<Voice>>(json);
        }

        public static void UpdateRegistry(List<Voice> voices, RegistryKey voicesTokensRootKey) {
           
        }


    }
}
