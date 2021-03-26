using OwinWebAPIwithUnity.Business.Abstracts;
using OwinWebAPIwithUnity.Business.Attributes;
using OwinWebAPIwithUnity.Business.Logging;

namespace OwinWebAPIwithUnity.Business
{
    [UnityIoCTransientLifetimeAttribute]
    public class BusinessClassExt : IBusinessClassExt
    {
        private readonly IUnitOfWorkExample _unitOfWorkExample;

        public BusinessClassExt(IUnitOfWorkExample unitOfWorkExample)
        {
            _unitOfWorkExample = unitOfWorkExample;
            UnityEventLogger.Log.CreateUnityMessage("BusinessClassExt");
        }

        private bool _disposed = false;

        public string Hello()
        {
            return "Hello from Business Class Ext";
        }

        public string SayHello(string hello)
        {
            _unitOfWorkExample.Deposit(1.5m);

            return "SayHello Business Ext " + hello;
        }

        public void Dispose()
        {
            _unitOfWorkExample.Dispose();
            UnityEventLogger.Log.DisposeUnityMessage("BusinessClassExt");

            if (!_disposed)
                _disposed = true;
        }
    }
}
