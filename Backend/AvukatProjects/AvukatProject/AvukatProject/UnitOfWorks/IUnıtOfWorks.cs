using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.UnitOfWorks
{
    public interface IUnıtOfWorks
    {
        Task CommitAsync();
        void Commit();
    }
}
