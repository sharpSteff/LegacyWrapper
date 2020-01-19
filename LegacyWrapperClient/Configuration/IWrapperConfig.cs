using LegacyWrapperClient.Architecture;

namespace LegacyWrapperClient.Configuration
{
    /// <summary>
    /// This class holds all configuration necessary for connecting to a LegacyWrapper instance.
    /// </summary>
    /// <remarks>This class is designed immutable.</remarks>
    public interface IWrapperConfig
    {
        /// <summary>
        /// The architecture of the called DLL (X86 or AMD64).
        /// </summary>
        TargetArchitecture TargetArchitecture { get; }

        /// <summary>
        /// Gets the time in milliseconds where a host process can be inactive before closing
        /// </summary>
        int Timeout { get; }

        string WorkingDirectory { get; }
    }
}