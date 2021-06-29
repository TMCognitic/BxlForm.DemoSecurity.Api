﻿using BxlForm.DemoSecurity.Api.Models.Client.Data;
using BxlForm.DemoSecurity.Api.Models.Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BxlForm.DemoSecurity.Api.Infrastructure.Validation
{
    public class CategoryIdValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int categoryId = (int)value;

            ICategoryRepository categoryService = (ICategoryRepository)validationContext.GetService(typeof(ICategoryRepository));
            Category category = categoryService.Get().Where(c => c.Id == categoryId).SingleOrDefault();

            if (category is null)
            {
                return new ValidationResult("Cette catégorie n'existe pas");
            }

            return ValidationResult.Success;
        }
    }
}
