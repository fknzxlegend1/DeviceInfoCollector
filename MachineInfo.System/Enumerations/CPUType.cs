namespace MachineInfo.System.Enumerations
{
    /// <summary>
    /// Enumeration <see cref="CPUType"/>
    /// <para />
    /// An enumeration of CPU types as detailed in the class Win32-Processor
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor">win32-processor</see>
    /// </summary>
    public enum CPUType 
    {
        NONE = -1,
        OTHER = 1, 
        UNKNOWN = 2, 
        CENTRAL_PROCESSOR = 3, 
        MATH_PROCESSOR = 4, 
        DSP_PROCESSOR = 5, 
        VIDEO_PROCESSOR = 6,
    }
}
