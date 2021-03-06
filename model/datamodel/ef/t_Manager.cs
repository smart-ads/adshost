// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace datamodel
{
    using Newtonsoft.Json;

    // Manager
    [Table("Manager", Schema = "acc")]
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public partial class Manager
    {

        ///<summary>
        /// Идентификатор
        ///</summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "int")]
        [Index(@"PK_Manager", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; } // Id (Primary key)

        ///<summary>
        /// Имя
        ///</summary>
        [Column(@"Name", Order = 2, TypeName = "varchar")]
        [Index(@"UK_Manager#Name", 1, IsUnique = true, IsClustered = false)]
        [Required]
        [MaxLength(255)]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Name { get; set; } // Name (length: 255)

        public Manager()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
