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
