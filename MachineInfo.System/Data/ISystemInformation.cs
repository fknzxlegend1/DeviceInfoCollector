#region License information

/*

Copyright 2022 Bogdan Bara, Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

namespace MachineInfo.System.Data
{
    public interface ISystemInformation
    {
        /// <summary>
        /// The platform information
        /// </summary>
        IPlatformInformation Platform { get; }

        /// <summary>
        /// General information about installed memory
        /// </summary>
        IMemoryInformation Memory { get; }

        /// <summary>
        /// List of system CPUs
        /// </summary>
        List<ICPUInformation> CPUs { get; }

        /// <summary>
        /// List of memory banks information
        /// </summary>
        List<IMemoryBankInformation> MemoryBanks { get; }

        /// <summary>
        /// List of video controller information
        /// </summary>
        List<IVideoControllerInformation> VideoControllers { get; }

        /// <summary>
        /// List of disk drives information
        /// </summary>
        List<IDiskDriveInformation> DiskDrives { get; }

        /// <summary>
        /// List of disk partitions' information
        /// </summary>
        List<IDiskPartitionInformation> DiskPartitions { get; }
    }
}
