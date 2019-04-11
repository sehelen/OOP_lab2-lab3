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
    public class Birds : Animals
    {
        [DataMember]
        public string migratory { get; set; }
        [DataMember]
        public string eggsAmount { get; set; }

        public Birds(string name, string cage, string migratory, string eggsAmount) : base(name, cage)
        {
            this.migratory = migratory;
            this.eggsAmount = eggsAmount;
        }
    }
}
