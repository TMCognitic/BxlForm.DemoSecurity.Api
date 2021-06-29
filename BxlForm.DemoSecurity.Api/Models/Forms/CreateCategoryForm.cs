using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Api.Models.Forms
{
    public class CreateCategoryForm
    {
        [Required]
        [MaxLength(125)]
        public string Name { get; set; }
    }
}
