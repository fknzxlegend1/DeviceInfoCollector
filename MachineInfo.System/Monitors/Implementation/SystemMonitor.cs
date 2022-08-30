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

namespace MachineInfo.System.Monitors.Implementation
{
    internal class SystemMonitor : ISystemMonitor
    {
        private readonly ICPUMonitor CPUMonitor;
        private readonly IDiskDriveMonitor DiskDriveMonitor;
        private readonly IDiskPartitionMonitor DiskPartitionMonitor;
        private readonly IMemoryBankMonitor MemoryBankMonitor;
        private readonly IMemoryMonitor MemoryMonitor;
        private readonly IPlatformMonitor PlatformMonitor;
        private readonly IVideoControllerMonitor VideoControllerMonitor;

        public SystemMonitor(ICPUMonitor CPUMonitor,
                             IDiskDriveMonitor DiskDriveMonitor,
                             IDiskPartitionMonitor DiskPartitionMonitor,
                             IMemoryBankMonitor MemoryBankMonitor,
                             IMemoryMonitor MemoryMonitor,
                             IPlatformMonitor PlatformMonitor,
                             IVideoControllerMonitor VideoControllerMonitor)
        {
            this.CPUMonitor = CPUMonitor;
            this.DiskDriveMonitor = DiskDriveMonitor;
            this.DiskPartitionMonitor = DiskPartitionMonitor;
            this.MemoryBankMonitor = MemoryBankMonitor;
            this.MemoryMonitor = MemoryMonitor;
            this.PlatformMonitor = PlatformMonitor;
            this.VideoControllerMonitor = VideoControllerMonitor;
        }

        public ISystemInformation CollectData()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                throw new NotImplementedException("No implementations for non-Windows platforms");

            var systemInformation = new SystemInformation();

            IMemoryInformation memoryInformation = null;
            IPlatformInformation platformInformation = null;
            IEnumerable<ICPUInformation> cpusInformation = null;
            IEnumerable<IDiskDriveInformation> diskDrivesInformation = null;
            IEnumerable<IDiskPartitionInformation> diskPartitionsInformation = null;
            IEnumerable<IMemoryBankInformation> memoryBanksInformation = null;
            IEnumerable<IVideoControllerInformation> videoControllersInformation = null;

            var monitoringTasks = new Task[]
            {
                Task.Factory.StartNew(() => { memoryInformation = MemoryMonitor.CollectData(); }),
                Task.Factory.StartNew(() => { platformInformation = PlatformMonitor.CollectData(); }),
                Task.Factory.StartNew(() => { cpusInformation = CPUMonitor.CollectData(); }),
                Task.Factory.StartNew(() => { diskDrivesInformation = DiskDriveMonitor.CollectData(); }),
                Task.Factory.StartNew(() => { diskPartitionsInformation = DiskPartitionMonitor.CollectData(); }),
                Task.Factory.StartNew(() => { memoryBanksInformation = MemoryBankMonitor.CollectData(); }),
                Task.Factory.StartNew(() => { videoControllersInformation = VideoControllerMonitor.CollectData(); }),
            };

            Task.WaitAll(monitoringTasks);

            cpusInformation ??= new List<ICPUInformation>();
            diskDrivesInformation ??= new List<IDiskDriveInformation>();
            diskPartitionsInformation ??= new List<IDiskPartitionInformation>();
            memoryBanksInformation ??= new List<IMemoryBankInformation>();
            videoControllersInformation ??= new List<IVideoControllerInformation>();

            systemInformation.Memory = memoryInformation;
            systemInformation.Platform = platformInformation;
            systemInformation.CPUs.AddRange(cpusInformation);
            systemInformation.DiskDrives.AddRange(diskDrivesInformation);
            systemInformation.DiskPartitions.AddRange(diskPartitionsInformation);
            systemInformation.MemoryBanks.AddRange(memoryBanksInformation);
            systemInformation.VideoControllers.AddRange(videoControllersInformation);

            return systemInformation;
        }
    }
}
