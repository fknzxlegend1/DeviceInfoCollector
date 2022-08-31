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
    internal class SystemInfo : ISystemInfo
    {
        /// <summary>
        /// The platform information
        /// </summary>
        public IPlatformInfo Platform { get; set; }

        /// <summary>
        /// General information about installed memory
        /// </summary>
        public IMemoryInfo Memory { get; set; }

        /// <summary>
        /// List of system CPUs
        /// </summary>
        public List<ICPUInfo> CPUs { get; } = new();

        /// <summary>
        /// List of memory banks information
        /// </summary>
        public List<IMemoryBankInfo> MemoryBanks { get; } = new();

        /// <summary>
        /// List of video controller information
        /// </summary>
        public List<IVideoControllerInfo> VideoControllers { get; } = new();

        /// <summary>
        /// List of disk drives information
        /// </summary>
        public List<IDiskDriveInfo> DiskDrives { get; } = new();

        /// <summary>
        /// List of disk partitions' information
        /// </summary>
        public List<IDiskPartitionInfo> DiskPartitions { get; } = new();
    }
}
