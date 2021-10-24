using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HogeschoolPxl.Data;

namespace HogeschoolPxl.Validation
{
    public class CheckHandboekId : Attribute, IModelValidator
    {
        private readonly IPxl iPxl;

        public CheckHandboekId(IPxl iPxl)
        {
            this.iPxl = iPxl;
        }
        IEnumerable<ModelValidationResult> IModelValidator.Validate(ModelValidationContext context)
        {
            var lst = new List<ModelValidationResult>();

            if (int.TryParse(context.Model.ToString(), out int id))
            {
                if (iPxl.GetHandboek(id) == null)
                {
                    lst.Add(new ModelValidationResult("", $"Handboek With id {id} does not exist !"));
                }
            }
            else
            {
                lst.Add(new ModelValidationResult("", "Not a valid Number"));
            }
            return lst;
        }
    }
}
