namespace MachineInfo.System.Enumerations
{
    /// <summary>
    /// Enumeration <see cref="VideoMemoryType"/>
    /// <para />
    /// An enumeration of video memory types as detailed in the class Win32-VideoController
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-videocontroller">win32-videocontroller</see>
    /// </summary>
    public enum VideoMemoryType
    {
        OTHER = 1, 
        UKNOWN = 2, 
        VRAM = 3, 
        DRAM = 4, 
        SRAM = 5, 
        WRAM = 6, 
        EDO_RAM = 7,
        Burst_Synchronous_DRAM = 8, 
        Pipelined_Burst_SRAM = 9, 
        CDRAM = 10, 
        _3DRAM = 11,
        SDRAM = 12, 
        SGRAM = 13
    }
}
