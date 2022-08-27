#region License information

/*

Copyright 2019 Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using System.Text;

namespace MachineInfo.System.Information
{
    /// <summary>
    /// \class MemoryInfo 
    /// Provides an overview about the overall memory installed on the computer.
    /// <seealso cref="MemoryBankInfo">
    /// </summary>
    public class MemoryInfo
    {
        #region Public properties

        /// <summary>
        /// Number of computer memory banks
        /// </summary>
        public int NoOfMemoryBanks { get; set; }

        /// <summary>
        /// The data width of the memory banks
        /// </summary>
        public int DataWidth { get; set; }

        /// <summary>
        /// The total memory size in bytes
        /// </summary>
        public long TotalSize { get; set; }

        /// <summary>
        /// The total memory size in mega-bytes
        /// </summary>
        public long TotalSizeMegaBytes { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// It uses the information provided in a list of MemoryBankInfo instances in order to set the properties
        /// of the MemoryInfo class
        /// </summary>
        /// <param name="banks">List of memory bank info instances (List<MemoryBankInfo>)</param>
        /// <returns>0 if success, -1 if exception and -2 if input is null</returns>
        public int GetMemoryInfo(List<MemoryBankInfo> banks)
        {
            try
            {
                if (banks == null)
                    return -2;

                NoOfMemoryBanks = banks.Count;
                DataWidth = banks[0].DataWidth;

                long size = 0;
                foreach (var item in banks)
                {
                    size += item.Capacity;
                }

                TotalSize = size;
                TotalSizeMegaBytes = size / (1024 * 1024);

                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Stringifies the properties of the MemoryInfo class.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder str = new();

            str.Append($"Number of Memory Banks: {NoOfMemoryBanks}\n");
            str.Append($"Memory Data Width: {DataWidth}\n");
            str.Append($"Memory Total Size (Bytes): {TotalSize}\n");
            str.Append($"Memory Total Size (MegaBytes): {TotalSizeMegaBytes}\n");

            return str.ToString();
        }

        #endregion
    }
}
