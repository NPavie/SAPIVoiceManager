using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;
using Newtonsoft.Json;

namespace VoicesManagementLibrary {
    /// <summary>
    /// Reflect a SAPI voice in the windows registry
    /// </summary>
    public class Voice : IEquatable<Voice> {

        /// <summary>
        /// Raw view of the voice record in registry
        /// Used for saving the voice
        /// </summary>
        public RegistryFolder RegistryRawData { get; set; }

        public string RegistryPath { get; }

        public List<RegistryFolder> UnidentifiedSubKeys;

        public List<RegistryValue<string>> UnidentifiedValues;

        private RegistryValue<string> _Name;
        public string Name {
            get => _Name?.Value;
            // voice name is the default value of the key
            set => _Name = new RegistryValue<string>(RegistryValueKind.String, value);
        }

        private RegistryValue<string> _LCID;
        public int LCID {
            get => int.Parse(_LCID.Name, System.Globalization.NumberStyles.HexNumber);
            set => _LCID = new RegistryValue<string>(RegistryValueKind.String, this.Name, Convert.ToString(value, 16));
        }

        private RegistryValue<string> _CLSID;
        public string CLSID {
            get => _CLSID?.Value;
            set => _CLSID = new RegistryValue<string>(RegistryValueKind.String, value, "CLSID");
            
        }

        private RegistryValue<string> _LangDataPath;
        public string LangDataPath {
            get => _LangDataPath?.Value;
            set => _LangDataPath = new RegistryValue<string>(RegistryValueKind.String, value, "LangDataPath");
        }

        private RegistryValue<string> _VoicePath;
        public string VoicePath {
            get => _VoicePath?.Value;
            set => _VoicePath = new RegistryValue<string>(RegistryValueKind.String, value, "VoicePath");
        }



        public class VoiceAttributes {

            private RegistryValue<string> _Age;
            public string Age {
                get => _Age?.Value;
                set => _Age = new RegistryValue<string>(RegistryValueKind.String, value, "Age");
            }

            private RegistryValue<string> _Gender;
            public string Gender {
                get => _Gender?.Value;
                set => _Gender = new RegistryValue<string>(RegistryValueKind.String, value, "Gender");
            }

            private RegistryValue<string> _Language;
            public string Language {
                get => _Language?.Value;
                set => _Language = new RegistryValue<string>(RegistryValueKind.String, value, "Language");
            }

            private RegistryValue<string> _Name;
            public string Name {
                get => _Name?.Value;
                set => _Name = new RegistryValue<string>(RegistryValueKind.String, value, "Name");
            }

            private RegistryValue<string> _SharedPronunciation;
            public string SharedPronunciation {
                get => _SharedPronunciation?.Value;
                set => _SharedPronunciation = new RegistryValue<string>(RegistryValueKind.String, value, "SharedPronunciation");
            }

            private RegistryValue<string> _SpLexicon;
            public string SpLexicon {
                get => _SpLexicon?.Value;
                set => _SpLexicon = new RegistryValue<string>(RegistryValueKind.String, value, "SpLexicon");
            }

            private RegistryValue<string> _Vendor;
            public string Vendor {
                get => _Vendor?.Value;
                set => _Vendor = new RegistryValue<string>(RegistryValueKind.String, value, "Vendor");
            }

            private RegistryValue<string> _Version;
            public string Version {
                get => _Version?.Value;
                set => _Version = new RegistryValue<string>(RegistryValueKind.String, value, "Version");
            }

            private RegistryValue<string> _DataVersion;
            public string DataVersion {
                get => _DataVersion?.Value;
                set => _DataVersion = new RegistryValue<string>(RegistryValueKind.String, value, "DataVersion");
            }

            private RegistryValue<string> _SayAsSupport;
            public string SayAsSupport {
                get => _SayAsSupport?.Value;
                set => _SayAsSupport = new RegistryValue<string>(RegistryValueKind.String, value, "SayAsSupport");
            }


            public string RegistryPath { get; set; }

            public List<string> UnidentifiedSubKeys;

            public List<RegistryValue<object>> UnidentifiedValues;

            public VoiceAttributes () {}

            public VoiceAttributes(RegistryKey attributesKey) {
                
                if (attributesKey == null) throw new Exception("Attributes key was not found");
                this.RegistryPath = attributesKey.Name;
                string[] values = attributesKey.GetValueNames();

                foreach (string ValueName in values) {
                    switch (ValueName.ToLower()) {
                        case "age": this.Age = (string)attributesKey.GetValue(ValueName); break;
                        case "gender": this.Gender = (string)attributesKey.GetValue(ValueName); break;
                        case "language": this.Language = (string)attributesKey.GetValue(ValueName); break;
                        case "name": this.Name = (string)attributesKey.GetValue(ValueName); break;
                        case "sharedpronunciation": this.SharedPronunciation = (string)attributesKey.GetValue(ValueName); break;
                        case "splexicon": this.SpLexicon = (string)attributesKey.GetValue(ValueName); break;
                        case "vendor": this.Vendor = (string)attributesKey.GetValue(ValueName); break;
                        case "version": this.Version = (string)attributesKey.GetValue(ValueName); break;
                        case "dataversion": this.DataVersion = (string)attributesKey.GetValue(ValueName); break;
                        case "sayassupport": this.SayAsSupport = (string)attributesKey.GetValue(ValueName); break;
                        default:
                            // just store the value in unidentified list
                            if (UnidentifiedValues == null) UnidentifiedValues = new List<RegistryValue<object>>();
                            UnidentifiedValues.Add(
                                new RegistryValue<object>(
                                    attributesKey.GetValueKind(ValueName),
                                    attributesKey.GetValue(ValueName),
                                    ValueName
                                )
                            );
                            break;
                    }
                }
                UnidentifiedSubKeys = attributesKey.GetSubKeyNames().ToList();

            }

