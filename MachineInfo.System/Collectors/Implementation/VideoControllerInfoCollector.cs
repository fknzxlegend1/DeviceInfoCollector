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

namespace MachineInfo.System.Collectors.Implementation
{
    internal class VideoControllerInfoCollector : IVideoControllerInfoCollector
    {
        private readonly ManagementObjectSearcher managementObjectSearcher;

        public VideoControllerInfoCollector()
        {
            managementObjectSearcher = new("SELECT * FROM Win32_VideoController");
        }

        public IEnumerable<IVideoControllerInfo> Collect()
        {
            var data = new List<IVideoControllerInfo>();

            var collection = managementObjectSearcher.Get().OfType<ManagementObject>();
            foreach (var item in collection)
            {
                var information = CollectVideoControllerInformatioN(item);

                if (information == null)
                    continue;

                data.Add(information);
            }

            return data;
        }

        #region Private methods

        private static IVideoControllerInfo CollectVideoControllerInformatioN(ManagementObject mgtObject)
        {
            VideoControllerInfo information = new();

            try
            {
                information.CurrentBitsPerPixel = mgtObject[WMI_Indexes.VideoController_CurrentBitsPerPixelIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_CurrentBitsPerPixelIndex].ToString()) : -1;
                information.CurrentHorizontalResolution = mgtObject[WMI_Indexes.VideoController_CurrentHorizontalResolutionIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_CurrentHorizontalResolutionIndex].ToString()) : -1;
                information.CurrentNumberOfColors = mgtObject[WMI_Indexes.VideoController_CurrentNumberOfColorsIndex] != null ? long.Parse(mgtObject[WMI_Indexes.VideoController_CurrentNumberOfColorsIndex].ToString()) : -1;
                information.CurrentNumberOfColumns = mgtObject[WMI_Indexes.VideoController_CurrentNumberOfColumnsIndex] != null ? long.Parse(mgtObject[WMI_Indexes.VideoController_CurrentNumberOfColumnsIndex].ToString()) : -1;
                information.CurrentNumberOfRows = mgtObject[WMI_Indexes.VideoController_CurrentNumberOfRowsIndex] != null ? long.Parse(mgtObject[WMI_Indexes.VideoController_CurrentNumberOfRowsIndex].ToString()) : -1;
                information.CurrentRefreshRate = mgtObject[WMI_Indexes.VideoController_CurrentRefreshRateIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_CurrentRefreshRateIndex].ToString()) : -1;
                information.CurrentScanMode = mgtObject[WMI_Indexes.VideoController_CurrentScanModeIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_CurrentScanModeIndex].ToString()) : -1;
                information.CurrentVerticalResolution = mgtObject[WMI_Indexes.VideoController_CurrentVerticalResolutionIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_CurrentVerticalResolutionIndex].ToString()) : -1;
                information.DeviceSpecificPens = mgtObject[WMI_Indexes.VideoController_DeviceSpecificPensIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_DeviceSpecificPensIndex].ToString()) : -1;
                information.DitherType = mgtObject[WMI_Indexes.VideoController_DitherTypeIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_DitherTypeIndex].ToString()) : -1;
                information.Id = mgtObject[WMI_Indexes.VideoController_IdIndex].ToString();
                information.VideoModeDescription = mgtObject[WMI_Indexes.VideoController_VideoModeDescriptionIndex].ToString();
                information.VideoProcessor = mgtObject[WMI_Indexes.VideoController_VideoProcessorIndex].ToString();
                information.SystemName = mgtObject[WMI_Indexes.VideoController_SystemNameIndex].ToString();
                information.Description = mgtObject[WMI_Indexes.VideoController_DescriptionIndex].ToString();
                information.Status = mgtObject[WMI_Indexes.VideoController_StatusIndex].ToString();
                information.AdapterRAM = mgtObject[WMI_Indexes.VideoController_AdapterRAMIndex] != null ? long.Parse(mgtObject[WMI_Indexes.VideoController_AdapterRAMIndex].ToString()) : -1;
                information.ColorTableEntries = mgtObject[WMI_Indexes.VideoController_ColorTableEntriesIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_ColorTableEntriesIndex].ToString()) : -1;
                information.AdapterDACType = mgtObject[WMI_Indexes.VideoController_AdapterDACTypeIndex] != null ? mgtObject[WMI_Indexes.VideoController_AdapterDACTypeIndex].ToString() : string.Empty;
                information.LastErrorCode = mgtObject[WMI_Indexes.VideoController_LastErrorCodeIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_LastErrorCodeIndex].ToString()) : -1;
                information.MaxMemorySupported = mgtObject[WMI_Indexes.VideoController_MaxMemorySupportedIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_MaxMemorySupportedIndex].ToString()) : -1;
                information.MaxNumberControlled = mgtObject[WMI_Indexes.VideoController_MaxNumberControlledIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_MaxNumberControlledIndex].ToString()) : -1;
                information.MaxRefreshRate = mgtObject[WMI_Indexes.VideoController_MaxRefreshRateIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_MaxRefreshRateIndex].ToString()) : -1;
                information.MinRefreshRate = mgtObject[WMI_Indexes.VideoController_MinRefreshRateIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_MinRefreshRateIndex].ToString()) : -1;
                information.VideoArchitecture = (VideoArchitecture)(mgtObject[WMI_Indexes.VideoController_VideoArchitectureIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_VideoArchitectureIndex].ToString()) : 2);
                information.VideoMemoryType = (VideoMemoryType)(mgtObject[WMI_Indexes.VideoController_VideoMemoryTypeIndex] == null ? int.Parse(mgtObject[WMI_Indexes.VideoController_VideoMemoryTypeIndex].ToString()) : 2);
                information.VideoMode = mgtObject[WMI_Indexes.VideoController_VideoModeIndex] != null ? int.Parse(mgtObject[WMI_Indexes.VideoController_VideoModeIndex].ToString()) : -1;

                string str = mgtObject[WMI_Indexes.VideoController_DriverDateIndex].ToString().TrimEnd();

                information.DriverDate = string.Empty;
                if (!string.IsNullOrWhiteSpace(str))
                {
                    int year = int.Parse(str.Substring(0, 4));
                    int month = int.Parse(str.Substring(4, 2));
                    int day = int.Parse(str.Substring(6, 2));

                    int hour = int.Parse(str.Substring(8, 2));
                    int minute = int.Parse(str.Substring(10, 2));
                    int second = int.Parse(str.Substring(12, 2));

                    DateTime date = new(year, month, day, hour, minute, second);

                    information.DriverDate = date.ToString();
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
