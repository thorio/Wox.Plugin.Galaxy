using System.Configuration;

namespace Wox.Plugin.Galaxy
{
	static class Environment
	{
		public static ConnectionStringSettings ConnectionString => Configuration.GetConnectionString("Galaxy2.0");
	}
}
