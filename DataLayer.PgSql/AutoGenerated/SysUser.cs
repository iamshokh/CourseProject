﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataLayer.PgSql;

[Table("sys_user")]
[Index("UserName", Name = "sys_user_unique_index_user_name", IsUnique = true)]
public partial class SysUser
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

    [InverseProperty("User")]
    public virtual ICollection<EnumComment> EnumComments { get; } = new List<EnumComment>();

    [InverseProperty("User")]
    public virtual ICollection<EnumLike> EnumLikes { get; } = new List<EnumLike>();

    [ForeignKey("RoleId")]
    [InverseProperty("SysUsers")]
    public virtual SysRole Role { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("SysUsers")]
    public virtual EnumState State { get; set; } = null!;
}
