using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;

namespace Microwave
{
	class ShittyMicrowave
	{
		[DllImport("winmm.dll", EntryPoint = "mciSendString")]
		public static extern int mciSendStringA(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

		static void Main(string[] args)
		{
			new ShittyMicrowave(true);
		}

		public ShittyMicrowave(bool closesAfterDing)
		{
			Open();
			Ding();
			Serve();
			Close();
		}

		private void Open()
		{
			mciSendStringA("set CDAudio door open", "", 127, 0);
		}

		private void Ding()
		{
			new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("Microwave.ding.wav")).Play();
		}

		private void Serve()
		{
			Thread.Sleep(5000);
		}

		private void Close()
		{
			mciSendStringA("set CDAudio door closed", "", 127, 0);
		}
	}
}