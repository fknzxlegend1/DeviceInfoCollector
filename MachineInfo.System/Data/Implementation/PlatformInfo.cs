#region License information

/*

Copyright 2022 Bogdan Bara, Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using System.Collections;

namespace MachineInfo.System.Data.Implementation
{
    internal class PlatformInfo : IPlatformInfo
    {
        /// <summary>
        /// A flag indicating the operating system is 64-bit
        /// </summary>
        public bool Is64BitOperatingSystem { get; set; }

        /// <summary>
        /// The current machine name
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// The operating system name
        /// </summary>
        public string OS { get; set; }

        /// <summary>
        /// The operating system version
        /// </summary>
        public string OSVersion { get; set; }

        /// <summary>
        /// The platform identifier
        /// </summary>
        public PlatformID Platform { get; set; }

        /// <summary>
        /// The unstalled service pack
        /// </summary>
        public string ServicePack { get; set; }

        /// <summary>
        /// The operating system version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The number of computer processors
        /// </summary>
        public int ProcessorCount { get; set; }

        /// <summary>
        /// The list of logical drives
        /// </summary>
        public string[] LogicalDrives { get; set; }

        /// <summary>
        /// A dictionary containing the list of enviroment variables
        /// </summary>
        public IDictionary EnvironmentVariables { get; set; }

        /// <summary>
        /// CLR version
        /// </summary>
        public string CLRVersion { get; set; }
    }
}
