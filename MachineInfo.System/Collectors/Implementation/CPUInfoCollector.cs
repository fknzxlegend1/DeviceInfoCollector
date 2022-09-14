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
using MachineInfo.System.Enumerations;
using MachineInfo.System.Internal;
using Microsoft.Extensions.Logging;
using System.Management;
using System.Text.RegularExpressions;

namespace MachineInfo.System.Collectors.Implementation
{
    internal class CPUInfoCollector : ICPUInfoCollector
    {
        private readonly ILogger<CPUInfoCollector> logger;
        private readonly ManagementObjectSearcher managementObjectSearcher;

        public CPUInfoCollector(ILogger<CPUInfoCollector> logger)
        {
            this.logger = logger;
            managementObjectSearcher = new("SELECT * FROM Win32_Processor");
        }

        public IEnumerable<ICPUInfo> Collect()
        {
            var data = new List<ICPUInfo>();

            var collection = managementObjectSearcher.Get().OfType<ManagementObject>();
            foreach (var item in collection)
            {
                var information = CollectCPUInformation(item);

                if (information == null)
                    continue;

                data.Add(information);
            }

            logger.LogInformation("Collected information about {Count} CPUs", data.Count);

            return data;
        }

        #region Private methods

        private ICPUInfo CollectCPUInformation(ManagementObject mgtObject)
        {
            CPUInfo information = new();

            try
            {
                information.Id = mgtObject[WMI_Indexes.CPU_IdIndex] == null ? "" : Regex.Replace(mgtObject[WMI_Indexes.CPU_IdIndex].ToString(), @"\s+", " ");
                information.AddressWidth = int.Parse(mgtObject[WMI_Indexes.CPU_AddressWidthIndex].ToString());
                information.CpuStatus = GetCpuStatus(int.Parse(mgtObject[WMI_Indexes.CPU_CpuStatusIndex].ToString()));
                information.DataWidth = int.Parse(mgtObject[WMI_Indexes.CPU_DataWidthIndex].ToString());
                information.DeviceID = mgtObject[WMI_Indexes.CPU_DeviceIDIndex].ToString();
                information.Family = (CPUFamily) int.Parse(mgtObject[WMI_Indexes.CPU_FamilyIndex].ToString());
                information.Manufacturer = mgtObject[WMI_Indexes.CPU_ManufacturerIndex].ToString();
                information.MaxClockSpeed = int.Parse(mgtObject[WMI_Indexes.CPU_MaxClockSpeedIndex].ToString());
                information.CurrentClockSpeed = int.Parse(mgtObject[WMI_Indexes.CPU_CurrentClockSpeedIndex].ToString());
                information.PartNumber = mgtObject[WMI_Indexes.CPU_PartNumberIndex].ToString();
                information.SerialNumber = mgtObject[WMI_Indexes.CPU_SerialNumberIndex].ToString().Trim();
                information.UniqueId = mgtObject[WMI_Indexes.CPU_UniqueIdIndex] != null ? mgtObject[WMI_Indexes.CPU_UniqueIdIndex].ToString() : string.Empty;
                information.ProcessorType = int.Parse(mgtObject[WMI_Indexes.CPU_ProcessorTypeIndex].ToString());
                information.ProcessorId = mgtObject[WMI_Indexes.CPU_ProcessorIdIndex].ToString();
                information.LoadPercentage = int.Parse(mgtObject[WMI_Indexes.CPU_LoadPercentageIndex].ToString());
                information.Architecture = GetCpuArchitecture(int.Parse(mgtObject[WMI_Indexes.CPU_ArchitectureIndex].ToString()));
                information.CurrentVoltage = mgtObject[WMI_Indexes.CPU_CurrentVoltageIndex] != null ? (CPUVoltage) int.Parse(mgtObject[WMI_Indexes.CPU_CurrentVoltageIndex].ToString()) : CPUVoltage.UNKNOWN;
                information.NumberOfLogicalProcessors = int.Parse(mgtObject[WMI_Indexes.CPU_NumberOfLogicalProcessorsIndex].ToString());
                information.NumberOfCores = int.Parse(mgtObject[WMI_Indexes.CPU_NumberOfCoresIndex].ToString());
                information.NumberOfEnabledCore = int.Parse(mgtObject[WMI_Indexes.CPU_NumberOfEnabledCoreIndex].ToString());
                information.Level = int.Parse(mgtObject[WMI_Indexes.CPU_LevelIndex].ToString());
                information.L2CacheSize = mgtObject[WMI_Indexes.CPU_L2CacheSizeIndex] != null ? int.Parse(mgtObject[WMI_Indexes.CPU_L2CacheSizeIndex].ToString()) : -1;
                information.L2CacheSpeed = mgtObject[WMI_Indexes.CPU_L2CacheSpeedIndex] != null ? int.Parse(mgtObject[WMI_Indexes.CPU_L2CacheSpeedIndex].ToString()) : -1;
                information.L3CacheSize = mgtObject[WMI_Indexes.CPU_L3CacheSizeIndex] != null ? int.Parse(mgtObject[WMI_Indexes.CPU_L3CacheSizeIndex].ToString()) : -1;
                information.L3CacheSpeed = mgtObject[WMI_Indexes.CPU_L3CacheSpeedIndex] != null ? int.Parse(mgtObject[WMI_Indexes.CPU_L3CacheSpeedIndex].ToString()) : -1;
                information.ThreadCount = mgtObject[WMI_Indexes.CPU_ThreadCountIndex] != null ? int.Parse(mgtObject[WMI_Indexes.CPU_ThreadCountIndex].ToString()) : -1;
                var success = bool.TryParse(mgtObject[WMI_Indexes.CPU_VirtualizationFirmwareEnabledIndex].ToString(), out bool virtualFlag);
                information.VirtualizationFirmwareEnabled = success ? (virtualFlag ? "ENABLED" : "DISABLED") : "UNKNOWN";
            }
            catch (Exception ex)
            {
                logger.LogError("Could not collect CPU information, reason: {Exception}", ex);
                return null;
            }

            return information;
        }

        /// <summary>
        /// This functions converts the CPU architecture from enumeration to string
        /// </summary>
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

        #endregion
    }
}
