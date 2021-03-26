using System;

namespace OwinWebAPIwithUnity.Business.Abstracts
{
    public interface IBusinessClassExt : IBusinessClass, IDisposable
    {
        string SayHello(string hello);
    }
}
