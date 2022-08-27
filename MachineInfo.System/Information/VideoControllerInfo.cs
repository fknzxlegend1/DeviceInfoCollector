using MachineInfo.System.Enumerations;
using MachineInfo.System.Internal;
using System.Management;
using System.Text;

namespace MachineInfo.System.Information
{
    /// <summary>
    /// \class VideoControllerInfo 
    /// captures the main properties of a video controller.
    /// It uses a subset of the properties defined in the WMI class: Win32_VideoController
    /// For more information, <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-videocontroller">Win32_PhysicalMemory class</see>
    /// </summary>
    public class VideoControllerInfo
    {
        #region Public properties

        /// <summary>
        /// Video controller identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Current resolution, color, and scan mode settings of the video controller.
        /// </summary>
        public string VideoModeDescription { get; set; }

        /// <summary>
        /// Free-form string describing the video processor.
        /// </summary>
        public string VideoProcessor { get; set; }

        /// <summary>
        /// Name of the scoping system.
        /// </summary>
        public string SystemName { get; set; }

        /// <summary>
        /// Description of the object.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Current status of the object. Various operational and nonoperational statuses can be defined.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Memory size of the video adapter.
        /// </summary>
        public int AdapterRAM { get; set; }

        /// <summary>
        /// Size of the system's color table. The device must have a color depth of 
        /// no more than 8 bits per pixel; otherwise, this property is not set.
        /// </summary>
        public int ColorTableEntries { get; set; }

        /// <summary>
        /// Name or identifier of the digital-to-analog converter (DAC) chip. 
        /// The character set of this property is alphanumeric.
        /// </summary>
        public string AdapterDACType { get; set; }

        /// <summary>
        /// Last error code reported by the logical device.
        /// </summary>
        public int LastErrorCode { get; set; }

        /// <summary>
        /// Maximum amount of memory supported in bytes.
        /// </summary>
        public int MaxMemorySupported { get; set; }

        /// <summary>
        /// Maximum number of directly addressable entities supportable by this controller.
        /// A value of 0 (zero) should be used if the number is unknown.
        /// </summary>
        public int MaxNumberControlled { get; set; }

        /// <summary>
        /// Maximum refresh rate of the video controller in hertz.
        /// </summary>
        public int MaxRefreshRate { get; set; }

        /// <summary>
        /// Minimum refresh rate of the video controller in hertz.
        /// </summary>
        public int MinRefreshRate { get; set; }

        /// <summary>
        /// Type of video architecture.
        /// </summary>
        public VideoArchitecture VideoArchitecture { get; set; }

        /// <summary>
        /// Type of video memory.
        /// </summary>
        public VideoMemoryType VideoMemoryType { get; set; }

        /// <summary>
        /// Current video mode.
        /// </summary>
        public int VideoMode { get; set; }

        /// <summary>
        /// Number of bits used to display each pixel.
        /// </summary>
        public int CurrentBitsPerPixel { get; set; }

        /// <summary>
        /// Current number of horizontal pixels.
        /// </summary>
        public int CurrentHorizontalResolution { get; set; }

        /// <summary>
        /// Number of colors supported at the current resolution.
        /// </summary>
        public long CurrentNumberOfColors { get; set; }

        /// <summary>
        /// Number of columns for this video controller (if in character mode).
        /// </summary>
        public long CurrentNumberOfColumns { get; set; }

        /// <summary>
        /// Number of rows for this video controller (if in character mode). 
        /// </summary>
        public long CurrentNumberOfRows { get; set; }

        /// <summary>
        /// Frequency at which the video controller refreshes the image for the monitor.
        /// </summary>
        public int CurrentRefreshRate { get; set; }

        /// <summary>
        /// Current scan mode.
        /// </summary>
        public int CurrentScanMode { get; set; }

        /// <summary>
        /// Current number of vertical pixels.
        /// </summary>
        public int CurrentVerticalResolution { get; set; }

        /// <summary>
        /// Current number of device-specific pens.
        /// </summary>
        public int DeviceSpecificPens { get; set; }

        /// <summary>
        /// Dither type of the video controller.
        /// </summary>
        public int DitherType { get; set; }

        /// <summary>
        /// Last modification date and time of the currently installed video driver.
        /// </summary>
        public string DriverDate { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// This function parses the management object structure to extract the video controller info fields.
        /// </summary>
        /// <param name="mgtObject">Management object containing the different video controller info fields</param>
        /// <returns>returns 0 if success, -1 if an exception occured</returns>
        public int GetVideoControllerInfo(ManagementObject mgtObject)
        {
            try
            {
                CurrentBitsPerPixel = mgtObject[Indexes.VideoController_CurrentBitsPerPixelIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_CurrentBitsPerPixelIndex].ToString()) : -1;

                CurrentHorizontalResolution = mgtObject[Indexes.VideoController_CurrentHorizontalResolutionIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_CurrentHorizontalResolutionIndex].ToString()) : -1;

                CurrentNumberOfColors = mgtObject[Indexes.VideoController_CurrentNumberOfColorsIndex] != null ? long.Parse(mgtObject[Indexes.VideoController_CurrentNumberOfColorsIndex].ToString()) : -1;

                CurrentNumberOfColumns = mgtObject[Indexes.VideoController_CurrentNumberOfColumnsIndex] != null ? long.Parse(mgtObject[Indexes.VideoController_CurrentNumberOfColumnsIndex].ToString()) : -1;

                CurrentNumberOfRows = mgtObject[Indexes.VideoController_CurrentNumberOfRowsIndex] != null ? long.Parse(mgtObject[Indexes.VideoController_CurrentNumberOfRowsIndex].ToString()) : -1;

                CurrentRefreshRate = mgtObject[Indexes.VideoController_CurrentRefreshRateIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_CurrentRefreshRateIndex].ToString()) : -1;

