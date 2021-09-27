using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;

namespace VoicesManagementLibrary {
    /// <summary>
    /// Reflect a SAPI voice in the windows registry
    /// </summary>
    public class Voice : IEquatable<Voice> {
        public RegistryKey OriginalToken { get; }

        public List<string> UnidentifiedSubKeys;
        public List<RegistryValue<string>> UnidentifiedValues;

        private RegistryValue<string> _Name;
        public string Name {
            get {
                return _Name != null ? _Name.Value : null;
            }
            set {
                // voice name is the default value of the key
                _Name = new RegistryValue<string>(RegistryValueKind.String, value);
            }
        }

        private RegistryValue<string> _LCID;
        public int LCID {
            get {
                return int.Parse(_LCID.Name, System.Globalization.NumberStyles.HexNumber);
            }
            set {
                _LCID = new RegistryValue<string>(RegistryValueKind.String, this.Name, Convert.ToString(value, 16));
            }
        }

        private RegistryValue<string> _CLSID;
        public string CLSID {
            get {
                return _CLSID != null ? _CLSID.Value : null;
            }
            set {
                _CLSID = new RegistryValue<string>(RegistryValueKind.String, value, "CLSID");
            }
        }

        private RegistryValue<string> _LangDataPath;
        public string LangDataPath {
            get {
                return _LangDataPath != null ? _LangDataPath.Value : null;
            }
            set {
                _LangDataPath = new RegistryValue<string>(RegistryValueKind.String, value, "LangDataPath");
            }
        }

        private RegistryValue<string> _VoicePath;
        public string VoicePath {
            get {
                return _VoicePath != null ? _VoicePath.Value : null;
            }
            set {
                _VoicePath = new RegistryValue<string>(RegistryValueKind.String, value, "VoicePath");
            }
        }



        public class VoiceAttributes {

            private RegistryValue<string> _Age;
            public string Age {
                get {
                    return _Age != null ? _Age.Value : null;
                }
                set {
                    _Age = new RegistryValue<string>(RegistryValueKind.String, value, "Age");
                }
            }

            private RegistryValue<string> _Gender;
            public string Gender {
                get {
                    return _Gender != null ? _Gender.Value : null;
                }
                set {
                    _Gender = new RegistryValue<string>(RegistryValueKind.String, value, "Gender");
                }
            }

            private RegistryValue<string> _Language;
            public string Language {
                get {
                    return _Language != null ? _Language.Value : null;
                }
                set {
                    _Language = new RegistryValue<string>(RegistryValueKind.String, value, "Language");
                }
            }

            private RegistryValue<string> _Name;
            public string Name {
                get {
                    return _Name != null ? _Name.Value : null;
                }
                set {
                    _Name = new RegistryValue<string>(RegistryValueKind.String, value, "Name");
                }
            }

            private RegistryValue<string> _SharedPronunciation;
            public string SharedPronunciation {
                get {
                    return _SharedPronunciation != null ? _SharedPronunciation.Value : null;
                }
                set {
                    _SharedPronunciation = new RegistryValue<string>(RegistryValueKind.String, value, "SharedPronunciation");
                }
            }

            private RegistryValue<string> _SpLexicon;
            public string SpLexicon {
                get {
                    return _SpLexicon != null ? _SpLexicon.Value : null;
                }
                set {
                    _SpLexicon = new RegistryValue<string>(RegistryValueKind.String, value, "SpLexicon");
                }
            }

            private RegistryValue<string> _Vendor;
            public string Vendor {
                get {
                    return _Vendor != null ? _Vendor.Value : null;
                }
                set {
                    _Vendor = new RegistryValue<string>(RegistryValueKind.String, value, "Vendor");
                }
            }

            private RegistryValue<string> _Version;
            public string Version {
                get {
                    return _Version != null ? _Version.Value : null;
                }
                set {
                    _Version = new RegistryValue<string>(RegistryValueKind.String, value, "Version");
                }
            }

            private RegistryValue<string> _DataVersion;
            public string DataVersion {
                get {
                    return _DataVersion != null ? _DataVersion.Value : null;
                }
                set {
                    _DataVersion = new RegistryValue<string>(RegistryValueKind.String, value, "DataVersion");
                }
            }

