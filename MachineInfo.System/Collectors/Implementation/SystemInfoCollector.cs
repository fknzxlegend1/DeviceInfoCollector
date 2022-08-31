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
        private readonly MachineInfoCollectorOptions collectorOptions;

        private readonly ICPUInfoCollector CPUMonitor;
        private readonly IDiskDriveInfoCollector DiskDriveMonitor;
        private readonly IDiskPartitionInfoCollector DiskPartitionMonitor;
        private readonly IMemoryBankInfoCollector MemoryBankMonitor;
        private readonly IMemoryInfoCollector MemoryMonitor;
        private readonly IPlatformInfoCollector PlatformMonitor;
        private readonly IVideoControllerInfoCollector VideoControllerMonitor;

        public SystemInfoCollector(MachineInfoCollectorOptions collectorOptions,
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

            var systemInformation = new SystemInfo();

            IMemoryInfo memoryInformation = null;
            IPlatformInfo platformInformation = null;
            IEnumerable<ICPUInfo> cpusInformation = null;
            IEnumerable<IDiskDriveInfo> diskDrivesInformation = null;
            IEnumerable<IDiskPartitionInfo> diskPartitionsInformation = null;
            IEnumerable<IMemoryBankInfo> memoryBanksInformation = null;
            IEnumerable<IVideoControllerInfo> videoControllersInformation = null;

            var monitoringTasks = new List<Task>();

            if (!collectorOptions.DisableMemoryInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { memoryInformation = MemoryMonitor.Collect(); }));

            if (!collectorOptions.DisablePlatformInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { platformInformation = PlatformMonitor.Collect(); }));

            if (!collectorOptions.DisableCPUInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { cpusInformation = CPUMonitor.Collect(); }));

            if (!collectorOptions.DisableDiskDriveInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { diskDrivesInformation = DiskDriveMonitor.Collect(); }));

            if (!collectorOptions.DisableDiskPartitionInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { diskPartitionsInformation = DiskPartitionMonitor.Collect(); }));

            if (!collectorOptions.DisableMemoryBankInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { memoryBanksInformation = MemoryBankMonitor.Collect(); }));

            if (!collectorOptions.DisableVideoControllerInfoCollection)
                monitoringTasks.Add(Task.Factory.StartNew(() => { videoControllersInformation = VideoControllerMonitor.Collect(); }));

            Task.WaitAll(monitoringTasks.ToArray());

            cpusInformation ??= Enumerable.Empty<ICPUInfo>();
            diskDrivesInformation ??= Enumerable.Empty<IDiskDriveInfo>();
            diskPartitionsInformation ??= Enumerable.Empty<IDiskPartitionInfo>();
            memoryBanksInformation ??= Enumerable.Empty<IMemoryBankInfo>();
            videoControllersInformation ??= Enumerable.Empty<IVideoControllerInfo>();

            systemInformation.Memory = memoryInformation;
            systemInformation.Platform = platformInformation;
            systemInformation.CPUs.AddRange(cpusInformation);
            systemInformation.DiskDrives.AddRange(diskDrivesInformation);
            systemInformation.DiskPartitions.AddRange(diskPartitionsInformation);
            systemInformation.MemoryBanks.AddRange(memoryBanksInformation);
            systemInformation.VideoControllers.AddRange(videoControllersInformation);

            monitoringTasks.ForEach(x => x.Dispose());

            return systemInformation;
        }
    }
}
