#region License information

/*

Copyright 2019 Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using MachineInfo.System.Internal;
using System.Management;
using System.Text;

namespace MachineInfo.System.Information
{
    /// <summary>
    /// Class <see cref="DiskDriveInfo"/>
    /// <para />
    /// Captures the properties of the disk drives installed on the computer.
    /// It uses a subset of the properties defined in the WMI class: Win32_DiskDrive
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-diskdrive">Win32_DiskDrive</see>
    /// </summary>
    public class DiskDriveInfo
    {
        #region Public properties

        /// <summary>
        /// Disk drive identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Unique identifier of the disk drive with other devices on the system.
        /// </summary>
        public string DeviceID { get; set; }

        /// <summary>
        /// Manufacturer's model number of the disk drive.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Number allocated by the manufacturer to identify the physical media.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Number allocated by the manufacturer to identify the physical media.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Disk identification. This property can be used to identify a shared resource.
        /// </summary>
        public int Signature { get; set; }

        /// <summary>
        /// Current status of the object.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// State of the logical device. 
        /// </summary>
        public string StatusInfo { get; set; }

        /// <summary>
        /// Value of the scoping computer's CreationClassName property.
        /// </summary>
        public string SystemCreationClassName { get; set; }

        /// <summary>
        /// Name of the scoping system.
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Total number of cylinders on the physical disk drive.
        /// </summary>
        public long TotalCylinders { get; set; }

        /// <summary>
        /// Total number of heads on the disk drive.
        /// </summary>
        public long TotalHeads { get; set; }

        /// <summary>
        /// Total number of sectors on the physical disk drive.
        /// </summary>
        public long TotalSectors { get; set; }

        /// <summary>
        /// Total number of tracks on the physical disk drive.
        /// </summary>
        public long TotalTracks { get; set; }

        /// <summary>
        /// Size of the disk drive.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Maximum number of media which can be supported or inserted.
        /// </summary>
        public int NumberOfMediaSupported { get; set; }

        /// <summary>
        /// Number of partitions on this physical disk drive that are 
        /// recognized by the operating system.
        /// </summary>
        public int Partitions { get; set; }

        /// <summary>
        /// Number of tracks in each cylinder on the physical disk drive.
        /// </summary>
        public int TracksPerCylinder { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// This function parses the management object structure to extract the disk drive info fields.
        /// </summary>
        /// <param name="mgtObject">Management object containing the different disk drive info fields</param>
        /// <returns>returns 0 if success, -1 if an exception occured</returns>
        public int GetDiskDriveInfo(ManagementObject mgtObject)
        {
            try
            {
                Id = mgtObject[Indexes.DiskDrive_IdIndex].ToString();

                DeviceID = mgtObject[Indexes.DiskDrive_DeviceIDIndex].ToString();

                Model = mgtObject[Indexes.DiskDrive_ModelIndex].ToString();

                Manufacturer = mgtObject[Indexes.DiskDrive_ManufacturerIndex].ToString();

                SerialNumber = mgtObject[Indexes.DiskDrive_SerialNumberIndex].ToString().Trim();

                Status = mgtObject[Indexes.DiskDrive_StatusIndex].ToString();

                SystemCreationClassName = mgtObject[Indexes.DiskDrive_SystemCreationClassNameIndex].ToString();

                SystemName = mgtObject[Indexes.DiskDrive_SystemNameIndex].ToString();

                TotalCylinders = mgtObject[Indexes.DiskDrive_TotalCylindersIndex] == null ? -1 : long.Parse(mgtObject[Indexes.DiskDrive_TotalCylindersIndex].ToString());

                TotalHeads = mgtObject[Indexes.DiskDrive_TotalHeadsIndex] == null ? -1 : long.Parse(mgtObject[Indexes.DiskDrive_TotalHeadsIndex].ToString());

                TotalSectors = mgtObject[Indexes.DiskDrive_TotalSectorsIndex] == null ? -1 : long.Parse(mgtObject[Indexes.DiskDrive_TotalSectorsIndex].ToString());

                TotalTracks = mgtObject[Indexes.DiskDrive_TotalTracksIndex] == null ? -1 : long.Parse(mgtObject[Indexes.DiskDrive_TotalTracksIndex].ToString());

                Size = mgtObject[Indexes.DiskDrive_SizeIndex] == null ? -1 : long.Parse(mgtObject[Indexes.DiskDrive_SizeIndex].ToString());

                NumberOfMediaSupported = mgtObject[Indexes.DiskDrive_NumberOfMediaSupportedIndex] == null ? -1 : int.Parse(mgtObject[Indexes.DiskDrive_NumberOfMediaSupportedIndex].ToString());

                Partitions = mgtObject[Indexes.DiskDrive_PartitionsIndex] == null ? -1 : int.Parse(mgtObject[Indexes.DiskDrive_PartitionsIndex].ToString());

                StatusInfo = GetStatusInfo(mgtObject[Indexes.DiskDrive_StatusInfoIndex] == null ? -1 : int.Parse(mgtObject[Indexes.DiskDrive_StatusInfoIndex].ToString()));

                TracksPerCylinder = mgtObject[Indexes.DiskDrive_TracksPerCylinderIndex] == null ? -1 : int.Parse(mgtObject[Indexes.DiskDrive_TracksPerCylinderIndex].ToString());

                Signature = (mgtObject[Indexes.DiskDrive_SignatureIndex] == null) ? -1 : int.Parse(mgtObject[Indexes.DiskDrive_SignatureIndex].ToString());

                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Stringifies the properties of the CPUInfo class.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder str = new();

            str.Append($"Name: {Id}\n");

            if (Manufacturer != string.Empty)
                str.Append($"Manufacturer: {Manufacturer}\n");

            if (SerialNumber != string.Empty)
                str.Append($"SerialNumber: {SerialNumber}\n");

            if (Model != string.Empty)
                str.Append($"Model: {Model}\n");

            if (Size >= 0)
                str.Append($"Size (Bytes): {Size}\n");

            str.Append($"Partitions: {Partitions}\n");

            if (Status != string.Empty)
                str.Append($"Status: {Status}\n");

            return str.ToString();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// This functions converts the disk drive status from enumeration to string
        /// </summary>
        /// <param name="status">the disk drive status (int)</param>
        /// <returns>the disk drive status (string)</returns>
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
