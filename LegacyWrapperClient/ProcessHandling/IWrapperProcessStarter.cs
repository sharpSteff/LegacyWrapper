using System;
using LegacyWrapperClient.Configuration;

namespace LegacyWrapperClient.ProcessHandling
{
    internal interface IWrapperProcessStarter : IDisposable
    {
        void StartWrapperProcess();
    }
}
