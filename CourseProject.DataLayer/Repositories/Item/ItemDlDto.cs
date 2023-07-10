using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProject.DataLayer.Repositories.Item
{
    public class ItemDlDto
    {
        [Required]
        [StringLength(250)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(250)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [StringLength(1000)]
        public string Details { get; set; } = null!;
    }
}
