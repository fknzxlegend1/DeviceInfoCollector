namespace MachineInfo.System.Enumerations
{
    /// <summary>
    /// Enumeration <see cref="CPUVoltage"/>
    /// <para />
    /// An enumeration of CPU voltages as detailed in the class Win32-Processor
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor">win32-processor</see>
    /// </summary>
    public enum CPUVoltage 
    { 
        NONE = -1,
        UNKNOWN = 0,
        _5V = 1, 
        _3_3V = 2, 
        _2_9V = 4, 
    }
}
