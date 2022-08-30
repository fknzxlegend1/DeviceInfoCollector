#region License information

/*

Copyright 2022 Bogdan Bara, Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

namespace MachineInfo.System.Data.Implementation
{
    internal class DiskPartitionInformation : IDiskPartitionInformation
    {
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
    }
}
