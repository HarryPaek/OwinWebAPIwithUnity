using System;

namespace OwinWebAPIwithUnity.Business.Abstracts
{
    public interface IBusinessClass : IDisposable
    {
        string Hello();
    }
}
