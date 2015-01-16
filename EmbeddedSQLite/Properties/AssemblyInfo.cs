using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using Pronestor.EmbeddedSQLite;

[assembly: PreApplicationStartMethod(typeof(SqLiteAssemblyLoader), "Init")]
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("EmbeddedSQLite")]
[assembly: AssemblyDescription("Embeds x64 and x86 System.Data.SQLite.dlls and resolves the correct one depending on process bitness")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Pronestor")]
[assembly: AssemblyProduct("EmbeddedSQLite")]
[assembly: AssemblyCopyright("Copyright ©  2015")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("0b49491d-b586-4866-894b-f0ba70be1bcc")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
