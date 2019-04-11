using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace oop_laba_2
{
    [Serializable, DataContract]
    public class Animals
    {
        [DataMember]
        public string cage_number { get; set; }
        [DataMember]
        public string name { get; set; }


        public Animals(string name, string cage)
        {
            this.cage_number = cage;
            this.name = name;
        }
    }
}
