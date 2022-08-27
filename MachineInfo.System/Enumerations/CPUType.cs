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
    /// Enumeration <see cref="CPUType"/>
    /// <para />
    /// An enumeration of CPU types as detailed in the class Win32-Processor
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor">win32-processor</see>
    /// </summary>
    public enum CPUType 
    {
        NONE = -1,
        OTHER = 1, 
        UNKNOWN = 2, 
        CENTRAL_PROCESSOR = 3, 
        MATH_PROCESSOR = 4, 
        DSP_PROCESSOR = 5, 
        VIDEO_PROCESSOR = 6,
    }
}
