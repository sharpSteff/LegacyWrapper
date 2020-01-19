using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LegacyWrapperClient.Architecture;

namespace LegacyWrapperClient.Configuration
{
    /// <summary>
    /// Builder class for an IWrapperConfig instance.
    /// </summary>
    public class WrapperConfigBuilder
    {
        private readonly WrapperConfig _configuration;

        private WrapperConfigBuilder()
        {
            _configuration = new WrapperConfig();
        }

        /// <summary>
        /// Creates a new instance of WrapperConfigBuilder.
        /// </summary>
        /// <returns>Returns a new instance of WrapperConfigBuilder.</returns>
        public static WrapperConfigBuilder Create()
        {
            return new WrapperConfigBuilder();
        }

        /// <summary>
        /// Sets the architecture of the called DLL.
        /// </summary>
        /// <param name="targetArchitecture">The architecture of the called DLL.</param>
        /// <returns>Returns the same instance of WrapperConfigBuilder.</returns>
        public WrapperConfigBuilder TargetArchitecture(TargetArchitecture targetArchitecture)
        {
            _configuration.TargetArchitecture = targetArchitecture;
            return this;
        }

        /// <summary>
        /// Sets the timeout of the host process in mille seconds (0 is unlimited)
        /// </summary>
        /// <param name="timeout">the timeout in milliseconds</param>
        /// <returns>Returns the same instance of WrapperConfigBuilder</returns>
        public WrapperConfigBuilder Timeout(int timeout)
        {
            _configuration.Timeout = timeout;
            return this;
        }

        /// <summary>
        /// Sets the working directory, where the host process executable can be found. Default is the main executable path
        /// </summary>
        /// <param name="workingdir">the working directory</param>
        /// <returns>Returns the same instance of WrapperConfigBuilder.</returns>
        public WrapperConfigBuilder WirkingDirectory(string workingdir)
        {
            _configuration.WorkingDirectory = workingdir;
            return this;
        }

        /// <summary>
        /// Returns all configured information as an instance of IWrapperConfig.
        /// </summary>
        /// <returns>Returns an instance of IWrapperConfig.</returns>
        public IWrapperConfig Build()
        {
            return _configuration;
        }
    }
}
