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
    class Cubs : Mammals
    {
        [DataMember]
        public Food food { get; set; }
        [DataMember]
        public string timeToBecomeAdult { get; set; }

        public Cubs(string name, string cage, string gender, string predator, Food food, string time) : base(name, cage, gender, predator)
        {
            this.food = food;
            this.timeToBecomeAdult = time;
        }
    }
}
