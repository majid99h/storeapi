using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Core
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
