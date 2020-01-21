using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Wox.Plugin.Galaxy
{
	class GalaxyClient
	{
		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);

		public static bool StartGame(string releaseKey)
		{
			Process.Start(Environment.ExePath, $"/command=runGame /gameId={releaseKey}");
			if (Environment.HideLauncher)
			{
				HideClient();
			}
			return true;
		}

		public async static void HideClient()
		{
			var i = 5;
			while (i-- > 0)
			{
				HideClient_Internal();
				await Task.Delay(100);
			}
		}

		private static bool HideClient_Internal()
		{
			var process = Process.GetProcessesByName("GalaxyClient").FirstOrDefault();
			if (process != null)
			{
				return ShowWindow(process.MainWindowHandle, 0);
			}
			return false;
		}
	}
}
