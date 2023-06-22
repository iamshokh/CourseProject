using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataLayer.PgSql;

[Table("sys_role")]
public partial class SysRole
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

    [ForeignKey("StateId")]
    [InverseProperty("SysRoles")]
    public virtual EnumState State { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<SysUser> SysUsers { get; } = new List<SysUser>();
}
