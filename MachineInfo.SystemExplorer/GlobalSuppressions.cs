// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Assembly is only compatible with Windows environment and therefore", Scope = "namespaceanddescendants", Target = "~N:MachineInfo.System")]
[assembly: SuppressMessage("Style", "IDE0057:Use range operator", Justification = "Code analysis message suppressed to keep Substring() style consistent in same method", Scope = "member", Target = "~M:MachineInfo.System.Information.VideoControllerInfo.GetVideoControllerInfo(System.Management.ManagementObject)~System.Int32")]
