using MachineInfo.System.Enumerations;
using MachineInfo.System.Internal;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;

namespace MachineInfo.System.Information
{
    /// <summary>
    /// Class <see cref="CPUInfo"/>
    /// <para />
    /// Captures the properties of the CPUs installed on the computer.
    /// It uses a subset of the properties defined in the WMI class: Win32_Processor
    /// <para />
    /// For more information see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor">Win32_Processor</see>
    /// </summary>
    public class CPUInfo
    {
        #region Public properties

        /// <summary>
        /// CPU identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// On a 32-bit operating system, the value is 32 and on a 64-bit operating system it is 64.
        /// </summary>
        public int AddressWidth { get; set; }

        /// <summary>
        /// Processor architecture used by the platform.
        /// </summary>
        public CPUArchitecture Architecture { get; set; }

        /// <summary>
        /// Current status of the processor. Status changes indicate processor usage, 
        /// but not the physical condition of the processor.
        /// </summary>
        public CPUStatus CpuStatus { get; set; }

        /// <summary>
        /// On a 32-bit processor, the value is 32 and on a 64-bit processor it is 64.
        /// </summary>
        public int DataWidth { get; set; }

        /// <summary>
        /// Unique identifier of a processor on the system.
        /// </summary>
        public string DeviceID { get; set; }

        /// <summary>
        /// Processor family type.
        /// </summary>
        public CPUFamily Family { get; set; }

        /// <summary>
        /// Name of the processor manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Maximum speed of the processor, in MHz.
        /// </summary>
        public int MaxClockSpeed { get; set; }

        /// <summary>
        /// The part number of this processor as set by the manufacturer.
        /// </summary>
        public string PartNumber { get; set; }

        /// <summary>
        /// The serial number of this processor This value is set by the manufacturer and normally not changeable.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Globally unique identifier for the processor. This identifier may only be unique within a processor family.
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// Primary function of the processor.
        /// </summary>
        public int ProcessorType { get; set; }

        /// <summary>
        /// Processor information that describes the processor features.
        /// </summary>
        public string ProcessorId { get; set; }

        /// <summary>
        /// Load capacity of each processor, averaged to the last second. 
        /// Processor loading refers to the total computing burden for each 
        /// processor at one time.
        /// </summary>
        public int LoadPercentage { get; set; }

        /// <summary>
        /// Current speed of the processor, in MHz.
        /// </summary>
        public int CurrentClockSpeed { get; set; }

        /// <summary>
        /// Voltage of the processor. 
        /// </summary>
        public CPUVoltage CurrentVoltage { get; set; }

        /// <summary>
        /// Number of cores for the current instance of the processor. 
        /// A core is a physical processor on the integrated circuit. 
        /// </summary>
        public int NumberOfCores { get; set; }

        /// <summary>
        /// The number of enabled cores per processor socket.
        /// </summary>
        public int NumberOfEnabledCore { get; set; }

        /// <summary>
        /// Number of logical processors for the current instance of the processor. 
        /// For processors capable of hyperthreading, this value includes only the 
        /// processors which have hyperthreading enabled.
        /// </summary>
        public int NumberOfLogicalProcessors { get; set; }

        /// <summary>
        /// System revision level that depends on the architecture. 
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Size of the Level 2 processor cache. A Level 2 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public int L2CacheSize { get; set; }

        /// <summary>
        /// Clock speed of the Level 2 processor cache. A Level 2 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public int L2CacheSpeed { get; set; }

        /// <summary>
        /// Size of the Level 3 processor cache. A Level 3 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public int L3CacheSize { get; set; }

        /// <summary>
        /// Clockspeed of the Level 3 property cache. A Level 3 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public int L3CacheSpeed { get; set; }

        /// <summary>
        /// The number of threads per processor socket.
        /// </summary>
        public int ThreadCount { get; set; }

