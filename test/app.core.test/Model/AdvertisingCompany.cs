using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("AdvertisingCompany", Schema = "comp")]
    public partial class AdvertisingCompany
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        [InverseProperty("AdvertisingCompany")]
        public virtual Advertiser CreatedByNavigation { get; set; }
    }
}
