using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses
{
    public abstract class BaseResponse
    {
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
