using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialink.Domain
{
    public class RequestLogDBModel
    {
        public int RequestLogDBModel_ID { get; set; }

        public string LogMethod { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