            private RegistryValue<string> _SayAsSupport;
            public string SayAsSupport {
                get {
                    return _SayAsSupport != null ? _SayAsSupport.Value : null;
                }
                set {
                    _SayAsSupport = new RegistryValue<string>(RegistryValueKind.String, value, "SayAsSupport");
                }
            }


            public RegistryKey OriginalKey;
            public List<string> UnidentifiedSubKeys;


            public List<RegistryValue<string>> UnidentifiedValues;

            public VoiceAttributes(RegistryKey attributesKey) {
                this.OriginalKey = attributesKey;
                if (OriginalKey == null) throw new Exception("Attributes key was not found");
                string[] values = OriginalKey.GetValueNames();

                foreach (string ValueName in values) {
                    switch (ValueName) {
                        case "Age": this.Age = (string)OriginalKey.GetValue(ValueName); break;
                        case "Gender": this.Gender = (string)OriginalKey.GetValue(ValueName); break;
                        case "Language": this.Language = (string)OriginalKey.GetValue(ValueName); break;
                        case "Name": this.Name = (string)OriginalKey.GetValue(ValueName); break;
                        case "SharedPronunciation": this.SharedPronunciation = (string)OriginalKey.GetValue(ValueName); break;
                        case "SpLexicon": this.SpLexicon = (string)OriginalKey.GetValue(ValueName); break;
                        case "Vendor": this.Vendor = (string)OriginalKey.GetValue(ValueName); break;
                        case "Version": this.Version = (string)OriginalKey.GetValue(ValueName); break;
                        case "DataVersion": this.DataVersion = (string)OriginalKey.GetValue(ValueName); break;
                        case "SayAsSupport": this.SayAsSupport = (string)OriginalKey.GetValue(ValueName); break;
                        default:
                            // just store the value in unidentified list
                            if (UnidentifiedValues == null) UnidentifiedValues = new List<RegistryValue<string>>();
                            UnidentifiedValues.Add(
                                new RegistryValue<string>(
                                    OriginalKey.GetValueKind(ValueName),
                                    OriginalKey.GetValue(ValueName).ToString(),
                                    ValueName
                                )
                            );
                            break;
                    }
                }
                UnidentifiedSubKeys = OriginalKey.GetSubKeyNames().ToList();

            }

            public string serialize() {
                return "";
            }

        }

        public VoiceAttributes Attributes { get; }

        public Voice(RegistryKey voiceTokenKey) {
            OriginalToken = voiceTokenKey;
            if (OriginalToken == null) throw new Exception("Undefined voice token in the registry");

            string[] values = OriginalToken.GetValueNames();

            foreach (string ValueName in values) {
                switch (ValueName) {
                    // Default key value is the voice name
                    case "": this.Name = (string)OriginalToken.GetValue(ValueName); break;
                    case "CLSID": this.CLSID = (string)OriginalToken.GetValue(ValueName); break;
                    case "LangDataPath": this.LangDataPath = (string)OriginalToken.GetValue(ValueName); break;
                    case "VoicePath": this.VoicePath = (string)OriginalToken.GetValue(ValueName); break;
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
                                    OriginalToken.GetValueKind(ValueName),
                                    OriginalToken.GetValue(ValueName).ToString(),
                                    ValueName
                                )
                            );
                        }

                        break;
                }
            }
            string[] subkeys = OriginalToken.GetSubKeyNames();
            if (subkeys.Length > 0) {
                foreach (string subKeyName in subkeys) {
                    if (subKeyName == "Attributes") {
                        this.Attributes = new VoiceAttributes(OriginalToken.OpenSubKey(subKeyName));
                    } else {
                        if (UnidentifiedSubKeys == null) UnidentifiedSubKeys = new List<string>();
                        UnidentifiedSubKeys.Add(subKeyName);
                    }
                }
            }
        }

        public bool Equals(Voice other) {
            if (other == null) return false;
            return this.Name.Equals(other.Name);
        }
    }
}
