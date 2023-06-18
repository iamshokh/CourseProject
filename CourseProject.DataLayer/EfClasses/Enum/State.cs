using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DataLayer.EfClasses
{
    [Table("enum_state")]
    public partial class State
    {
        public State()
        {
            Users = new HashSet<User>();
        }
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        [StringLength(50)]
        public string? Code { get; set; }

        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;

        [Column("full_name")]
        [StringLength(250)]
        public string FullName { get; set; } = null!;

        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [InverseProperty(nameof(User.State))]
        public virtual ICollection<User> Users { get; } = new List<User>();
    }
}
