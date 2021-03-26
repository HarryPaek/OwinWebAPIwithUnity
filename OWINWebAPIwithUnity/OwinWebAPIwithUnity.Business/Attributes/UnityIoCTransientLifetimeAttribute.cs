using System;

namespace OwinWebAPIwithUnity.Business.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class UnityIoCTransientLifetimeAttribute : Attribute
    {
        private readonly double _version = 0.0;

        public UnityIoCTransientLifetimeAttribute()
        {
            this._version = 1.0;
        }

        public double Version
        {
            get { return this._version; }
        }
    }
}
