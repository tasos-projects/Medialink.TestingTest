using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medialink.RepositoryInterfaces
{
    public interface IDatabaseRepository
    {
        int Select();

        int Insert();

        int Update();

        int Delete();
    }
}
