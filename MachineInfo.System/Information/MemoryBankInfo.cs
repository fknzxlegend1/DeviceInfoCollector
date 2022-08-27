using MachineInfo.System.Enumerations;
using MachineInfo.System.Internal;
using System.Management;

namespace MachineInfo.System.Information
{
    /// <summary>
    /// Class <see cref="MemoryBankInfo"/>
    /// <para />
    /// Captures the main properties of a MemoryBankInfo structure.
    /// It uses a subset of the properties defined in the WMI class: Win32_PhysicalMemory
    /// <para />
    /// For more information, <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-physicalmemory">Win32_PhysicalMemory class</see>
    /// </summary>
    public class MemoryBankInfo
    {
        #region Public properties

        /// <summary>
        /// The memory bank info identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Physically labeled bank where the memory is located.
        /// </summary>
        public string BankLabel { get; set; }

        /// <summary>
        /// Data width of the physical memory—in bits.
        /// </summary>
        public int DataWidth { get; set; }

        /// <summary>
        /// Description of an object.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Label of the socket or circuit board that holds the memory.
        /// </summary>
        public string DeviceLocator { get; set; }

        /// <summary>
        /// Name of the organization responsible for producing the physical element.
        /// </summary>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Manufacturer-allocated number to identify the physical element.
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// Stock keeping unit number for the physical element.
        /// </summary>
        public string SKU { get; set; }

        /// <summary>
        /// The raw SMBIOS memory type. 
        /// </summary>
        public int SMBIOSMemoryType { get; set; }

        /// <summary>
        /// Speed of the physical memory—in nanoseconds.
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// Current status of the object. 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Name for the physical element.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Additional data, beyond asset tag information, that can be used to identify a physical element.
        /// </summary>
        public string OtherIdentifyingInfo { get; set; }

        /// <summary>
        /// Part number assigned by the organization responsible for producing or manufacturing the physical element.
        /// </summary>
        public string PartNumber { get; set; }

        /// <summary>
        /// Unique identifier for the physical memory device that is represented by an instance of Win32_PhysicalMemory. 
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// Total width, in bits, of the physical memory, including check or error correction bits. 
        /// </summary>
        public int TotalWidth { get; set; }

        /// <summary>
        /// Type of physical memory represented.
        /// </summary>
        public int TypeDetail { get; set; }

        /// <summary>
        /// Version of the physical element.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Position of the physical memory in a row.
        /// </summary>
        public int PositionInRow { get; set; }

        /// <summary>
        /// Implementation form factor for the chip.
        /// </summary>
        public MemoryBankFormFactor FormFactor { get; set; }

        /// <summary>
        /// Total capacity of the physical memory—in bytes.
        /// </summary>
        public long Capacity { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// This function parses the management object structure to extract the memory bank info fields.
        /// </summary>
        /// <param name="mgtObject">Management object containing the different memory bank info fields</param>
        /// <returns>returns 0 if success, -1 if an exception occured</returns>
        public int GetMemInfo(ManagementObject mgtObject)
        {
            try
            {
                Capacity = long.Parse(mgtObject[Indexes.MemoryBank_CapacityIndex].ToString());

                Id = mgtObject[Indexes.MemoryBank_IdIndex] != null ? mgtObject[Indexes.MemoryBank_IdIndex].ToString() : string.Empty;

                BankLabel = mgtObject[Indexes.MemoryBank_BankLabelIndex] == null ? string.Empty : mgtObject[Indexes.MemoryBank_BankLabelIndex].ToString();

                Description = mgtObject[Indexes.MemoryBank_DescriptionIndex] != null ? mgtObject[Indexes.MemoryBank_DescriptionIndex].ToString() : string.Empty;

                DeviceLocator = mgtObject[Indexes.MemoryBank_DeviceLocatorIndex] != null ? mgtObject[Indexes.MemoryBank_DeviceLocatorIndex].ToString() : string.Empty;

                Manufacturer = mgtObject[Indexes.MemoryBank_ManufacturerIndex] != null ? mgtObject[Indexes.MemoryBank_ManufacturerIndex].ToString() : string.Empty;

                SerialNumber = mgtObject[Indexes.MemoryBank_SerialNumberIndex].ToString();

                SKU = mgtObject[Indexes.MemoryBank_SKUIndex] != null ? mgtObject[Indexes.MemoryBank_SKUIndex].ToString() : string.Empty;

                Status = mgtObject[Indexes.MemoryBank_StatusIndex] != null ? mgtObject[Indexes.MemoryBank_StatusIndex].ToString() : string.Empty;

                Model = mgtObject[Indexes.MemoryBank_ModelIndex] != null ? mgtObject[Indexes.MemoryBank_ModelIndex].ToString() : string.Empty;

                OtherIdentifyingInfo = mgtObject[Indexes.MemoryBank_OtherIdentifyingInfoIndex] != null ? mgtObject[Indexes.MemoryBank_OtherIdentifyingInfoIndex].ToString() : string.Empty;

                PartNumber = mgtObject[Indexes.MemoryBank_PartNumberIndex] != null ? mgtObject[Indexes.MemoryBank_PartNumberIndex].ToString() : string.Empty;

                DataWidth = int.Parse(mgtObject[Indexes.MemoryBank_DataWidthIndex].ToString());

                Speed = int.Parse(mgtObject[Indexes.MemoryBank_SpeedIndex].ToString());

                SMBIOSMemoryType = int.Parse(mgtObject[Indexes.MemoryBank_SMBIOSMemoryTypeIndex].ToString());

                Tag = mgtObject[Indexes.MemoryBank_TagIndex] == null ? string.Empty : mgtObject[Indexes.MemoryBank_TagIndex].ToString();

                Version = mgtObject[Indexes.MemoryBank_VersionIndex] == null ? string.Empty : mgtObject[Indexes.MemoryBank_VersionIndex].ToString();

                TotalWidth = int.Parse(mgtObject[Indexes.MemoryBank_TotalWidthIndex].ToString());

                TypeDetail = int.Parse(mgtObject[Indexes.MemoryBank_TypeDetailIndex].ToString());

                PositionInRow = mgtObject[Indexes.MemoryBank_PositionInRowIndex] == null ? -1 : int.Parse(mgtObject[Indexes.MemoryBank_PositionInRowIndex].ToString());

                FormFactor = GetMemBankFormFactor(int.Parse(mgtObject[Indexes.MemoryBank_FormFactorIndex].ToString()));

                return 0;
            }
            catch
            {
                return -1;
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// This functions converts the memory bank form factor from enumeration to string
        /// </summary>
        /// <param name="formfactor">the memory bank form factor (int)</param>
        /// <returns>the memory bank form factor (string)</returns>
        private static MemoryBankFormFactor GetMemBankFormFactor(int formfactor)
        {
            return (MemoryBankFormFactor)formfactor;
        }

        #endregion
    }
}
