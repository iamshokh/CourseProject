using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DataLayer.PgSql;

[Table("doc_collection")]
public partial class DocCollection
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

    [InverseProperty("Collection")]
    public virtual ICollection<DocItem> DocItems { get; } = new List<DocItem>();

    [ForeignKey("StateId")]
    [InverseProperty("DocCollections")]
    public virtual EnumState State { get; set; } = null!;
}
