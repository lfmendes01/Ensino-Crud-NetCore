using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dto.Error
{
    public class ApiErrorResult
    {
        public IEnumerable<ApiError> Errors { get; set; }

        public ApiErrorResult() { }

        public ApiErrorResult(int code, string header, string message)
        {
            Errors = new List<ApiError>()
            {
                new ApiError()
                {
                    Code = code,
                    Header = header,
                    Message = message
                }
            };
        }
    }
}
