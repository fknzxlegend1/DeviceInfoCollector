#region License information

/*

Copyright 2019 Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

namespace MachineInfo.System.Enumerations
{
    /// <summary>
    /// Enumeration <see cref="CPUFamily"/>
    /// <para />
    /// An enumeration of CPU families as detailed in the class Win32-Processor
    /// <para />
    /// For more information, see <see href="https://docs.microsoft.com/en-us/windows/win32/cimwin32prov/win32-processor">win32-processor</see>
    /// </summary>
    public enum CPUFamily
    {
        NONE = -1,
        Other = 1,
        Unknown = 2, 
        _8086 = 3, 
        _80286 = 4, 
        Intel_80386 = 5, 
        Intel_80486 = 6, 
        _8087 = 7, 
        _80287 = 8, 
        _80387 = 9,
        _80487 = 10, 
        Pentium_brand = 11, 
        Pentium_Pro = 12, 
        Pentium_II = 13, 
        Pentium_MMX = 14, 
        Celeron = 15, 
        Pentium_II_Xeon = 16,
        Pentium_III = 17, 
        M1_Family = 18, 
        M2_Family = 19, 
        K5_Family = 24, 
        K6_Family = 25, 
        K6_2 = 26, 
        K6_3 = 27, 
        AMD_Athlon = 28,
        AMD_Duron = 29, 
        AMD29000 = 30, 
        K6_2PLUS = 31, 
        Power_PC = 32, 
        Power_PC_601 = 33, 
        Power_PC_603 = 34, 
        Power_PC_603_PLUS = 35,
        Power_PC_604 = 36, 
        Power_PC_620 = 37, 
        Power_PC_X704 = 38, 
        Power_PC_750 = 39, 
        Alpha = 48, 
        Alpha_21064 = 49, 
        Alpha_21066 = 50,
        Alpha_21164 = 51, 
        Alpha_21164PC = 52, 
        Alpha_21164a = 53, 
        Alpha_21264 = 54, 
        Alpha_21364 = 55, 
        MIPS = 64, 
        MIPS_R4000 = 65,
        MIPS_R4200 = 66, 
        MIPS_R4400 = 67, 
        MIPS_R4600 = 68, 
        MIPS_R10000 = 69, 
        SPARC = 80, 
        SuperSPARC = 81, 
        MICROSPARC_II = 82,
        MICROSPARC_IIEP = 83, 
        ULTRASPARC = 84, 
        ULTRASPARC_II = 85, 
        ULTRASPARC_IIi = 86, 
        ULTRASPARC_III = 87, 
        ULTRASPARC_IIIi = 88,
        _68040 = 96, 
        _68XXX = 97, 
        _68000 = 98, 
        _68010 = 99, 
        _68020 = 100, 
        _68030 = 101, 
        Hobbit = 112, 
        Crusoe_TM5000 = 120,
        Crusoe_TM3000 = 121, 
        Efficeon_TM8000 = 122, 
        Weitek = 128, 
        Itanium = 130, 
        AMD_Athlon_64 = 131, 
        AMD_Opteron = 132,
        PA_RISC = 144, 
        PA_RISC_8500 = 145, 
        PA_RISC_8000 = 146, 
        PA_RISC_7300LC = 147, 
        PA_RISC_7200 = 148, 
        PA_RISC_7100LC = 149,
        PA_RISC_7100 = 150, 
        V30 = 160, 
        Pentium_III_Xeon = 176, 
        Pentium_III_SpeedStep = 177, 
        Pentium_4 = 178, 
        Intel_Xeon = 179,
        AS400 = 180, 
        Intel_Xeon_MP = 181, 
        AMD_AthlonXP = 182, 
        AMD_AthlonMP = 183, 
        Intel_Itanium_2 = 184, 
        Intel_Pentium_M = 185,
        K7 = 190, 
        IBM390 = 200, 
        G4 = 201, 
        G5 = 202, 
        G6 = 203, 
        Z_Architecture = 204, 
        i860 = 250, 
        i960 = 251, 
        SH_3 = 260,
        SH_4 = 261, 
        ARM = 280, 
        StrongARM = 281, 
        _6X86 = 300, 
        MediaGX = 301, 
        MII = 302, 
        WinChip = 320, 
        DSP = 350, 
        Video_Processor = 500,
    }
}
