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
    internal class CPUInfo : ICPUInfo
    {
        /// <summary>
        /// CPU identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// On a 32-bit operating system, the value is 32 and on a 64-bit operating system it is 64.
        /// </summary>
        public int AddressWidth { get; set; }

        /// <summary>
        /// Processor architecture used by the platform.
        /// </summary>
        public CPUArchitecture Architecture { get; set; }

        /// <summary>
        /// Current status of the processor. Status changes indicate processor usage, 
        /// but not the physical condition of the processor.
        /// </summary>
        public CPUStatus CpuStatus { get; set; }

        /// <summary>
        /// On a 32-bit processor, the value is 32 and on a 64-bit processor it is 64.
        /// </summary>
        public int DataWidth { get; set; }

        /// <summary>
        /// Unique identifier of a processor on the system.
        /// </summary>
        public string DeviceID { get; set; }

        /// <summary>
        /// Processor family type.
        /// </summary>
        public CPUFamily Family { get; set; }

        /// <summary>
        /// Name of the processor manufacturer.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Maximum speed of the processor, in MHz.
        /// </summary>
        public int MaxClockSpeed { get; set; }

        /// <summary>
        /// The part number of this processor as set by the manufacturer.
        /// </summary>
        public string PartNumber { get; set;  }

        /// <summary>
        /// The serial number of this processor This value is set by the manufacturer and normally not changeable.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Globally unique identifier for the processor. This identifier may only be unique within a processor family.
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// Primary function of the processor.
        /// </summary>
        public int ProcessorType { get; set; }

        /// <summary>
        /// Processor information that describes the processor features.
        /// </summary>
        public string ProcessorId { get; set; }

        /// <summary>
        /// Load capacity of each processor, averaged to the last second. 
        /// Processor loading refers to the total computing burden for each 
        /// processor at one time.
        /// </summary>
        public int LoadPercentage { get; set; }

        /// <summary>
        /// Current speed of the processor, in MHz.
        /// </summary>
        public int CurrentClockSpeed { get; set; }

        /// <summary>
        /// Voltage of the processor. 
        /// </summary>
        public CPUVoltage CurrentVoltage { get; set; }

        /// <summary>
        /// Number of cores for the current instance of the processor. 
        /// A core is a physical processor on the integrated circuit. 
        /// </summary>
        public int NumberOfCores { get; set; }

        /// <summary>
        /// The number of enabled cores per processor socket.
        /// </summary>
        public int NumberOfEnabledCore { get; set; }

        /// <summary>
        /// Number of logical processors for the current instance of the processor. 
        /// For processors capable of hyperthreading, this value includes only the 
        /// processors which have hyperthreading enabled.
        /// </summary>
        public int NumberOfLogicalProcessors { get; set; }

        /// <summary>
        /// System revision level that depends on the architecture. 
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Size of the Level 2 processor cache. A Level 2 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public int L2CacheSize { get; set; }

        /// <summary>
        /// Clock speed of the Level 2 processor cache. A Level 2 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public int L2CacheSpeed { get; set; }

        /// <summary>
        /// Size of the Level 3 processor cache. A Level 3 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public int L3CacheSize { get; set; }

        /// <summary>
        /// Clockspeed of the Level 3 property cache. A Level 3 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        public int L3CacheSpeed { get; set; }

        /// <summary>
        /// The number of threads per processor socket.
        /// </summary>
        public int ThreadCount { get; set; }

        /// <summary>
        /// If True, the Firmware has enabled virtualization extensions.
        /// </summary>
        public string VirtualizationFirmwareEnabled { get; set; }
    }
}
