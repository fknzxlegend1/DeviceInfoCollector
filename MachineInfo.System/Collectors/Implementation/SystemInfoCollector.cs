#region License information

/*

Copyright 2022 Bogdan Bara, Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using MachineInfo.System.Data;
using MachineInfo.System.Data.Implementation;
using System.Runtime.InteropServices;

namespace MachineInfo.System.Collectors.Implementation
{
    internal class SystemInfoCollector : ISystemInfoCollector
    {
        private readonly SystemInfoCollectorOptions collectorOptions;

        private readonly ICPUInfoCollector CPUMonitor;
        private readonly IDiskDriveInfoCollector DiskDriveMonitor;
        private readonly IDiskPartitionInfoCollector DiskPartitionMonitor;
        private readonly IMemoryBankInfoCollector MemoryBankMonitor;
        private readonly IMemoryInfoCollector MemoryMonitor;
        private readonly IPlatformInfoCollector PlatformMonitor;
        private readonly IVideoControllerInfoCollector VideoControllerMonitor;

        public SystemInfoCollector(SystemInfoCollectorOptions collectorOptions,
                                   ICPUInfoCollector CPUMonitor,
                                   IDiskDriveInfoCollector DiskDriveMonitor,
                                   IDiskPartitionInfoCollector DiskPartitionMonitor,
                                   IMemoryBankInfoCollector MemoryBankMonitor,
                                   IMemoryInfoCollector MemoryMonitor,
                                   IPlatformInfoCollector PlatformMonitor,
                                   IVideoControllerInfoCollector VideoControllerMonitor)
        {
            this.collectorOptions = collectorOptions;
            this.CPUMonitor = CPUMonitor;
            this.DiskDriveMonitor = DiskDriveMonitor;
            this.DiskPartitionMonitor = DiskPartitionMonitor;
            this.MemoryBankMonitor = MemoryBankMonitor;
            this.MemoryMonitor = MemoryMonitor;
            this.PlatformMonitor = PlatformMonitor;
            this.VideoControllerMonitor = VideoControllerMonitor;
        }

        public ISystemInfo Collect()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new NotImplementedException("No implementations for non-Windows platforms");

            var systemInfo = new SystemInfo();

            IMemoryInfo memoryInfo = null;
            IPlatformInfo platformInfo = null;
            IEnumerable<ICPUInfo> cpusInfo = null;
            IEnumerable<IDiskDriveInfo> diskDrivesInfo = null;
            IEnumerable<IDiskPartitionInfo> diskPartitionsInfo = null;
            IEnumerable<IMemoryBankInfo> memoryBanksInfo = null;
            IEnumerable<IVideoControllerInfo> videoControllersInfo = null;

            var monitoringTasks = new List<Task>();

            if (collectorOptions.EnableMemoryInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { memoryInfo = MemoryMonitor.Collect(); }));

            if (collectorOptions.EnablePlatformInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { platformInfo = PlatformMonitor.Collect(); }));

            if (collectorOptions.EnableCPUInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { cpusInfo = CPUMonitor.Collect(); }));

            if (collectorOptions.EnableDiskDriveInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { diskDrivesInfo = DiskDriveMonitor.Collect(); }));

            if (collectorOptions.EnableDiskPartitionInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { diskPartitionsInfo = DiskPartitionMonitor.Collect(); }));

            if (collectorOptions.EnableMemoryBankInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { memoryBanksInfo = MemoryBankMonitor.Collect(); }));

            if (collectorOptions.EnableVideoControllerInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { videoControllersInfo = VideoControllerMonitor.Collect(); }));

            if (monitoringTasks.Any())
                Task.WaitAll(monitoringTasks.ToArray());

            cpusInfo ??= Enumerable.Empty<ICPUInfo>();
            diskDrivesInfo ??= Enumerable.Empty<IDiskDriveInfo>();
            diskPartitionsInfo ??= Enumerable.Empty<IDiskPartitionInfo>();
            memoryBanksInfo ??= Enumerable.Empty<IMemoryBankInfo>();
            videoControllersInfo ??= Enumerable.Empty<IVideoControllerInfo>();

            systemInfo.Memory = memoryInfo;
            systemInfo.Platform = platformInfo;
            systemInfo.CPUs.AddRange(cpusInfo);
            systemInfo.DiskDrives.AddRange(diskDrivesInfo);
            systemInfo.DiskPartitions.AddRange(diskPartitionsInfo);
            systemInfo.MemoryBanks.AddRange(memoryBanksInfo);
            systemInfo.VideoControllers.AddRange(videoControllersInfo);

            monitoringTasks.ForEach(x => x.Dispose());

            return systemInfo;
        }
    }
}
