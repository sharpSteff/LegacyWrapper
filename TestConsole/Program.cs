using LegacyWrapperClient.Architecture;
using LegacyWrapperClient.Client;
using LegacyWrapperClient.Configuration;
using LegacyWrapperTest.Integration.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            TestCallMethodWithoutException();




        }

        public static void TestCallMethodWithoutException()
        {
            IWrapperConfig configuration = WrapperConfigBuilder.Create()
                .TargetArchitecture(TargetArchitecture.X86)
                .Build();

            // Create new Wrapper client providing the proxy interface
            // Remember to ensure a call to the Dispose()-Method!
            using (var client = WrapperProxyFactory<IUser32Dll>.GetInstance(configuration))
            {
                // Make calls - it's that simple!
                int x = client.GetSystemMetrics(0);
                int y = client.GetSystemMetrics(1);
            }
        }
    }
}
