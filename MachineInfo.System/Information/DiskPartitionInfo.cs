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
    /// Class <see cref="DiskPartitionInfo"/>
    /// <para />
    /// Captures the properties of the disk partitions installed on the computer.
    /// It uses a subset of the properties defined in the WMI class: Win32_DiskPartition
    /// <para />
    /// For more information, <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-diskpartition">Win32_DiskPartition</see>
    /// </summary>
    public class DiskPartitionInfo
    {
        #region Public properties

        /// <summary>
        /// The disk partition identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Unique identifier of the disk drive and partition, from the rest of the system.
        /// </summary>
        public string DeviceID { get; set; }

        /// <summary>
        /// Total size of the partition.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Total number of consecutive blocks, each block the size of the value contained 
        /// in the BlockSize property, which form this storage extent.
        /// </summary>
        public long NumberOfBlocks { get; set; }

        /// <summary>
        /// Current status of the object. 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// State of the logical device.
        /// </summary>
        public string StatusInfo { get; set; }

        /// <summary>
        /// Creation class name of the scoping system.
        /// </summary>
        public string SystemCreationClassName { get; set; }

        /// <summary>
        /// Name of the scoping system.
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Type of the partition.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Indicates whether the computer can be booted from this partition.
        /// </summary>
        public bool? Bootable { get; set; }

        /// <summary>
        /// Partition is the active partition. The operating system uses the active 
        /// partition when booting from a hard disk.
        /// </summary>
        public bool? BootPartition { get; set; }

        /// <summary>
        /// If True, this is the primary partition.
        /// </summary>
        public bool? PrimaryPartition { get; set; }

        /// <summary>
        /// If True, the partition information has changed.
        /// </summary>
        public bool? RewritePartition { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// This function parses the management object structure to extract the disk partition fields.
        /// </summary>
        /// <param name="mgtObject">Management object containing the different disk partition fields</param>
        /// <returns>returns 0 if success, -1 if an exception occured</returns>
        public int GetDiskPartitionInfo(ManagementObject mgtObject)
        {
            try
            {
                Id = mgtObject[Indexes.DiskPartition_IdIndex].ToString();

                DeviceID = mgtObject[Indexes.DiskPartition_DeviceIDIndex].ToString();

                Size = mgtObject[Indexes.DiskPartition_SizeIndex] != null ? long.Parse(mgtObject[Indexes.DiskPartition_SizeIndex].ToString()) : -1;

                NumberOfBlocks = mgtObject[Indexes.DiskPartition_NumberOfBlocksIndex] != null ? long.Parse(mgtObject[Indexes.DiskPartition_NumberOfBlocksIndex].ToString()) : -1;

                Status = mgtObject[Indexes.DiskPartition_StatusIndex] != null ? mgtObject[Indexes.DiskPartition_StatusIndex].ToString() : string.Empty;

                SystemCreationClassName = mgtObject[Indexes.DiskPartition_SystemCreationClassNameIndex].ToString();

                SystemName = mgtObject[Indexes.DiskPartition_SystemNameIndex].ToString();

                SystemName = mgtObject[Indexes.DiskPartition_TypeIndex].ToString();

                if (mgtObject[Indexes.DiskPartition_BootableIndex] != null)
                {
                    var success = bool.TryParse(mgtObject[Indexes.DiskPartition_BootableIndex].ToString(), out bool temp);
                    Bootable = success ? temp : null;
                }

                if (mgtObject[Indexes.DiskPartition_BootPartitionIndex] != null)
                {
                    var success = bool.TryParse(mgtObject[Indexes.DiskPartition_BootPartitionIndex].ToString(), out bool temp);
                    BootPartition = success ? temp : null;
                }

                if (mgtObject[Indexes.DiskPartition_PrimaryPartitionIndex] != null)
                {
                    var success = bool.TryParse(mgtObject[Indexes.DiskPartition_PrimaryPartitionIndex].ToString(), out bool temp);
                    PrimaryPartition = success ? temp : null;
                }

                if (mgtObject[Indexes.DiskPartition_RewritePartitionIndex] != null)
                {
                    var success = bool.TryParse(mgtObject[Indexes.DiskPartition_RewritePartitionIndex].ToString(), out bool temp);
                    RewritePartition = success ? temp : null;
                }

                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Stringifies the properties of the DiskPartition class.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder str = new();

            str.Append($"Name: {Id}\n");
            str.Append($"Size (Bytes): {Size}\n");
            str.Append($"Number Of Blocks: {NumberOfBlocks}\n");

            if (Status != string.Empty)
                str.Append($"Partition Status: {Status}\n");

            str.Append($"Primary Partition: {PrimaryPartition}\n");

            return str.ToString();
        }

        #endregion
    }
}
