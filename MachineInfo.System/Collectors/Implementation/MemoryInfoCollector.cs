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
using MachineInfo.System.Internal;
using Microsoft.Extensions.Logging;
using System.Management;

namespace MachineInfo.System.Collectors.Implementation
{
    internal class MemoryInfoCollector : IMemoryInfoCollector
    {
        private readonly ILogger<MemoryInfoCollector> logger;
        private readonly ManagementObjectSearcher managementObjectSearcher;

        public MemoryInfoCollector(ILogger<MemoryInfoCollector> logger)
        {
            this.logger = logger;
            managementObjectSearcher = new("SELECT * FROM Win32_PhysicalMemory");
        }

        public IMemoryInfo Collect()
        {
            MemoryInfo information = new();

            try
            {
                var collection = managementObjectSearcher.Get().OfType<ManagementObject>();

                var banks = new List<(int DataWidth, long Capacity)>();
                foreach (var item in collection)
                {
                    var dataWidth = int.Parse(item[WMI_Indexes.MemoryBank_DataWidthIndex].ToString());
                    var capacity = long.Parse(item[WMI_Indexes.MemoryBank_CapacityIndex].ToString());

                    banks.Add((dataWidth, capacity));
                }

                information.NoOfMemoryBanks = banks.Count;
                information.DataWidth = banks.FirstOrDefault().DataWidth;
                information.TotalSize = banks.Sum(x => x.Capacity);

                logger.LogInformation("Collected information about Memory");
            }
            catch (Exception ex)
            {
                logger.LogError("Could not collect Memory information, reason: {Exception}", ex);
                return null;
            }

            return information;
        }
    }
}
