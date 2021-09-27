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

        public string serialize() {
            return JsonConvert.SerializeObject(this);
            /*return "{" +
                "\"name\":" + (this.Name != null ? ("\"" + this.Name.ToString().Replace("\\", "\\\\") + "\"") : "null") + ","+
                "\"type\":" + "\"" + this.Type.ToString() + "\"" + "," +
                "\"value\":" + "\"" + this.Value.ToString().Replace("\\", "\\\\") + "\"" +
                "}";*/
        }

        public static RegistryValue<object> unserialize(string json) {
            // TODO
        }



    }
}
