using System;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        
        int Complete();
    }
}