﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataLayer.PgSql;

[Table("enum_state")]
public partial class EnumState
{
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

    [InverseProperty("State")]
    public virtual ICollection<DocCollection> DocCollections { get; } = new List<DocCollection>();

    [InverseProperty("State")]
    public virtual ICollection<DocItem> DocItems { get; } = new List<DocItem>();

    [InverseProperty("State")]
    public virtual ICollection<EnumComment> EnumComments { get; } = new List<EnumComment>();

    [InverseProperty("State")]
    public virtual ICollection<EnumLike> EnumLikes { get; } = new List<EnumLike>();

    [InverseProperty("State")]
    public virtual ICollection<SysRole> SysRoles { get; } = new List<SysRole>();

    [InverseProperty("State")]
    public virtual ICollection<SysUser> SysUsers { get; } = new List<SysUser>();
}
