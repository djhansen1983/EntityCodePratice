using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;

namespace CodeFirstExercise.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; } //max length of name will be 30
        [StringLength(2)]
        [Required]
        public string State { get; set; } //max length of state is 2
        public bool IsNationalAccount { get; set; } = false;
        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalSales { get; set; } = 0;

        public virtual IEnumerable<Order> Orders { get; set; }

        public Customer()
        {

        }
    }
}
