using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoicesManagementLibrary {
    public static class VoicesRegistryManagement {

        public class VoiceTokensRoot {
            public string Path { get; private set; } 
            private VoiceTokensRoot(string path) {
                this.Path = path;
            }
             public static VoiceTokensRoot SAPI { get => new VoiceTokensRoot(@"SOFTWARE\Microsoft\Speech\Voices\Tokens"); }

            public static VoiceTokensRoot SAPIOneCore { get => new VoiceTokensRoot(@"SOFTWARE\Microsoft\Speech_OneCore\Voices\Tokens"); }

        }

        ///
        /// <summary>
        /// Parse voices tokens registry key (vtr) to get a list voices registered in it. 
        /// If no key is proved,  the full list of accessible voices (SAPI and SAPI OneCore)
        /// is retrieved for the system on the current architecture used to launch the software.
        /// </summary>
        /// <param name="vtr">VoicesTokensRoot.SAPI, VoicesTokensRoot.SAPIOneCore, or null for both</param>
        /// <returns></returns>
        public static List<Voice> ParseVoices(VoiceTokensRoot vtr = null) {
            List<Voice> result = new List<Voice>();
            if (vtr != null) {
                // Open registry keys
                RegistryKey voiceTokens = Registry.LocalMachine.OpenSubKey(vtr.Path);
                
                if (voiceTokens != null) {
                    foreach (string voiceToken in voiceTokens.GetSubKeyNames()) {
                        result.Add(new Voice(voiceTokens.OpenSubKey(voiceToken)));
                    }
                }
                voiceTokens.Close();
            } else {
                result = ParseVoices(VoiceTokensRoot.SAPI);
                // append onecore voices
                foreach (Voice oneCoreVoice in ParseVoices(VoiceTokensRoot.SAPIOneCore)) {
                    if (!result.Contains(oneCoreVoice)) {
                        result.Add(oneCoreVoice);
                    }
                }
            }
            return result;

        }

        /// <summary>
        /// Parse a voices path in registry
        /// </summary>
        /// <param name="HKLMPath"> string format path</param>
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

            voiceTokens.Close();
            return result;
        }

        

        public static string SerializeVoices(VoiceTokensRoot vtr = null) {
            return JsonConvert.SerializeObject(ParseVoices(vtr));
        }

        public static List<Voice> DeserializeVoices(string json) {
            return JsonConvert.DeserializeObject<List<Voice>>(json);
        }

        public static List<Voice> SaveToRegistry(List<Voice> voices, VoiceTokensRoot vtr) {
            RegistryKey voiceTokens = Registry.LocalMachine.OpenSubKey(vtr.Path, true);
            List<Voice> currentlyInstalled = new List<Voice>();
            if (voiceTokens != null) {
                foreach (string voiceToken in voiceTokens.GetSubKeyNames()) {
                    currentlyInstalled.Add(new Voice(voiceTokens.OpenSubKey(voiceToken)));
                }
            }

            foreach (Voice toInstall in voices) {
                if (!currentlyInstalled.Contains(toInstall)) {
                    // install new voice
                    toInstall.SaveUnder(voiceTokens);
                    currentlyInstalled.Add(toInstall);
                }
            }
            voiceTokens.Close();
            return currentlyInstalled;
        }
    }
}
