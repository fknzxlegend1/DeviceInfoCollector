namespace MachineInfo.System.Enumerations
{
    /// <summary>
    /// Enumeration <see cref="MemoryBankFormFactor"/>
    /// <para />
    /// An enumeration of memory bank form factors as detailed in the class Win32-PhysicalMemory
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-physicalmemory">win32-physicalmemory</see>
    /// </summary>
    public enum MemoryBankFormFactor
    {
        UNKNOWN = 0, 
        OTHER = 1, 
        SIP = 2, 
        DIP = 3, 
        ZIP = 4, 
        SOJ = 5, 
        PROPRIETARY = 6, 
        SIMM = 7, 
        DIMM = 8, 
        TSOP = 9,
        PGA = 10, 
        RIMM = 11, 
        SODIMM = 12, 
        SRIMM = 13, 
        SMD = 14, 
        SSMP = 15, 
        QFP = 16, 
        TQFP = 17, 
        SOIC = 18, 
        LCC = 19,
        PLCC = 20, 
        BGA = 21, 
        FPBGA = 22, 
        LGA = 23
    }
}
