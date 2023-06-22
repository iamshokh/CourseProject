using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataLayer.PgSql;

[Table("doc_item")]
public partial class DocItem
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("full_name")]
    [StringLength(250)]
    public string FullName { get; set; } = null!;

    [Column("image_url")]
    [StringLength(250)]
    public string ImageUrl { get; set; } = null!;

    [Column("collection_id")]
    public int CollectionId { get; set; }

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

    [ForeignKey("CollectionId")]
    [InverseProperty("DocItems")]
    public virtual DocCollection Collection { get; set; } = null!;

    [ForeignKey("StateId")]
    [InverseProperty("DocItems")]
    public virtual EnumState State { get; set; } = null!;
}
