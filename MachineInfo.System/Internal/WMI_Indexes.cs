#region License information

/*

Copyright 2022 Bogdan Bara

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

namespace MachineInfo.System.Internal
{
    internal static class WMI_Indexes
    {
        #region CPU indexes

        public const string CPU_IdIndex = "Name";
        public const string CPU_AddressWidthIndex = "AddressWidth";
        public const string CPU_CpuStatusIndex = "CpuStatus";
        public const string CPU_DataWidthIndex = "DataWidth";
        public const string CPU_DeviceIDIndex = "DeviceID";
        public const string CPU_FamilyIndex = "Family";
        public const string CPU_ManufacturerIndex = "Manufacturer";
        public const string CPU_MaxClockSpeedIndex = "MaxClockSpeed";
        public const string CPU_CurrentClockSpeedIndex = "CurrentClockSpeed";
        public const string CPU_PartNumberIndex = "PartNumber";
        public const string CPU_SerialNumberIndex = "SerialNumber";
        public const string CPU_UniqueIdIndex = "UniqueId";
        public const string CPU_ProcessorTypeIndex = "ProcessorType";
        public const string CPU_ProcessorIdIndex = "ProcessorId";
        public const string CPU_LoadPercentageIndex = "LoadPercentage";
        public const string CPU_ArchitectureIndex = "Architecture";
        public const string CPU_CurrentVoltageIndex = "CurrentVoltage";
        public const string CPU_NumberOfLogicalProcessorsIndex = "NumberOfLogicalProcessors";
        public const string CPU_NumberOfCoresIndex = "NumberOfCores";
        public const string CPU_NumberOfEnabledCoreIndex = "NumberOfEnabledCore";
        public const string CPU_LevelIndex = "Level";
        public const string CPU_L2CacheSizeIndex = "L2CacheSize";
        public const string CPU_L2CacheSpeedIndex = "L2CacheSpeed";
        public const string CPU_L3CacheSizeIndex = "L3CacheSize";
        public const string CPU_L3CacheSpeedIndex = "L3CacheSpeed";
        public const string CPU_ThreadCountIndex = "ThreadCount";
        public const string CPU_VirtualizationFirmwareEnabledIndex = "VirtualizationFirmwareEnabled";

        #endregion

        #region DiskDrive indexes

        public const string DiskDrive_IdIndex = "Name";
        public const string DiskDrive_DeviceIDIndex = "DeviceID";
        public const string DiskDrive_ModelIndex = "Model";
        public const string DiskDrive_ManufacturerIndex = "Manufacturer";
        public const string DiskDrive_SerialNumberIndex = "SerialNumber";
        public const string DiskDrive_StatusIndex = "Status";
        public const string DiskDrive_SystemCreationClassNameIndex = "SystemCreationClassName";
        public const string DiskDrive_SystemNameIndex = "SystemName";
        public const string DiskDrive_TotalCylindersIndex = "TotalCylinders";
        public const string DiskDrive_TotalHeadsIndex = "TotalHeads";
        public const string DiskDrive_TotalSectorsIndex = "TotalSectors";
        public const string DiskDrive_TotalTracksIndex = "TotalTracks";
        public const string DiskDrive_SizeIndex = "Size";
        public const string DiskDrive_NumberOfMediaSupportedIndex = "NumberOfMediaSupported";
        public const string DiskDrive_PartitionsIndex = "Partitions";
        public const string DiskDrive_StatusInfoIndex = "StatusInfo";
        public const string DiskDrive_TracksPerCylinderIndex = "TracksPerCylinder";
        public const string DiskDrive_SignatureIndex = "Signature";

        #endregion

        #region DiskPartition indexes

        public const string DiskPartition_IdIndex = "Name";
        public const string DiskPartition_DeviceIDIndex = "DeviceID";
        public const string DiskPartition_SizeIndex = "Size";
        public const string DiskPartition_NumberOfBlocksIndex = "NumberOfBlocks";
        public const string DiskPartition_StatusIndex = "Status";
        public const string DiskPartition_SystemCreationClassNameIndex = "SystemCreationClassName";
        public const string DiskPartition_SystemNameIndex = "SystemName";
        public const string DiskPartition_TypeIndex = "Type";
        public const string DiskPartition_BootableIndex = "Bootable";
        public const string DiskPartition_BootPartitionIndex = "BootPartition";
        public const string DiskPartition_PrimaryPartitionIndex = "PrimaryPartition";
        public const string DiskPartition_RewritePartitionIndex = "RewritePartition";

        #endregion

        #region MemoryBank indexes

        public const string MemoryBank_CapacityIndex = "Capacity";
        public const string MemoryBank_IdIndex = "Name";
        public const string MemoryBank_BankLabelIndex = "BankLabel";
        public const string MemoryBank_DescriptionIndex = "Description";
        public const string MemoryBank_DeviceLocatorIndex = "DeviceLocator";
        public const string MemoryBank_ManufacturerIndex = "Manufacturer";
        public const string MemoryBank_SerialNumberIndex = "SerialNumber";
        public const string MemoryBank_SKUIndex = "SKU";
        public const string MemoryBank_StatusIndex = "Status";
        public const string MemoryBank_ModelIndex = "Model";
        public const string MemoryBank_OtherIdentifyingInfoIndex = "OtherIdentifyingInfo";
        public const string MemoryBank_PartNumberIndex = "PartNumber";
        public const string MemoryBank_DataWidthIndex = "DataWidth";
        public const string MemoryBank_SpeedIndex = "Speed";
        public const string MemoryBank_SMBIOSMemoryTypeIndex = "SMBIOSMemoryType";
        public const string MemoryBank_TagIndex = "Tag";
        public const string MemoryBank_VersionIndex = "Version";
        public const string MemoryBank_TotalWidthIndex = "TotalWidth";
        public const string MemoryBank_TypeDetailIndex = "TypeDetail";
        public const string MemoryBank_PositionInRowIndex = "PositionInRow";
        public const string MemoryBank_FormFactorIndex = "FormFactor";

        #endregion

        #region VideoController indexes

        public const string VideoController_CurrentBitsPerPixelIndex = "CurrentBitsPerPixel";
        public const string VideoController_CurrentHorizontalResolutionIndex = "CurrentHorizontalResolution";
        public const string VideoController_CurrentNumberOfColorsIndex = "CurrentNumberOfColors";
        public const string VideoController_CurrentNumberOfColumnsIndex = "CurrentNumberOfColumns";
        public const string VideoController_CurrentNumberOfRowsIndex = "CurrentNumberOfRows";
        public const string VideoController_CurrentRefreshRateIndex = "CurrentRefreshRate";
        public const string VideoController_CurrentScanModeIndex = "CurrentScanMode";
        public const string VideoController_CurrentVerticalResolutionIndex = "CurrentVerticalResolution";
        public const string VideoController_DeviceSpecificPensIndex = "DeviceSpecificPens";
        public const string VideoController_DitherTypeIndex = "DitherType";
        public const string VideoController_IdIndex = "Name";
        public const string VideoController_VideoModeDescriptionIndex = "VideoModeDescription";
        public const string VideoController_VideoProcessorIndex = "VideoProcessor";
        public const string VideoController_SystemNameIndex = "SystemName";
        public const string VideoController_DescriptionIndex = "Description";
        public const string VideoController_StatusIndex = "Status";
        public const string VideoController_AdapterRAMIndex = "AdapterRAM";
        public const string VideoController_ColorTableEntriesIndex = "ColorTableEntries";
        public const string VideoController_AdapterDACTypeIndex = "AdapterDACType";
        public const string VideoController_LastErrorCodeIndex = "LastErrorCode";
        public const string VideoController_MaxMemorySupportedIndex = "MaxMemorySupported";
        public const string VideoController_MaxNumberControlledIndex = "MaxNumberControlled";
        public const string VideoController_MaxRefreshRateIndex = "MaxRefreshRate";
        public const string VideoController_MinRefreshRateIndex = "MinRefreshRate";
        public const string VideoController_VideoArchitectureIndex = "VideoArchitecture";
        public const string VideoController_VideoMemoryTypeIndex = "VideoMemoryType";
        public const string VideoController_VideoModeIndex = "VideoMode";
        public const string VideoController_DriverDateIndex = "DriverDate";

        #endregion
    }
}
