using Autofac;
using Autofac.Core;
using System;
using System.Collections.Generic;

namespace inWMSAndroid.Utilities.DI
{
    public sealed class DependencyInjectionManager : IDisposable
    {
        private bool vrcContainerWasBuild = false;
        private static DependencyInjectionManager vrcDependencyContainer;
        private static ContainerBuilder vrcContainerBuilder;
        private static Autofac.IContainer container { get; set; }

        public Autofac.IContainer Container { get => container; }
        public ContainerBuilder ContainerBuilder { get => vrcContainerBuilder; }

        private DependencyInjectionManager()
        {

        }

        public static DependencyInjectionManager GetInstance()
        {
            if (vrcDependencyContainer == null)
            {
                vrcDependencyContainer = new DependencyInjectionManager();
                CreateContainerBuilder();
            }
            return vrcDependencyContainer;
        }

        public T Resolve<T>(params ResolveParameter[] parameters)
        {
            IList<Parameter> parameterList = new List<Parameter>();
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    parameterList.Add(new NamedParameter(param.ParameterName, param.ParameterValue));
                }
            }
            return container.Resolve<T>(parameterList);
        }

        private static void CreateContainerBuilder()
        {
            if (vrcContainerBuilder == null)
            {
                vrcContainerBuilder = new ContainerBuilder();
            }
        }

        public void BuildContainer()
        {
            if (vrcContainerWasBuild)
            {
                return;
            }
            if (container != null)
            {
                container.Dispose();
                container = null;
            }
            container = vrcContainerBuilder.Build();
            vrcContainerWasBuild = true;
        }

        public void Dispose()
        {
            if (container != null)
            {
                container.Dispose();
                container = null;
            }
            if (vrcContainerBuilder != null)
            {
                vrcContainerBuilder = new ContainerBuilder();
            }
            vrcContainerWasBuild = false;
        }
    }

    public class ResolveParameter
    {
        public ResolveParameter(string parameterName, object parameterValue)
        {
            ParameterName = parameterName;
            ParameterValue = parameterValue;
        }
        public string ParameterName { get; private set; }
        public object ParameterValue { get; private set; }
    }

    public class RegisterParameter
    {
        public RegisterParameter(ResolveParameter resolveParameter, object returnType)
        {
            ResolveParameter = resolveParameter;
            ReturnType = returnType;
        }

        public ResolveParameter ResolveParameter { get; private set; }
        public object ReturnType { get; private set; }
    }
}
