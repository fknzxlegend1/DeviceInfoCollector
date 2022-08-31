namespace MachineInfo.System
{
    public class MachineInfoCollectorOptions
    {
        public bool DisableCPUInfoCollection { get; set; }
        public bool DisableDiskDriveInfoCollection { get; set; }
        public bool DisableDiskPartitionInfoCollection { get; set; }
        public bool DisableMemoryBankInfoCollection { get; set; }
        public bool DisableMemoryInfoCollection { get; set; }
        public bool DisablePlatformInfoCollection { get; set; }
        public bool DisableVideoControllerInfoCollection { get; set; }
    }
}
