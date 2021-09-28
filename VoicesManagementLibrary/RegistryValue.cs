using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;
using Newtonsoft.Json;

namespace VoicesManagementLibrary {
    
    public class RegistryValue<T> {

        public string Name { get; }

        public RegistryValueKind Type { get; }

        public T Value { get; }


        public RegistryValue(RegistryValueKind Type, T Value, string Name = null) {
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
