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
using System.Management;

namespace MachineInfo.System.Monitors.Implementation
{
    internal class MemoryBankMonitor : IMemoryBankMonitor
    {
        private readonly ManagementObjectSearcher managementObjectSearcher;

        public MemoryBankMonitor()
        {
            managementObjectSearcher = new("SELECT * FROM Win32_PhysicalMemory");
        }

        public IEnumerable<IMemoryBankInformation> CollectData()
        {
            var data = new List<IMemoryBankInformation>();

            var collection = managementObjectSearcher.Get().OfType<ManagementObject>();
            foreach (var item in collection)
            {
                var information = CollectMemoryBankInformation(item);

                if (information == null)
                    continue;

                data.Add(information);
            }

            return data;
        }

        #region Private methods

        private static IMemoryBankInformation CollectMemoryBankInformation(ManagementObject mgtObject)
        {
            MemoryBankInformation information = new();

            try
            {
                information.Capacity = long.Parse(mgtObject[WMI_Indexes.MemoryBank_CapacityIndex].ToString());
                information.Id = mgtObject[WMI_Indexes.MemoryBank_IdIndex] != null ? mgtObject[WMI_Indexes.MemoryBank_IdIndex].ToString() : string.Empty;
                information.BankLabel = mgtObject[WMI_Indexes.MemoryBank_BankLabelIndex] == null ? string.Empty : mgtObject[WMI_Indexes.MemoryBank_BankLabelIndex].ToString();
                information.Description = mgtObject[WMI_Indexes.MemoryBank_DescriptionIndex] != null ? mgtObject[WMI_Indexes.MemoryBank_DescriptionIndex].ToString() : string.Empty;
                information.DeviceLocator = mgtObject[WMI_Indexes.MemoryBank_DeviceLocatorIndex] != null ? mgtObject[WMI_Indexes.MemoryBank_DeviceLocatorIndex].ToString() : string.Empty;
                information.Manufacturer = mgtObject[WMI_Indexes.MemoryBank_ManufacturerIndex] != null ? mgtObject[WMI_Indexes.MemoryBank_ManufacturerIndex].ToString() : string.Empty;
                information.SerialNumber = mgtObject[WMI_Indexes.MemoryBank_SerialNumberIndex].ToString();
                information.SKU = mgtObject[WMI_Indexes.MemoryBank_SKUIndex] != null ? mgtObject[WMI_Indexes.MemoryBank_SKUIndex].ToString() : string.Empty;
                information.Status = mgtObject[WMI_Indexes.MemoryBank_StatusIndex] != null ? mgtObject[WMI_Indexes.MemoryBank_StatusIndex].ToString() : string.Empty;
                information.Model = mgtObject[WMI_Indexes.MemoryBank_ModelIndex] != null ? mgtObject[WMI_Indexes.MemoryBank_ModelIndex].ToString() : string.Empty;
                information.OtherIdentifyingInfo = mgtObject[WMI_Indexes.MemoryBank_OtherIdentifyingInfoIndex] != null ? mgtObject[WMI_Indexes.MemoryBank_OtherIdentifyingInfoIndex].ToString() : string.Empty;
                information.PartNumber = mgtObject[WMI_Indexes.MemoryBank_PartNumberIndex] != null ? mgtObject[WMI_Indexes.MemoryBank_PartNumberIndex].ToString() : string.Empty;
                information.DataWidth = int.Parse(mgtObject[WMI_Indexes.MemoryBank_DataWidthIndex].ToString());
                information.Speed = int.Parse(mgtObject[WMI_Indexes.MemoryBank_SpeedIndex].ToString());
                information.SMBIOSMemoryType = int.Parse(mgtObject[WMI_Indexes.MemoryBank_SMBIOSMemoryTypeIndex].ToString());
                information.Tag = mgtObject[WMI_Indexes.MemoryBank_TagIndex] == null ? string.Empty : mgtObject[WMI_Indexes.MemoryBank_TagIndex].ToString();
                information.Version = mgtObject[WMI_Indexes.MemoryBank_VersionIndex] == null ? string.Empty : mgtObject[WMI_Indexes.MemoryBank_VersionIndex].ToString();
                information.TotalWidth = int.Parse(mgtObject[WMI_Indexes.MemoryBank_TotalWidthIndex].ToString());
                information.TypeDetail = int.Parse(mgtObject[WMI_Indexes.MemoryBank_TypeDetailIndex].ToString());
                information.PositionInRow = mgtObject[WMI_Indexes.MemoryBank_PositionInRowIndex] == null ? -1 : int.Parse(mgtObject[WMI_Indexes.MemoryBank_PositionInRowIndex].ToString());
                information.FormFactor = (MemoryBankFormFactor) int.Parse(mgtObject[WMI_Indexes.MemoryBank_FormFactorIndex].ToString());
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
