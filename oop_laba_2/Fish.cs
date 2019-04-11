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
    public class Fish : Animals
    {
        [DataMember]
        public string freshwater { get; set; }
        [DataMember]
        public string sprawingTime { get; set; }

        public Fish(string name, string cage, string fresh, string spraw) : base(name,  cage)
        {
            this.freshwater = fresh;
            this.sprawingTime = sprawingTime;
        }

    }
}
