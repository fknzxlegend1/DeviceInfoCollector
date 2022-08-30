﻿#region License information

/*

Copyright 2022 Bogdan Bara, Sabeur Lafi

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using MachineInfo.System.Data;
using MachineInfo.System.Data.Implementation;

namespace MachineInfo.System.Monitors.Implementation
{
    internal class PlatformMonitor : IPlatformMonitor
    {
        public IPlatformInformation CollectData()
        {
            PlatformInformation information = new();

            try
            {
                var os = Environment.OSVersion;

                information.Is64BitOperatingSystem = Environment.Is64BitOperatingSystem;
                information.MachineName = Environment.MachineName;
                information.Platform = os.Platform;
                information.ServicePack = os.ServicePack;
                information.Version = os.VersionString;
                information.CLRVersion = Environment.Version.ToString();
                information.ProcessorCount = Environment.ProcessorCount;
                information.LogicalDrives = Environment.GetLogicalDrives();
                information.EnvironmentVariables = Environment.GetEnvironmentVariables();
            }
            catch
            {
                return null;
            }

            return information;
        }
    }
}
