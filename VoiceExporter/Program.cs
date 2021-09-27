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

namespace VoiceExporter {
    class Program {
        static void Main(string[] args) {

            List<Voice> tempListVoice = VoicesRegistryParser.ParseRegistry();

            // Get all voices from current registry and export reg keys content
            // Voices are stored in two registy entry :
            // - HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices\Tokens
            // - HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech\Voices\Tokens
            RegistryKey SAPIOneCoreTokens = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Speech_OneCore\Voices\Tokens");
            string oneCoreVoices = SAPIOneCoreTokens != null ? serializeKey(SAPIOneCoreTokens) : null;
            RegistryKey SAPITokens = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Speech\Voices\Tokens");
            string speechVoices = SAPITokens != null ? serializeKey(SAPITokens) : null;

            // export results to json files voices-arch.json and voices_OneCore-arch.json
            // 
            string finalList = "{\"voicesRoot\":[" +
                (oneCoreVoices != null ? oneCoreVoices : "") +
                (oneCoreVoices != null && speechVoices != null ? "," : "") +
                (speechVoices != null ? speechVoices : "") +
                "]}";
            string temp = Path.GetTempFileName();
            File.WriteAllText(temp, finalList);

            string outputPath = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "voices_" + (IntPtr.Size == 4 ? "x86" : "x64") + ".json"
            );
            File.Move(temp, outputPath);

        }

        static string serializeKey(RegistryKey key) {
            string result = "{";
            result += "\"name\":\"" + key.Name.Replace("\\", "\\\\") + "\"";
            string[] values = key.GetValueNames();
            if(values.Length > 0) {
                result += ",\"values\":[";
                bool notFirst = false;
                foreach (string ValueName in values) {
                    result += (notFirst ? "," : "") + "{";
                    result += "\"name\":\"" + ValueName.Replace("\\", "\\\\") + "\"";
                    result += ",\"type\":\"" + key.GetValueKind(ValueName).ToString() + "\"";
                    result += ",\"value\":\"" + key.GetValue(ValueName).ToString().Replace("\\", "\\\\") + "\"";
                    result += "}";
                    notFirst = true;
                }
                result += "]";
            }
            string[] subkeys = key.GetSubKeyNames();
            if(subkeys.Length > 0) {
                result += ",\"subkeys\":[";
                bool notFirst = false;
                foreach (string subKeyName in subkeys) {
                    result += (notFirst ? "," : "") + serializeKey(key.OpenSubKey(subKeyName));
                    notFirst = true;
                }
                result += "]";
            }
            result += "}";
            return result;
        }

    }
}
