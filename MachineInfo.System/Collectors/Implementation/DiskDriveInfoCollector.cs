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
    internal class DiskDriveInfoCollector : IDiskDriveInfoCollector
    {
        private readonly ILogger<DiskDriveInfoCollector> logger;
        private readonly ManagementObjectSearcher managementObjectSearcher;

        public DiskDriveInfoCollector(ILogger<DiskDriveInfoCollector> logger)
        {
            this.logger = logger;
            managementObjectSearcher = new("SELECT * FROM Win32_DiskDrive");
        }

        public IEnumerable<IDiskDriveInfo> Collect()
        {
            var data = new List<IDiskDriveInfo>();

            var collection = managementObjectSearcher.Get().OfType<ManagementObject>();
            foreach (var item in collection)
            {
                var information = CollectDiskDriveInformation(item);

                if (information == null)
                    continue;

                data.Add(information);
            }

            logger.LogInformation("Collected information about {Count} Disk Drives", data.Count);

            return data;
        }

        #region Private methods

        private IDiskDriveInfo CollectDiskDriveInformation(ManagementObject mgtObject)
        {
            DiskDriveInfo information = new();
            
            try
            {
                information.Id = mgtObject[WMI_Indexes.DiskDrive_IdIndex].ToString();
                information.DeviceID = mgtObject[WMI_Indexes.DiskDrive_DeviceIDIndex].ToString();
                information.Model = mgtObject[WMI_Indexes.DiskDrive_ModelIndex].ToString();
                information.Manufacturer = mgtObject[WMI_Indexes.DiskDrive_ManufacturerIndex].ToString();
                information.SerialNumber = mgtObject[WMI_Indexes.DiskDrive_SerialNumberIndex].ToString().Trim();
                information.Status = mgtObject[WMI_Indexes.DiskDrive_StatusIndex].ToString();
                information.SystemCreationClassName = mgtObject[WMI_Indexes.DiskDrive_SystemCreationClassNameIndex].ToString();
                information.SystemName = mgtObject[WMI_Indexes.DiskDrive_SystemNameIndex].ToString();
                information.TotalCylinders = mgtObject[WMI_Indexes.DiskDrive_TotalCylindersIndex] == null ? -1 : long.Parse(mgtObject[WMI_Indexes.DiskDrive_TotalCylindersIndex].ToString());
                information.TotalHeads = mgtObject[WMI_Indexes.DiskDrive_TotalHeadsIndex] == null ? -1 : long.Parse(mgtObject[WMI_Indexes.DiskDrive_TotalHeadsIndex].ToString());
                information.TotalSectors = mgtObject[WMI_Indexes.DiskDrive_TotalSectorsIndex] == null ? -1 : long.Parse(mgtObject[WMI_Indexes.DiskDrive_TotalSectorsIndex].ToString());
                information.TotalTracks = mgtObject[WMI_Indexes.DiskDrive_TotalTracksIndex] == null ? -1 : long.Parse(mgtObject[WMI_Indexes.DiskDrive_TotalTracksIndex].ToString());
                information.Size = mgtObject[WMI_Indexes.DiskDrive_SizeIndex] == null ? -1 : long.Parse(mgtObject[WMI_Indexes.DiskDrive_SizeIndex].ToString());
                information.NumberOfMediaSupported = mgtObject[WMI_Indexes.DiskDrive_NumberOfMediaSupportedIndex] == null ? -1 : int.Parse(mgtObject[WMI_Indexes.DiskDrive_NumberOfMediaSupportedIndex].ToString());
                information.Partitions = mgtObject[WMI_Indexes.DiskDrive_PartitionsIndex] == null ? -1 : int.Parse(mgtObject[WMI_Indexes.DiskDrive_PartitionsIndex].ToString());
                information.StatusInfo = GetStatusInfo(mgtObject[WMI_Indexes.DiskDrive_StatusInfoIndex] == null ? -1 : int.Parse(mgtObject[WMI_Indexes.DiskDrive_StatusInfoIndex].ToString()));
                information.TracksPerCylinder = mgtObject[WMI_Indexes.DiskDrive_TracksPerCylinderIndex] == null ? -1 : int.Parse(mgtObject[WMI_Indexes.DiskDrive_TracksPerCylinderIndex].ToString());
                information.Signature = (mgtObject[WMI_Indexes.DiskDrive_SignatureIndex] == null) ? -1 : int.Parse(mgtObject[WMI_Indexes.DiskDrive_SignatureIndex].ToString());
            }
            catch (Exception ex)
            {
                logger.LogError("Could not collect Disk Drive information, reason: {Exception}", ex);
                return null;
            }

            return information;
        }

        /// <summary>
        /// This functions converts the disk drive status from enumeration to string
        /// </summary>
        private static string GetStatusInfo(int status)
        {
            return status switch
            {
                1 => "OTHER",
                2 => "UNKNWON",
                3 => "ENABLED",
                4 => "DISABLED",
                5 => "NOT APPLICABLE",
                _ => "",
            };
        }

        #endregion
    }
}
