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
    public class Mammals : Animals
    {
        [DataMember]
        public string gender { get; set; }
        [DataMember]
        public string predator { get; set; }

        public Mammals(string name, string cage, string gender, string predator) : base(name, cage)
        {
            this.gender= gender;
            this.predator = predator;
        }
    }
}
