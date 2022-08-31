#region License information

/*

Copyright 2022 Bogdan Bara, Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using MachineInfo.System.Enumerations;

namespace MachineInfo.System.Data
{
    public interface IMemoryBankInfo
    {
        /// <summary>
        /// The memory bank info identifier
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Physically labeled bank where the memory is located.
        /// </summary>
        string BankLabel { get; }

        /// <summary>
        /// Data width of the physical memory—in bits.
        /// </summary>
        int DataWidth { get; }

        /// <summary>
        /// Description of an object.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Label of the socket or circuit board that holds the memory.
        /// </summary>
        string DeviceLocator { get; }

        /// <summary>
        /// Name of the organization responsible for producing the physical element.
        /// </summary>
        string Manufacturer { get; }

        /// <summary>
        /// Manufacturer-allocated number to identify the physical element.
        /// </summary>
        string SerialNumber { get; }

        /// <summary>
        /// Stock keeping unit number for the physical element.
        /// </summary>
        string SKU { get; }

        /// <summary>
        /// The raw SMBIOS memory type. 
        /// </summary>
        int SMBIOSMemoryType { get; }

        /// <summary>
        /// Speed of the physical memory—in nanoseconds.
        /// </summary>
        int Speed { get; }

        /// <summary>
        /// Current status of the object. 
        /// </summary>
        string Status { get; }

        /// <summary>
        /// Name for the physical element.
        /// </summary>
        string Model { get; }

        /// <summary>
        /// Additional data, beyond asset tag information, that can be used to identify a physical element.
        /// </summary>
        string OtherIdentifyingInfo { get; }

        /// <summary>
        /// Part number assigned by the organization responsible for producing or manufacturing the physical element.
        /// </summary>
        string PartNumber { get; }

        /// <summary>
        /// Unique identifier for the physical memory device that is represented by an instance of Win32_PhysicalMemory. 
        /// </summary>
        string Tag { get; }

        /// <summary>
        /// Total width, in bits, of the physical memory, including check or error correction bits. 
        /// </summary>
        int TotalWidth { get; }

        /// <summary>
        /// Type of physical memory represented.
        /// </summary>
        int TypeDetail { get; }

        /// <summary>
        /// Version of the physical element.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Position of the physical memory in a row.
        /// </summary>
        int PositionInRow { get; }

        /// <summary>
        /// Implementation form factor for the chip.
        /// </summary>
        MemoryBankFormFactor FormFactor { get; }

        /// <summary>
        /// Total capacity of the physical memory—in bytes.
        /// </summary>
        long Capacity { get; }
    }
}
