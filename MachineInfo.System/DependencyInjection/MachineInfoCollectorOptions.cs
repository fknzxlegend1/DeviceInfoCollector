namespace MachineInfo.System
{
    public class SystemInfoCollectorOptions
    {
        public bool EnableCPUInfoCollection { get; set; }
        public bool EnableDiskDriveInfoCollection { get; set; }
        public bool EnableDiskPartitionInfoCollection { get; set; }
        public bool EnableMemoryBankInfoCollection { get; set; }
        public bool EnableMemoryInfoCollection { get; set; }
        public bool EnablePlatformInfoCollection { get; set; }
        public bool EnableVideoControllerInfoCollection { get; set; }
    }
}
