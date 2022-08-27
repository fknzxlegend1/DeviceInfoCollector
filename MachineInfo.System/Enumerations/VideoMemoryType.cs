﻿#region License information

/*

Copyright 2019 Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

namespace MachineInfo.System.Enumerations
{
    /// <summary>
    /// Enumeration <see cref="VideoMemoryType"/>
    /// <para />
    /// An enumeration of video memory types as detailed in the class Win32-VideoController
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-videocontroller">win32-videocontroller</see>
    /// </summary>
    public enum VideoMemoryType
    {
        OTHER = 1, 
        UKNOWN = 2, 
        VRAM = 3, 
        DRAM = 4, 
        SRAM = 5, 
        WRAM = 6, 
        EDO_RAM = 7,
        Burst_Synchronous_DRAM = 8, 
        Pipelined_Burst_SRAM = 9, 
        CDRAM = 10, 
        _3DRAM = 11,
        SDRAM = 12, 
        SGRAM = 13
    }
}
