﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ProductDto
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(35)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
