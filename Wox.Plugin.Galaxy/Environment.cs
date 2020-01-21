using System.Configuration;

namespace Wox.Plugin.Galaxy
{
	static class Environment
	{
		public static ConnectionStringSettings ConnectionString => Configuration.GetConnectionString("Galaxy2.0");
		public static string ExePath => Configuration.GetKey("ExePath");
		public static bool HideLauncher => bool.Parse(Configuration.GetKey("HideLauncher"));
	}
}
