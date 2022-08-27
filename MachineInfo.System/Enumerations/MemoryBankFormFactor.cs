#region License information

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
    /// Enumeration <see cref="MemoryBankFormFactor"/>
    /// <para />
    /// An enumeration of memory bank form factors as detailed in the class Win32-PhysicalMemory
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-physicalmemory">win32-physicalmemory</see>
    /// </summary>
    public enum MemoryBankFormFactor
    {
        UNKNOWN = 0, 
        OTHER = 1, 
        SIP = 2, 
        DIP = 3, 
        ZIP = 4, 
        SOJ = 5, 
        PROPRIETARY = 6, 
        SIMM = 7, 
        DIMM = 8, 
        TSOP = 9,
        PGA = 10, 
        RIMM = 11, 
        SODIMM = 12, 
        SRIMM = 13, 
        SMD = 14, 
        SSMP = 15, 
        QFP = 16, 
        TQFP = 17, 
        SOIC = 18, 
        LCC = 19,
        PLCC = 20, 
        BGA = 21, 
        FPBGA = 22, 
        LGA = 23
    }
}
