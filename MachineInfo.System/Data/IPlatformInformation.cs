#region License information

/*

Copyright 2022 Bogdan Bara, Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using System.Collections;

namespace MachineInfo.System.Data
{
    public interface IPlatformInformation
    {
        /// <summary>
        /// A flag indicating the operating system is 64-bit
        /// </summary>
        bool Is64BitOperatingSystem { get; }

        /// <summary>
        /// The current machine name
        /// </summary>
        string MachineName { get; }

        /// <summary>
        /// The platform identifier
        /// </summary>
        PlatformID Platform { get; }

        /// <summary>
        /// The unstalled service pack
        /// </summary>
        string ServicePack { get; }

        /// <summary>
        /// The operating system version
        /// </summary>
        string Version { get; }

        /// <summary>
        /// The number of computer processors
        /// </summary>
        int ProcessorCount { get; }

        /// <summary>
        /// The list of logical drives
        /// </summary>
        string[] LogicalDrives { get; }

        /// <summary>
        /// A dictionary containing the list of enviroment variables
        /// </summary>
        IDictionary EnvironmentVariables { get; }

        /// <summary>
        /// CLR version
        /// </summary>
        string CLRVersion { get; }
    }
}
