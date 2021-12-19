using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Service.Common.Dtos.Api
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Error { get; set; }
    }
}
