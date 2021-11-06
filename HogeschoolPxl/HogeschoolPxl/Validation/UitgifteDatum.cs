using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HogeschoolPxl.Validation
{
    public class UitgifteDatum : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            //DateTime dtm = DateTime.Now;
            var lst = new List<ModelValidationResult>();

            if (DateTime.TryParse(context.Model.ToString(), out DateTime dtm))
            {
                if (dtm > new DateTime(DateTime.Now.Year, 1, 1))
                {
                    lst.Add(new ModelValidationResult("", $"UitgifteDatum cannot be after 1/1/{DateTime.Now.Year}"));
                }
                else if (dtm < new DateTime(1980, 1, 1))
                {
                    lst.Add(new ModelValidationResult("", "UitgifteDatum should not be before  1/1/1980"));
                }
            }
            else
            {
                lst.Add(new ModelValidationResult("", "Not a valid Date!"));
            }
            return lst;
        }
    }
}
