using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CodeFirstExercise.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }


        public virtual Product Product { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }

        public OrderLine() { }
    }
}
