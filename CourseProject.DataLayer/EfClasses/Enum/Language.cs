using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DataLayer.EfClasses
{
    [Table("enum_language")]
    public partial class Language
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        [StringLength(10)]
        public string Code { get; set; } = null!;

        [Column("short_name")]
        [StringLength(50)]
        public string ShortName { get; set; } = null!;

        [Column("full_name")]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }
    }
}
