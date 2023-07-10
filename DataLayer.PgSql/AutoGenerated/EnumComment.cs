using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataLayer.PgSql;

[Table("enum_comment")]
public partial class EnumComment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("details")]
    [StringLength(1000)]
    public string Details { get; set; } = null!;

    [Column("state_id")]
    public int StateId { get; set; }

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }

    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }

    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("EnumComments")]
    public virtual DocItem Item { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("EnumComments")]
    public virtual EnumState State { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("EnumComments")]
    public virtual SysUser User { get; set; } = null!;
}
