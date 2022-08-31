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
    internal class DiskDriveInfo : IDiskDriveInfo
    {
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
    }
}
