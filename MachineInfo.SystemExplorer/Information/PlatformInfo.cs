using System.Collections;

namespace MachineInfo.System.Information
{
    /// <summary>
    /// \class PlatformInfo 
    /// Captures the properties of the computer's platform.
    /// </summary>
    public class PlatformInfo
    {
        #region Public properties

        /// <summary>
        /// A flag indicating the operating system is 64-bit
        /// </summary>
        public bool is64BitOperatingSystem;

        /// <summary>
        /// The current machine name
        /// </summary>
        public string machineName;

        /// <summary>
        /// The operating system name
        /// </summary>
        public OperatingSystem os;

        /// <summary>
        /// The platform identifier
        /// </summary>
        public PlatformID platform;

        /// <summary>
        /// The unstalled service pack
        /// </summary>
        public string servicePack;

        /// <summary>
        /// The operating system version
        /// </summary>
        public string version;

        /// <summary>
        /// The number of computer processors
        /// </summary>
        public int processorCount;

        /// <summary>
        /// The list of logical drives
        /// </summary>
        public string[] logicalDrives;

        /// <summary>
        /// A dictionary containing the list of enviroment variables
        /// </summary>
        public IDictionary envVars;

        /// <summary>
        /// CLR version
        /// </summary>
        public Version clrVersion;

        #endregion

        #region Public methods

        /// <summary>
        /// Gets the system information (including OS, logical drives, env. variables, etc.)
        /// </summary>
        /// <returns>0 if success, -1 if an exception had occured</returns>
        public int GetSystemInfo()
        {
            try
            {
                is64BitOperatingSystem = Environment.Is64BitOperatingSystem;

                machineName = Environment.MachineName;

                os = Environment.OSVersion;

                platform = os.Platform;

                servicePack = os.ServicePack;

                clrVersion = Environment.Version;

                version = os.VersionString;

                processorCount = Environment.ProcessorCount;

                logicalDrives = Environment.GetLogicalDrives();
                
                envVars = Environment.GetEnvironmentVariables();
                
                return 0;
            }
            catch
            {
                return -1;
            }
        }

        #endregion
    }
}