        /// <summary>
        /// If True, the Firmware has enabled virtualization extensions.
        /// </summary>
        public string VirtualizationFirmwareEnabled { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// This function parses the management object structure to extract the CPU info fields.
        /// </summary>
        /// <param name="mgtObject">Management object containing the different CPU info fields</param>
        /// <returns>returns 0 if success, -1 if an exception occured</returns>
        public int GetCpuInfo(ManagementObject mgtObject)
        {
            try
            {
                Id = mgtObject[Indexes.CPU_IdIndex] == null ? "" : Regex.Replace(mgtObject[Indexes.CPU_IdIndex].ToString(), @"\s+", " ");

                AddressWidth = int.Parse(mgtObject[Indexes.CPU_AddressWidthIndex].ToString());

                CpuStatus = GetCpuStatus(int.Parse(mgtObject[Indexes.CPU_CpuStatusIndex].ToString()));

                DataWidth = int.Parse(mgtObject[Indexes.CPU_DataWidthIndex].ToString());

                DeviceID = mgtObject[Indexes.CPU_DeviceIDIndex].ToString();

                Family = GetCpuFamily(int.Parse(mgtObject[Indexes.CPU_FamilyIndex].ToString()));

                Manufacturer = mgtObject[Indexes.CPU_ManufacturerIndex].ToString();

                MaxClockSpeed = int.Parse(mgtObject[Indexes.CPU_MaxClockSpeedIndex].ToString());

                CurrentClockSpeed = int.Parse(mgtObject[Indexes.CPU_CurrentClockSpeedIndex].ToString());

                PartNumber = mgtObject[Indexes.CPU_PartNumberIndex].ToString();

                SerialNumber = mgtObject[Indexes.CPU_SerialNumberIndex].ToString().Trim();

                UniqueId = mgtObject[Indexes.CPU_UniqueIdIndex] != null ? mgtObject[Indexes.CPU_UniqueIdIndex].ToString() : string.Empty;

                ProcessorType = int.Parse(mgtObject[Indexes.CPU_ProcessorTypeIndex].ToString());

                ProcessorId = mgtObject[Indexes.CPU_ProcessorIdIndex].ToString();

                LoadPercentage = int.Parse(mgtObject[Indexes.CPU_LoadPercentageIndex].ToString());

                Architecture = GetCpuArchitecture(int.Parse(mgtObject[Indexes.CPU_ArchitectureIndex].ToString()));

                CurrentVoltage = mgtObject[Indexes.CPU_CurrentVoltageIndex] != null ? GetCpuCurrentVoltage(int.Parse(mgtObject[Indexes.CPU_CurrentVoltageIndex].ToString())) : CPUVoltage.UNKNOWN;
                
                NumberOfLogicalProcessors = int.Parse(mgtObject[Indexes.CPU_NumberOfLogicalProcessorsIndex].ToString());
                
                NumberOfCores = int.Parse(mgtObject[Indexes.CPU_NumberOfCoresIndex].ToString());
                
                NumberOfEnabledCore = int.Parse(mgtObject[Indexes.CPU_NumberOfEnabledCoreIndex].ToString());

                Level = int.Parse(mgtObject[Indexes.CPU_LevelIndex].ToString());
                
                L2CacheSize = mgtObject[Indexes.CPU_L2CacheSizeIndex] != null ? int.Parse(mgtObject[Indexes.CPU_L2CacheSizeIndex].ToString()) : -1;
                
                L2CacheSpeed = mgtObject[Indexes.CPU_L2CacheSpeedIndex] != null ? int.Parse(mgtObject[Indexes.CPU_L2CacheSpeedIndex].ToString()) : -1;
                
                L3CacheSize = mgtObject[Indexes.CPU_L3CacheSizeIndex] != null ? int.Parse(mgtObject[Indexes.CPU_L3CacheSizeIndex].ToString()) : -1;
                
                L3CacheSpeed = mgtObject[Indexes.CPU_L3CacheSpeedIndex] != null ? int.Parse(mgtObject[Indexes.CPU_L3CacheSpeedIndex].ToString()) : -1;

                ThreadCount = mgtObject[Indexes.CPU_ThreadCountIndex] != null ? int.Parse(mgtObject[Indexes.CPU_ThreadCountIndex].ToString()) : -1;

                var success = bool.TryParse(mgtObject[Indexes.CPU_VirtualizationFirmwareEnabledIndex].ToString(), out bool virtualFlag);
                VirtualizationFirmwareEnabled = success ? (virtualFlag ? "ENABLED" : "DISABLED") : "UNKNOWN";

                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Stringifies the properties of the CPUInfo class.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder str = new();

            str.Append($"Device ID: {DeviceID}\n");
            str.Append($"Name: {Id}\n");
            str.Append($"Current Clock Speed (MHz): {CurrentClockSpeed}, Max. Clock Speed (MHz): {MaxClockSpeed}\n");
            str.Append($"Architecture: {Architecture}\n");

            if (Manufacturer != string.Empty)
                str.Append($"Manufacturer: {Manufacturer}\n");

            str.Append($"NumberOfCores: {NumberOfCores}\n");
            str.Append($"Number Of Logical Processors: {NumberOfLogicalProcessors}\n");
            str.Append($"Number Of Enabled Core: {NumberOfEnabledCore}\n");

            return str.ToString();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// This functions converts the CPU architecture from enumeration to string
        /// </summary>
        /// <param name="architecture">the CPU architecture (int)</param>
        /// <returns>the CPU architecture (string)</returns>
        private static CPUArchitecture GetCpuArchitecture(int architecture)
        {
            return architecture switch
            {
                0 => CPUArchitecture.X86,
                1 => CPUArchitecture.MIPS,
                2 => CPUArchitecture.ALPHA,
                3 => CPUArchitecture.POWERPC,
                5 => CPUArchitecture.ARM,
                6 => CPUArchitecture.IA64,
                9 => CPUArchitecture.X64,
                _ => CPUArchitecture.NONE,
            };
        }

        /// <summary>
        /// This functions converts the CPU status from enumeration to string
        /// </summary>
        /// <param name="status">the CPU status (int)</param>
        /// <returns>the CPU status (string)</returns>
        private static CPUStatus GetCpuStatus(int status)
        {
            return status switch
            {
                0 => CPUStatus.UNKNOWN,
                1 => CPUStatus.ENABLED,
                2 => CPUStatus.DISABLED_USER,
                3 => CPUStatus.DISABLED_BIOS,
                4 => CPUStatus.IDLE,
                5 or 6 => CPUStatus.RESERVED,
                7 => CPUStatus.OTHER,
                _ => CPUStatus.NONE,
            };
        }

        /// <summary>
        /// This functions converts the CPU family from enumeration to string
        /// </summary>
        /// <param name="family">the CPU family (int)</param>
        /// <returns>the CPU family (string)</returns>
        private static CPUFamily GetCpuFamily(int family)
        {
            return (CPUFamily)family;
        }

        /// <summary>
        /// This functions converts the CPU current voltage from enumeration to string
        /// </summary>
        /// <param name="voltage">the CPU current voltage (int)</param>
        /// <returns>the CPU current voltage (string)</returns>
        private static CPUVoltage GetCpuCurrentVoltage(int voltage)
        {
            return (CPUVoltage)voltage;
        }

        #endregion
    }
}
