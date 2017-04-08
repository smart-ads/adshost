using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace datamodel
{
    [Table("Advertiser", Schema = "acc")]
    public partial class Advertiser
    {
        public Advertiser()
        {
            AdvertisingCompany = new HashSet<AdvertisingCompany>();
        }

        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [InverseProperty("CreatedByNavigation")]
        public virtual ICollection<AdvertisingCompany> AdvertisingCompany { get; set; }
    }
}
