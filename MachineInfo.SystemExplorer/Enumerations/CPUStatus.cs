namespace MachineInfo.System.Enumerations
{
    /// <summary>
    /// Enumeration <see cref="CPUStatus"/>
    /// <para />
    /// An enumeration of CPU statuses as detailed in the class Win32-Processor
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor">win32-processor</see>
    /// </summary>
    public enum CPUStatus 
    { 
        NONE = -1,
        UNKNOWN = 0,
        ENABLED = 1,
        DISABLED_USER = 2,
        DISABLED_BIOS = 3,
        IDLE = 4,
        RESERVED = 5,
        OTHER = 7,
    }
}
