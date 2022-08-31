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
using System.Management;

namespace MachineInfo.System.Collectors.Implementation
{
    internal class DiskPartitionInfoCollector : IDiskPartitionInfoCollector
    {
        private readonly ManagementObjectSearcher managementObjectSearcher;

        public DiskPartitionInfoCollector()
        {
            managementObjectSearcher = new("SELECT * FROM Win32_DiskPartition");
        }

        public IEnumerable<IDiskPartitionInfo> Collect()
        {
            var data = new List<IDiskPartitionInfo>();

            var collection = managementObjectSearcher.Get().OfType<ManagementObject>();
            foreach (var item in collection)
            {
                var information = CollectDiskPartitionInformation(item);

                if (information == null)
                    continue;

                data.Add(information);
            }

            return data;
        }

        #region Private methods

        private static IDiskPartitionInfo CollectDiskPartitionInformation(ManagementObject mgtObject)
        {
            DiskPartitionInfo information = new();

            try
            {
                information.Id = mgtObject[WMI_Indexes.DiskPartition_IdIndex].ToString();
                information.DeviceID = mgtObject[WMI_Indexes.DiskPartition_DeviceIDIndex].ToString();
                information.Size = mgtObject[WMI_Indexes.DiskPartition_SizeIndex] != null ? long.Parse(mgtObject[WMI_Indexes.DiskPartition_SizeIndex].ToString()) : -1;
                information.NumberOfBlocks = mgtObject[WMI_Indexes.DiskPartition_NumberOfBlocksIndex] != null ? long.Parse(mgtObject[WMI_Indexes.DiskPartition_NumberOfBlocksIndex].ToString()) : -1;
                information.Status = mgtObject[WMI_Indexes.DiskPartition_StatusIndex] != null ? mgtObject[WMI_Indexes.DiskPartition_StatusIndex].ToString() : string.Empty;
                information.SystemCreationClassName = mgtObject[WMI_Indexes.DiskPartition_SystemCreationClassNameIndex].ToString();
                information.SystemName = mgtObject[WMI_Indexes.DiskPartition_SystemNameIndex].ToString();
                information.SystemName = mgtObject[WMI_Indexes.DiskPartition_TypeIndex].ToString();

                if (mgtObject[WMI_Indexes.DiskPartition_BootableIndex] != null)
                {
                    var success = bool.TryParse(mgtObject[WMI_Indexes.DiskPartition_BootableIndex].ToString(), out bool temp);
                    information.Bootable = success ? temp : null;
                }

                if (mgtObject[WMI_Indexes.DiskPartition_BootPartitionIndex] != null)
                {
                    var success = bool.TryParse(mgtObject[WMI_Indexes.DiskPartition_BootPartitionIndex].ToString(), out bool temp);
                    information.BootPartition = success ? temp : null;
                }

                if (mgtObject[WMI_Indexes.DiskPartition_PrimaryPartitionIndex] != null)
                {
                    var success = bool.TryParse(mgtObject[WMI_Indexes.DiskPartition_PrimaryPartitionIndex].ToString(), out bool temp);
                    information.PrimaryPartition = success ? temp : null;
                }

                if (mgtObject[WMI_Indexes.DiskPartition_RewritePartitionIndex] != null)
                {
                    var success = bool.TryParse(mgtObject[WMI_Indexes.DiskPartition_RewritePartitionIndex].ToString(), out bool temp);
                    information.RewritePartition = success ? temp : null;
                }
            }
            catch
            {
                return null;
            }

            return information;
        }

        #endregion
    }
}
