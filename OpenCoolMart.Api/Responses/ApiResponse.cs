using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenCoolMart.Api.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; private set; }
        public ApiResponse(T data)
        {
            this.Data = data;
        }

    }
}
