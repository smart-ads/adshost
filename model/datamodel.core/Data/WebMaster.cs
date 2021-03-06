﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("WebMaster", Schema = "acc")]
    public partial class WebMaster
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
    }
}