                CurrentScanMode = mgtObject[Indexes.VideoController_CurrentScanModeIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_CurrentScanModeIndex].ToString()) : -1;

                CurrentVerticalResolution = mgtObject[Indexes.VideoController_CurrentVerticalResolutionIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_CurrentVerticalResolutionIndex].ToString()) : -1;

                DeviceSpecificPens = mgtObject[Indexes.VideoController_DeviceSpecificPensIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_DeviceSpecificPensIndex].ToString()) : -1;

                DitherType = mgtObject[Indexes.VideoController_DitherTypeIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_DitherTypeIndex].ToString()) : -1;

                Id = mgtObject[Indexes.VideoController_IdIndex].ToString();

                VideoModeDescription = mgtObject[Indexes.VideoController_VideoModeDescriptionIndex].ToString();

                VideoProcessor = mgtObject[Indexes.VideoController_VideoProcessorIndex].ToString();

                SystemName = mgtObject[Indexes.VideoController_SystemNameIndex].ToString();

                Description = mgtObject[Indexes.VideoController_DescriptionIndex].ToString();

                Status = mgtObject[Indexes.VideoController_StatusIndex].ToString();

                AdapterRAM = mgtObject[Indexes.VideoController_AdapterRAMIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_AdapterRAMIndex].ToString()) : -1;

                ColorTableEntries = mgtObject[Indexes.VideoController_ColorTableEntriesIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_ColorTableEntriesIndex].ToString()) : -1;

                AdapterDACType = mgtObject[Indexes.VideoController_AdapterDACTypeIndex] != null ? mgtObject[Indexes.VideoController_AdapterDACTypeIndex].ToString() : string.Empty;

                LastErrorCode = mgtObject[Indexes.VideoController_LastErrorCodeIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_LastErrorCodeIndex].ToString()) : -1;

                MaxMemorySupported = mgtObject[Indexes.VideoController_MaxMemorySupportedIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_MaxMemorySupportedIndex].ToString()) : -1;

                MaxNumberControlled = mgtObject[Indexes.VideoController_MaxNumberControlledIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_MaxNumberControlledIndex].ToString()) : -1;

                MaxRefreshRate = mgtObject[Indexes.VideoController_MaxRefreshRateIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_MaxRefreshRateIndex].ToString()) : -1;

                MinRefreshRate = mgtObject[Indexes.VideoController_MinRefreshRateIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_MinRefreshRateIndex].ToString()) : -1;

                VideoArchitecture = GetVideoArchitecture(mgtObject[Indexes.VideoController_VideoArchitectureIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_VideoArchitectureIndex].ToString()) : 2);

                VideoMemoryType = GetVideoMemoryType(mgtObject[Indexes.VideoController_VideoMemoryTypeIndex] == null ? int.Parse(mgtObject[Indexes.VideoController_VideoMemoryTypeIndex].ToString()) : 2);

                VideoMode = mgtObject[Indexes.VideoController_VideoModeIndex] != null ? int.Parse(mgtObject[Indexes.VideoController_VideoModeIndex].ToString()) : -1;

                string str = mgtObject[Indexes.VideoController_DriverDateIndex].ToString().TrimEnd();
                if (!string.IsNullOrWhiteSpace(str))
                {
                    int year = int.Parse(str.Substring(0, 4));
                    int month = int.Parse(str.Substring(4, 2));
                    int day = int.Parse(str.Substring(6, 2));

                    int hour = int.Parse(str.Substring(8, 2));
                    int minute = int.Parse(str.Substring(10, 2));
                    int second = int.Parse(str.Substring(12, 2));

                    DateTime date = new(year, month, day, hour, minute, second);

                    DriverDate = date.ToString();
                }
                else
                {
                    DriverDate = string.Empty;
                }

                return 0;
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Stringifies the properties of the VideoControllerInfo class.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder str = new();

            str.Append($"Name: {Id}\n");
            str.Append($"Video Architecture: {VideoArchitecture}\n");
            str.Append($"Video Memory Type: {VideoMemoryType}\n");
            str.Append($"Video Controller Status: {Status}\n");
            str.Append($"Adapter RAM (Bytes): {AdapterRAM}\n");
            str.Append($"Driver Date: {DriverDate}\n");
            str.Append($"Video Mode Description: {VideoModeDescription}\n");

            return str.ToString();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// This functions converts the video controller architecture from enumeration to string
        /// </summary>
        /// <param name="architecture">the video controller architecture (int)</param>
        /// <returns>the video controller architecture (string)</returns>
        protected static VideoArchitecture GetVideoArchitecture(int architecture)
        {
            return (VideoArchitecture)architecture;
        }

        /// <summary>
        /// This functions converts the video controller architecture from enumeration to string
        /// </summary>
        /// <param name="memtype">the video controller architecture (int)</param>
        /// <returns>the video controller architecture (string)</returns>
        protected static VideoMemoryType GetVideoMemoryType(int memtype)
        {
            return (VideoMemoryType)memtype;
        }

        #endregion
    }
}
