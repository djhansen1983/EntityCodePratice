﻿using CodeFirstExercise.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CodeFirstExercise
{
    public class Order
    {
        public int Id { get; set; }
        [StringLength (30)]
        [Required]
        public string Description { get; set; }
        [Column(TypeName = "decimal(12,2)")]
        public decimal Total { get; set; }


        public int CustomerId { get; set; } //Foreign Key
        public virtual Customer Customer { get; set; }
        
        


        public Order()
        {

        }
    }
}
