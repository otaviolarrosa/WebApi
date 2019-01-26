using Microsoft.Extensions.DependencyInjection;
using Moq;
using MyWebApi.Infra;
using MyWebApi.Ioc;
using System;

namespace MyWebApi.Tests.Base
{
    public class BaseTest
    {
        public BaseTest()
        {
            var serviceProvider = new ServiceCollection();
            new RegisterClass().Register(serviceProvider);
            new DataRegisterFake().Register(serviceProvider);
            var serviceProviderMock = new Mock<IServiceProvider>();
            ServiceLocator.SetLocatorProvider(serviceProvider.BuildServiceProvider());
        }
    }
}
