using MachineInfo.System.Collectors;
using MachineInfo.System.Collectors.Implementation;

namespace MachineInfo.System
{
    public static class SystemInfoCollectorFactory
    {
        private static ISystemInfoCollector systemMonitor;

        public static ISystemInfoCollector Create()
        {
            if (systemMonitor != null)
                return systemMonitor;

            ICPUInfoCollector cpuMonitor = new CPUInfoCollector();
            IDiskDriveInfoCollector diskDriveMonitor = new DiskDriveInfoCollector();
            IDiskPartitionInfoCollector diskPartitionMonitor = new DiskPartitionInfoCollector();
            IMemoryBankInfoCollector memoryBankMonitor = new MemoryBankInfoCollector();
            IMemoryInfoCollector memoryMonitor = new MemoryInfoCollector();
            IPlatformInfoCollector platformMonitor = new PlatformInfoCollector();
            IVideoControllerInfoCollector videoControllerMonitor = new VideoControllerInfoCollector();

            systemMonitor = new SystemInfoCollector(cpuMonitor, 
                                              diskDriveMonitor, 
                                              diskPartitionMonitor, 
                                              memoryBankMonitor, 
                                              memoryMonitor, 
                                              platformMonitor, 
                                              videoControllerMonitor);

            return systemMonitor;
        }
    }
}
