using LegacyWrapperClient.Architecture;

namespace LegacyWrapperClient.Configuration
{
    internal class WrapperConfig : IWrapperConfig
    {
        internal WrapperConfig()
        {
            Timeout = System.Threading.Timeout.Infinite;
        }

        public TargetArchitecture TargetArchitecture { get; set; }

        public int Timeout { get; set; }

        public string WorkingDirectory { get; set; }
    }
}
