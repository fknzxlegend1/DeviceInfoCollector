namespace MachineInfo.System.Enumerations
{
    /// <summary>
    /// Enumeration <see cref="VideoArchitecture"/>
    /// <para />
    /// An enumeration of video controller architectures as detailed in the class Win32-VideoController
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-videocontroller">win32-videocontroller</see>
    /// </summary>
    public enum VideoArchitecture
    {
        OTHER = 1, 
        UNKNOWN = 2, 
        CGA = 3, 
        EGA = 4, 
        VGA = 5, 
        SVGA = 6, 
        MDA = 7, 
        HGC = 8,
        MCGA = 9,
        _8514A = 10, 
        XGA = 11, 
        Linear_Frame_Buffer = 12, 
        PC_98 = 160
    }
}
