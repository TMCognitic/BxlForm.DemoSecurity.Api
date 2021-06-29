using BxlForm.DemoSecurity.Api.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Api.Models.Forms
{
    public class EditContactForms
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(75)]
        public string LastName { get; set; }
        [Required]
        [StringLength(75)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(384)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [CategoryIdValidation]
        public int CategoryId { get; set; }
    }
}