            public string Serialize() {
                return JsonConvert.SerializeObject(this);
            }

            public override string ToString() {
                return " - Name:" + this.Name?.ToString() + "\r\n" +
                    " - Age:" + this.Age?.ToString() + "\r\n" +
                    " - Gender:" + this.Gender?.ToString() + "\r\n" +
                    " - Language:" + this.Language?.ToString() + "\r\n" +
                    " - SharedPronunciation:" + this.SharedPronunciation?.ToString() + "\r\n" +
                    " - SpLexicon:" + this.SpLexicon?.ToString() + "\r\n" +
                    " - Vendor:" + this.Vendor?.ToString() + "\r\n" +
                    " - Version:" + this.Version?.ToString() + "\r\n" +
                    " - DataVersion:" + this.DataVersion?.ToString() + "\r\n" +
                    " - SayAsSupport:" + this.SayAsSupport?.ToString();
            }
            
        }

        public VoiceAttributes Attributes { get; set; }

        public Voice() { }

        public Voice(RegistryKey voiceTokenKey) {
            
            if (voiceTokenKey == null) throw new Exception("Undefined voice token in the registry");
            RegistryRawData = new RegistryFolder(voiceTokenKey);
            string[] values = voiceTokenKey.GetValueNames();

            foreach (string ValueName in values) {
                switch (ValueName.ToLower()) { // Use lowercase comparison as some third party does not follow usual case
                    // Default key value is the voice name
                    case "": this.Name = (string)voiceTokenKey.GetValue(ValueName); break;
                    case "clsid": this.CLSID = (string)voiceTokenKey.GetValue(ValueName); break;
                    case "langdatapath": this.LangDataPath = (string)voiceTokenKey.GetValue(ValueName); break;
                    case "voicepath": this.VoicePath = (string)voiceTokenKey.GetValue(ValueName); break;
                    default:
                        // special key : the language code is stored
                        // using hexa code as key name, and voice name as key value 
                        try {
                            this.LCID = int.Parse(ValueName, System.Globalization.NumberStyles.HexNumber);
                        } catch (Exception) {
                            // Not the LCID or an identified key, just store the value in unidentified list
                            if (UnidentifiedValues == null) UnidentifiedValues = new List<RegistryValue<string>>();
                            UnidentifiedValues.Add(
                                new RegistryValue<string>(
                                    voiceTokenKey.GetValueKind(ValueName),
                                    voiceTokenKey.GetValue(ValueName).ToString(),
                                    ValueName
                                )
                            );
                        }

                        break;
                }
            }
            string[] subkeys = voiceTokenKey.GetSubKeyNames();
            if (subkeys.Length > 0) {
                foreach (string subKeyName in subkeys) {
                    if (subKeyName.ToLower() == "attributes") {  // Use lowercase comparison as some third party does not follow usual case
                        this.Attributes = new VoiceAttributes(voiceTokenKey.OpenSubKey(subKeyName));
                    } else {
                        if (UnidentifiedSubKeys == null) UnidentifiedSubKeys = new List<RegistryFolder>();
                        UnidentifiedSubKeys.Add(new RegistryFolder(voiceTokenKey.OpenSubKey(subKeyName)));
                    }
                }
            }
        }

        public bool Equals(Voice other) {
            if (other == null) return false;
            return this.Name.Equals(other.Name);
        }

        public string Serialize() {
            return JsonConvert.SerializeObject(this);
        }

        public override string ToString() {
            return this.Name + "\r\n" +
                "Registry path: " + this.RegistryPath?.ToString() + "\r\n" +
                "LCID (language): " + this.LCID.ToString() + " (" + CultureInfo.GetCultureInfo(this.LCID).DisplayName + ")\r\n" +
                "CLSID: " + this.CLSID?.ToString() + "\r\n" +
                "LangDataPath: " + this.LangDataPath?.ToString() + "\r\n" +
                "VoicePath: " + this.VoicePath?.ToString() + "\r\n" +
                "Attributes:" + "\r\n" + this.Attributes.ToString();
        }

        public void SaveUnder(RegistryKey voicesTokensKey) {
            this.RegistryRawData.InsertUnderRegistryKey(voicesTokensKey);
        }

    }
}
