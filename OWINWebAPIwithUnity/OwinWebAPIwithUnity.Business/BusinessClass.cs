using OwinWebAPIwithUnity.Business.Abstracts;
using OwinWebAPIwithUnity.Business.Attributes;
using OwinWebAPIwithUnity.Business.Logging;

namespace OwinWebAPIwithUnity.Business
{
    [UnityIoCTransientLifetimeAttribute]
    public class BusinessClass : IBusinessClass
    {
        private IUnitOfWorkExample _unitOfWorkExample;

        public BusinessClass(IUnitOfWorkExample unitOfWorkExample)
        {
            _unitOfWorkExample = unitOfWorkExample;
            UnityEventLogger.Log.CreateUnityMessage("BusinessClass");
        }

        private bool _disposed = false;

        public string Hello()
        {
            return _unitOfWorkExample.HelloFromUnitOfWorkExample();
        }

        public void Dispose()
        {
            _unitOfWorkExample.Dispose();
            UnityEventLogger.Log.DisposeUnityMessage("BusinessClass");

            if (!_disposed)
                _disposed = true;
        }
    }
}
