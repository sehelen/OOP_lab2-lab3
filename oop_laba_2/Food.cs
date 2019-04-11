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
    public class Food
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string amount { get; set; }
        [DataMember]
        public string price { get; set; }

        public Food(string name, string amount, string price)
        {
            this.amount = amount;
            this.name = name;
            this.price = price;
        }
    }
}
