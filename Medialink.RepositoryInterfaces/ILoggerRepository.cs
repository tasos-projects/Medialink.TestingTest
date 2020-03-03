using Medialink.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialink.RepositoryInterfaces
{
    public interface ILoggerRepository
    {
        int Log(RequestLogDBModel requestLog);
    }
}
