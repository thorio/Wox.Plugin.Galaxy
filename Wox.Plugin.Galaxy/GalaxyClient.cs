namespace Wox.Plugin.Galaxy
{
	class GalaxyClient
	{
		public static bool StartGame(string releaseKey)
		{
			System.Diagnostics.Process.Start(Configuration.GetKey("ExePath"), $"/command=runGame /gameId={releaseKey}");
			return true;
		}
	}
}
