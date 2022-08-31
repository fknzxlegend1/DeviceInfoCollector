#region License information

/*

Copyright 2022 Bogdan Bara, Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using MachineInfo.System.Enumerations;

namespace MachineInfo.System.Data.Implementation
{
    internal class VideoControllerInfo : IVideoControllerInfo
    {
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
        public long AdapterRAM { get; set; }

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
    }
}
