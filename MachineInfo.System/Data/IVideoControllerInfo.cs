#region License information

/*

Copyright 2022 Bogdan Bara, Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using MachineInfo.System.Enumerations;

namespace MachineInfo.System.Data
{
    public interface IVideoControllerInfo
    {
        /// <summary>
        /// Video controller identifier
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Current resolution, color, and scan mode settings of the video controller.
        /// </summary>
        string VideoModeDescription { get; }

        /// <summary>
        /// Free-form string describing the video processor.
        /// </summary>
        string VideoProcessor { get; }

        /// <summary>
        /// Name of the scoping system.
        /// </summary>
        string SystemName { get; }

        /// <summary>
        /// Description of the object.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Current status of the object. Various operational and nonoperational statuses can be defined.
        /// </summary>
        string Status { get; }

        /// <summary>
        /// Memory size of the video adapter.
        /// </summary>
        long AdapterRAM { get; }

        /// <summary>
        /// Size of the system's color table. The device must have a color depth of 
        /// no more than 8 bits per pixel; otherwise, this property is not set.
        /// </summary>
        int ColorTableEntries { get; }

        /// <summary>
        /// Name or identifier of the digital-to-analog converter (DAC) chip. 
        /// The character set of this property is alphanumeric.
        /// </summary>
        string AdapterDACType { get; }

        /// <summary>
        /// Last error code reported by the logical device.
        /// </summary>
        int LastErrorCode { get; }

        /// <summary>
        /// Maximum amount of memory supported in bytes.
        /// </summary>
        int MaxMemorySupported { get; }

        /// <summary>
        /// Maximum number of directly addressable entities supportable by this controller.
        /// A value of 0 (zero) should be used if the number is unknown.
        /// </summary>
        int MaxNumberControlled { get; }

        /// <summary>
        /// Maximum refresh rate of the video controller in hertz.
        /// </summary>
        int MaxRefreshRate { get; }

        /// <summary>
        /// Minimum refresh rate of the video controller in hertz.
        /// </summary>
        int MinRefreshRate { get; }

        /// <summary>
        /// Type of video architecture.
        /// </summary>
        VideoArchitecture VideoArchitecture { get; }

        /// <summary>
        /// Type of video memory.
        /// </summary>
        VideoMemoryType VideoMemoryType { get; }

        /// <summary>
        /// Current video mode.
        /// </summary>
        int VideoMode { get; }

        /// <summary>
        /// Number of bits used to display each pixel.
        /// </summary>
        int CurrentBitsPerPixel { get; }

        /// <summary>
        /// Current number of horizontal pixels.
        /// </summary>
        int CurrentHorizontalResolution { get; }

        /// <summary>
        /// Number of colors supported at the current resolution.
        /// </summary>
        long CurrentNumberOfColors { get; }

        /// <summary>
        /// Number of columns for this video controller (if in character mode).
        /// </summary>
        long CurrentNumberOfColumns { get; }

        /// <summary>
        /// Number of rows for this video controller (if in character mode). 
        /// </summary>
        long CurrentNumberOfRows { get; }

        /// <summary>
        /// Frequency at which the video controller refreshes the image for the monitor.
        /// </summary>
        int CurrentRefreshRate { get; }

        /// <summary>
        /// Current scan mode.
        /// </summary>
        int CurrentScanMode { get; }

        /// <summary>
        /// Current number of vertical pixels.
        /// </summary>
        int CurrentVerticalResolution { get; }

        /// <summary>
        /// Current number of device-specific pens.
        /// </summary>
        int DeviceSpecificPens { get; }

        /// <summary>
        /// Dither type of the video controller.
        /// </summary>
        int DitherType { get; }

        /// <summary>
        /// Last modification date and time of the currently installed video driver.
        /// </summary>
        string DriverDate { get; }
    }
}
