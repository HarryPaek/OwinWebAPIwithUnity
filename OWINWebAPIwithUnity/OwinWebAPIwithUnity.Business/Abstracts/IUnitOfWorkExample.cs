using System;

namespace OwinWebAPIwithUnity.Business.Abstracts
{
    public interface IUnitOfWorkExample: IDisposable
    {
        string HelloFromUnitOfWorkExample();

        void Deposit(decimal depositAmount);
    }
}
