using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DataLayer.EfClasses
{
    [Table("sys_role")]
    public partial class Role
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        [StringLength(20)]
        public string? Code { get; set; }

        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;

        [Column("full_name")]
        [StringLength(300)]
        public string FullName { get; set; } = null!;

        [Column("state_id")]
        public int StateId { get; set; }

        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;
    }
}
