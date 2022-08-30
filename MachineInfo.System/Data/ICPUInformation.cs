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
    public interface ICPUInformation
    {
        /// <summary>
        /// CPU identifier
        /// </summary>
        string Id { get; }

        /// <summary>
        /// On a 32-bit operating system, the value is 32 and on a 64-bit operating system it is 64.
        /// </summary>
        int AddressWidth { get; }

        /// <summary>
        /// Processor architecture used by the platform.
        /// </summary>
        CPUArchitecture Architecture { get; }

        /// <summary>
        /// Current status of the processor. Status changes indicate processor usage, 
        /// but not the physical condition of the processor.
        /// </summary>
        CPUStatus CpuStatus { get; }

        /// <summary>
        /// On a 32-bit processor, the value is 32 and on a 64-bit processor it is 64.
        /// </summary>
        int DataWidth { get; }

        /// <summary>
        /// Unique identifier of a processor on the system.
        /// </summary>
        string DeviceID { get; }

        /// <summary>
        /// Processor family type.
        /// </summary>
        CPUFamily Family { get; }

        /// <summary>
        /// Name of the processor manufacturer.
        /// </summary>
        string Manufacturer { get; }

        /// <summary>
        /// Maximum speed of the processor, in MHz.
        /// </summary>
        int MaxClockSpeed { get; }

        /// <summary>
        /// The part number of this processor as set by the manufacturer.
        /// </summary>
        string PartNumber { get; }

        /// <summary>
        /// The serial number of this processor This value is set by the manufacturer and normally not changeable.
        /// </summary>
        string SerialNumber { get; }

        /// <summary>
        /// Globally unique identifier for the processor. This identifier may only be unique within a processor family.
        /// </summary>
        string UniqueId { get; }

        /// <summary>
        /// Primary function of the processor.
        /// </summary>
        int ProcessorType { get; }

        /// <summary>
        /// Processor information that describes the processor features.
        /// </summary>
        string ProcessorId { get; }

        /// <summary>
        /// Load capacity of each processor, averaged to the last second. 
        /// Processor loading refers to the total computing burden for each 
        /// processor at one time.
        /// </summary>
        int LoadPercentage { get; }

        /// <summary>
        /// Current speed of the processor, in MHz.
        /// </summary>
        int CurrentClockSpeed { get; }

        /// <summary>
        /// Voltage of the processor. 
        /// </summary>
        CPUVoltage CurrentVoltage { get; }

        /// <summary>
        /// Number of cores for the current instance of the processor. 
        /// A core is a physical processor on the integrated circuit. 
        /// </summary>
        int NumberOfCores { get; }

        /// <summary>
        /// The number of enabled cores per processor socket.
        /// </summary>
        int NumberOfEnabledCore { get; }

        /// <summary>
        /// Number of logical processors for the current instance of the processor. 
        /// For processors capable of hyperthreading, this value includes only the 
        /// processors which have hyperthreading enabled.
        /// </summary>
        int NumberOfLogicalProcessors { get; }

        /// <summary>
        /// System revision level that depends on the architecture. 
        /// </summary>
        int Level { get; }

        /// <summary>
        /// Size of the Level 2 processor cache. A Level 2 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        int L2CacheSize { get; }

        /// <summary>
        /// Clock speed of the Level 2 processor cache. A Level 2 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        int L2CacheSpeed { get; }

        /// <summary>
        /// Size of the Level 3 processor cache. A Level 3 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        int L3CacheSize { get; }

        /// <summary>
        /// Clockspeed of the Level 3 property cache. A Level 3 cache is an external 
        /// memory area that has a faster access time than the main RAM memory.
        /// </summary>
        int L3CacheSpeed { get; }

        /// <summary>
        /// The number of threads per processor socket.
        /// </summary>
        int ThreadCount { get; }

        /// <summary>
        /// If True, the Firmware has enabled virtualization extensions.
        /// </summary>
        string VirtualizationFirmwareEnabled { get; }
    }
}
