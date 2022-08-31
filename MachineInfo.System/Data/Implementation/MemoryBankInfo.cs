#region License information

/*

Copyright 2022 Bogdan Bara, Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using MachineInfo.System.Enumerations;

namespace MachineInfo.System.Data.Implementation
{
    internal class MemoryBankInfo : IMemoryBankInfo
    {
        /// <summary>
        /// The memory bank info identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Physically labeled bank where the memory is located.
        /// </summary>
        public string BankLabel { get; set; }

        /// <summary>
        /// Data width of the physical memory—in bits.
        /// </summary>
        public int DataWidth { get; set; }

        /// <summary>
        /// Description of an object.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Label of the socket or circuit board that holds the memory.
        /// </summary>
        public string DeviceLocator { get; set; }

        /// <summary>
        /// Name of the organization responsible for producing the physical element.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Manufacturer-allocated number to identify the physical element.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Stock keeping unit number for the physical element.
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// The raw SMBIOS memory type. 
        /// </summary>
        public int SMBIOSMemoryType { get; set; }

        /// <summary>
        /// Speed of the physical memory—in nanoseconds.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Current status of the object. 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Name for the physical element.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Additional data, beyond asset tag information, that can be used to identify a physical element.
        /// </summary>
        public string OtherIdentifyingInfo { get; set; }

        /// <summary>
        /// Part number assigned by the organization responsible for producing or manufacturing the physical element.
        /// </summary>
        public string PartNumber { get; set; }

        /// <summary>
        /// Unique identifier for the physical memory device that is represented by an instance of Win32_PhysicalMemory. 
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Total width, in bits, of the physical memory, including check or error correction bits. 
        /// </summary>
        public int TotalWidth { get; set; }

        /// <summary>
        /// Type of physical memory represented.
        /// </summary>
        public int TypeDetail { get; set; }

        /// <summary>
        /// Version of the physical element.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Position of the physical memory in a row.
        /// </summary>
        public int PositionInRow { get; set; }

        /// <summary>
        /// Implementation form factor for the chip.
        /// </summary>
        public MemoryBankFormFactor FormFactor { get; set; }

        /// <summary>
        /// Total capacity of the physical memory—in bytes.
        /// </summary>
        public long Capacity { get; set; }
    }
}
