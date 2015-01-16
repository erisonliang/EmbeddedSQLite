using System;
using System.IO;
using System.Reflection;
using System.Web.Hosting;

namespace Pronestor.EmbeddedSQLite
{
  public static class SqLiteAssemblyLoader
  {
    private static readonly Lazy<Assembly> _sqlLiteAssemblyLoader;

    static SqLiteAssemblyLoader()
    {
      _sqlLiteAssemblyLoader = new Lazy<Assembly>(() =>
      {
        bool is64BitProcess = (IntPtr.Size == 8);
        const string dllName = "System.Data.SQLite.DLL";
        
        // Embedded dll resource names:
        // 32-bit: EmbeddedSQLite.Resources.x86.System.Data.SQLite.DLL
        // 64-bit: EmbeddedSQLite.Resources.x64.System.Data.SQLite.DLL

        string embeddedDllResourceName = "Pronestor.EmbeddedSQLite.Resources." + (is64BitProcess ?  "x64" : "x86") + "." + dllName;
        using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(embeddedDllResourceName))
        {
          string filePath = Path.Combine(GetDllDirectory(), dllName);
          using (Stream fileStream = File.OpenWrite(filePath))
          {
            stream.CopyTo(fileStream);
            fileStream.Flush();
          }

          Assembly asm = Assembly.LoadFile(filePath);
          return asm;
        }
      });
    }

    public static void Init()
    {
      AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => 
        args.Name == "System.Data.SQLite, Version=1.0.61.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139" ? _sqlLiteAssemblyLoader.Value : null;
    }

    private static string GetDllDirectory()
    {
      return HostingEnvironment.IsHosted ? Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data") : Directory.GetCurrentDirectory();
    }
  }
}
