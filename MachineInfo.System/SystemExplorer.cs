using MachineInfo.System.Information;
using System.Management;
using System.Runtime.InteropServices;

namespace MachineInfo.System
{
    /// <summary>
    /// \class Explorer
    /// A class that instantiates and calls all the classes in charge of discovering the installed hardware / software.
    /// </summary>
    public class SystemExplorer
    {
        #region Constructors

        /// <summary>
        /// Default construct which initializes all hardware objects
        /// </summary>
        public SystemExplorer()
        {
            System_CPUs = new List<CPUInfo>();
            System_Memory = new List<MemoryBankInfo>();
            System_VideoControllers = new List<VideoControllerInfo>();
            PlatformInformation = new PlatformInfo();
            MemoryInformation = new MemoryInfo();
            System_DiskDrives = new List<DiskDriveInfo>();
            System_DiskPartitions = new List<DiskPartitionInfo>();
        }

        #endregion

        #region Public properties

        /// <summary>
        /// The platform information
        /// </summary>
        public PlatformInfo PlatformInformation { get; set; }

        /// <summary>
        /// List of system CPUs
        /// </summary>
        public List<CPUInfo> System_CPUs { get; set; }

        /// <summary>
        /// List of memory banks information
        /// </summary>
        public List<MemoryBankInfo> System_Memory { get; set; }

        /// <summary>
        /// General information about installed memory
        /// </summary>
        public MemoryInfo MemoryInformation { get; set; }
        
        /// <summary>
        /// List of video controller information
        /// </summary>
        public List<VideoControllerInfo> System_VideoControllers { get; set; }

        /// <summary>
        /// List of disk drives information
        /// </summary>
        public List<DiskDriveInfo> System_DiskDrives { get; set; }

        /// <summary>
        /// List of disk partitions' information
        /// </summary>
        public List<DiskPartitionInfo> System_DiskPartitions { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// This functions queries the different software / hardware records in order to get their properties
        /// </summary>
        /// <returns>0 if success and -1 if an exception arises</returns>
        public int Run()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new NotImplementedException("No implementations for non-Windows platforms");

            try
            {
                int error = 0;

                PlatformInformation.GetSystemInfo();

                GetCPUInfo();

                GetMemoryInfo();

                MemoryInformation.GetMemoryInfo(System_Memory);

                GetVideoControllerInfo();

                GetDiskDriveInfo();

                GetDiskPartitionInfo();

                return error;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// This function queries the Win32_Processor in order to extract the properties of all installed CPUs
        /// <seealso cref="CPUInfo"/>
        /// </summary>
        public void GetCPUInfo()
        {
            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_Processor");
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol.OfType<ManagementObject>())
            {
                CPUInfo cpu = new();
                cpu.GetCpuInfo(mgtObject);

                System_CPUs.Add(cpu);
            }
        }

        /// <summary>
        /// This function queries the Win32_PhysicalMemory in order to extract the properties of all installed memory banks
        /// <seealso cref="MemoryBankInfo"/>
        /// </summary>
        public void GetMemoryInfo()
        {
            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_PhysicalMemory");
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol.OfType<ManagementObject>())
            {
                MemoryBankInfo mem = new();
                mem.GetMemInfo(mgtObject);                

                System_Memory.Add(mem);
            }
        }

        /// <summary>
        /// This function queries the Win32_VideoController in order to extract the properties of all installed video controllers
        /// <seealso cref="VideoControllerInfo"/>
        /// </summary>
        public void GetVideoControllerInfo()
        {
            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_VideoController");
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol.OfType<ManagementObject>())
            {
                VideoControllerInfo vid = new();
                vid.GetVideoControllerInfo(mgtObject);

                System_VideoControllers.Add(vid);
            }
        }

        /// <summary>
        /// This function queries the Win32_DiskDrive in order to extract the properties of all installed disk drives
        /// <seealso cref="DiskDriveInfo"/>
        /// </summary>
        public void GetDiskDriveInfo()
        {
            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_DiskDrive");
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol.OfType<ManagementObject>())
            {
                DiskDriveInfo disk = new();
                disk.GetDiskDriveInfo(mgtObject);

                System_DiskDrives.Add(disk);
            }
        }

        /// <summary>
        /// This function queries the Win32_DiskPartition in order to extract the properties of all available disk partitions
        /// <seealso cref="DiskPartitionInfo"/>
        /// </summary>
        public void GetDiskPartitionInfo()
        {
            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_DiskPartition");
            ManagementObjectCollection objCol = searcher.Get();

            foreach (ManagementObject mgtObject in objCol.OfType<ManagementObject>())
            {
                DiskPartitionInfo partition = new();
                partition.GetDiskPartitionInfo(mgtObject);

                System_DiskPartitions.Add(partition);
            }
        }

        #endregion
    }
}
