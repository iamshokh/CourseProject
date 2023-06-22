using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DataLayer.EfClasses
{
    [Table("doc_item")]
    public class Item
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

        [ForeignKey(nameof(CollectionId))]
        public virtual Collections Collection { get; set; } = null!;

        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; } = null!;
    }
}
