using OwinWebAPIwithUnity.Business.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity;
using Unity.RegistrationByConvention;

namespace OwinWebAPIwithUnity.Server
{
    public static class UnityHelpers
    {
        #region Unity Container

        private static Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);

            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return _container.Value;
        }

        #endregion

        private static IEnumerable<Type> GetTypesWithCustomAttribute<T>(Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.GetCustomAttributes(typeof(T), true).Length > 0)
                        yield return type;
                }
            }
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            var myAssemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("OwinWebAPIwithUnity")).ToArray();

            container.RegisterType(typeof(Startup));

            container.RegisterTypes(GetTypesWithCustomAttribute<UnityIoCContainerControlledAttribute>(myAssemblies),
                                    WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.ContainerControlled, null)
                     .RegisterTypes(GetTypesWithCustomAttribute<UnityIoCTransientLifetimeAttribute>(myAssemblies),
                                    WithMappings.FromMatchingInterface,  WithName.Default,  WithLifetime.Transient);
        }
    }
}
