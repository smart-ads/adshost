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

    // Partner
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.29.1.0")]
    public partial class PartnerConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Partner>
    {
        public PartnerConfiguration()
            : this("acc")
        {
        }

        public PartnerConfiguration(string schema)
        {
            Property(x => x.Name).IsUnicode(false);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
