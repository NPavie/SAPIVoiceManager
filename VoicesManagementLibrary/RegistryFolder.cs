using Microsoft.Win32;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace VoicesManagementLibrary {

    /// <summary>
    /// Memory storage class for the content of a RegistryKey
    /// </summary>
    public class RegistryFolder {

        public List<RegistryValue<object>> Values { get; set; }

        public List<RegistryFolder> SubKeys { get; set; }

        public string Name { get; set; }

        public string ShortName { get => Path.GetFileName(this.Name); }

        public RegistryFolder() { }

        public RegistryFolder(RegistryKey key) {
            this.Name = key.Name;
            string[] values = key.GetValueNames();
            if(values.Length > 0) {
                Values = new List<RegistryValue<object>>();
                foreach (string valueName in values) {
                    Values.Add(new RegistryValue<object>(
                        key.GetValueKind(valueName),
                        key.GetValue(valueName),
                        valueName
                    ));
                }
            }
            string[] subKeyNames = key.GetSubKeyNames();
            if(subKeyNames.Length > 0) {
                SubKeys = new List<RegistryFolder>();
                foreach (string subkeyName in subKeyNames) {
                    SubKeys.Add(new RegistryFolder(
                        key.OpenSubKey(subkeyName)
                    ));
                }
            }
        }

        public string Serialize() {
            return JsonConvert.SerializeObject(this);
        }

        /// <summary>
        /// Save the folder
        /// </summary>
        /// <param name="parent"></param>
        public void InsertUnderRegistryKey(RegistryKey parent) {
            RegistryKey newKey = parent.CreateSubKey(this.ShortName);
            if (Values != null) foreach (RegistryValue<object> registryValue in Values) {
                newKey.SetValue(registryValue.Name, registryValue.Value, registryValue.Type);
            }
            if(SubKeys != null) foreach (RegistryFolder subKey in SubKeys) {
                subKey.InsertUnderRegistryKey(newKey);
            }
            newKey.Close();
        }
    }
}
