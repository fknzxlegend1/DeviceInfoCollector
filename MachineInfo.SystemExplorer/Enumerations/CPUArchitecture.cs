namespace MachineInfo.System.Enumerations
{
    /// <summary>
    /// Enumeration <see cref="CPUArchitecture"/>
    /// <para />
    /// An enumeration of CPU architectures as detailed in the class Win32-Processor
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor">win32-processor</see>
    /// </summary>
    public enum CPUArchitecture 
    { 
        NONE = -1,
        X86 = 0,
        MIPS = 1,
        ALPHA = 2,
        POWERPC = 3,
        ARM = 5,
        IA64 = 6,
        X64 = 9,
    }
}
