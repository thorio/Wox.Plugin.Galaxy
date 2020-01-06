using System;
using System.Configuration;
using System.Reflection;

namespace Wox.Plugin.Galaxy
{
	static class Configuration
	{
		private static System.Configuration.Configuration _config;

		static System.Configuration.Configuration Config
		{
			get
			{
				if (_config is null)
				{
					var configMap = new ExeConfigurationFileMap();
					configMap.ExeConfigFilename = Assembly.GetAssembly(typeof(Configuration)).Location + ".config";
					_config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
				}
				return _config;
			}
		}

		public static string GetKey(string key)
		{
			try
			{
				return Config.AppSettings.Settings[key].Value;
			}
			catch (NullReferenceException)
			{
				throw new ConfigurationErrorsException($"Missing configuration key '{key}'");
			}
		}

		public static ConnectionStringSettings GetConnectionString(string connectionStringName)
		{
			try
			{
				return Config.ConnectionStrings.ConnectionStrings[connectionStringName];
			}
			catch (NullReferenceException)
			{
				throw new ConfigurationErrorsException($"Missing connectionString '{connectionStringName}'");
			}
		}
	}
}
