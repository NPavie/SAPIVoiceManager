
using Microsoft.Win32;
using Newtonsoft.Json;

namespace VoicesManagementLibrary {

    /// <summary>
    /// Memory storage class for a value within a RegistryKey
    /// </summary>
    public class RegistryValue<T> {

        public string Name { get; }

        public RegistryValueKind Type { get; }

        public T Value { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="Value"></param>
        /// <param name="Name">Name of the value, or an empty string for default</param>
        public RegistryValue(RegistryValueKind Type, T Value, string Name = "") {
            this.Type = Type;
            this.Value = Value;
            this.Name = Name;
        }

        public string Serialize() {
            return JsonConvert.SerializeObject(this);
        }

        public static RegistryValue<object> Deserialize(string json) {
            return (RegistryValue<object>)JsonConvert.DeserializeObject(json);
        }



    }
}
