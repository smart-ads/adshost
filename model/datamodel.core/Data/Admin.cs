using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("Admin", Schema = "acc")]
    public partial class Admin
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public bool IsSuper { get; set; }
    }
}
