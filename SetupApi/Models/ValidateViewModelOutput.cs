using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetupApi.Models
{
    public class ValidateViewModelOutput
    {
        public IEnumerable<string> Errors { get; private set; }

        public ValidateViewModelOutput(IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
