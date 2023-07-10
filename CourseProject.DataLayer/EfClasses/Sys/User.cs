using CourseProject.Core.Security;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DataLayer.EfClasses
{
    [Table("sys_user")]
    [Index("UserName", Name = "sys_user_unique_index_user_name", IsUnique = true)]
    public partial class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_name")]
        [StringLength(250)]
        public string UserName { get; set; } = null!;

        [Column("password_hash")]
        [StringLength(250)]
        public string PasswordHash { get; set; } = null!;

        [Column("password_salt")]
        [StringLength(250)]
        public string PasswordSalt { get; set; } = null!;

        [Column("email")]
        [StringLength(250)]
        public string? Email { get; set; }

        [Column("phone_number")]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        [Column("shortname")]
        [StringLength(260)]
        public string Shortname { get; set; } = null!;

        [Column("fullname")]
        [StringLength(500)]
        public string Fullname { get; set; } = null!;

        [Column("last_access_time", TypeName = "timestamp without time zone")]
        public DateTime? LastAccessTime { get; set; }

        [Column("state_id")]
        public int StateId { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }

        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [Column("created_user_id")]
        public int? CreatedUserId { get; set; }

        [Column("modified_date", TypeName = "timestamp without time zone")]
        public DateTime? ModifiedDate { get; set; }

        [Column("modified_user_id")]
        public int? ModifiedUserId { get; set; }

        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; } = null!;

        public bool IsValidPassword(string password)
        {
            return !(string.IsNullOrEmpty(password) || PasswordHasher.GenerateHash(password, PasswordSalt) != PasswordHash);
        }
        public void SetPassword(string password, bool isNewEntity = false)
        {
            if (isNewEntity && string.IsNullOrEmpty(password))
                throw new ArgumentException("Password required for new user", nameof(password));

            if (isNewEntity || !string.IsNullOrEmpty(password))
            {
                PasswordSalt = PasswordHasher.GenerateSalt();
                PasswordHash = PasswordHasher.GenerateHash(password, PasswordSalt);
            }
        }
    }
}
