using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.Error
{
    public class ApiError
    {
        public int Code { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }
    }
}
