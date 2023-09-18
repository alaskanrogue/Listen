namespace Listen
{
	using Microsoft.Maui;
	using Microsoft.Maui.Controls;
	using CommunityToolkit.Maui.Alerts;
	using CommunityToolkit.Maui.Core;
	using CommunityToolkit.Maui.Media;
	using System.Globalization;
	using System.Threading;

	public partial class MainPage : ContentPage
	{
		internal static string activeLanguage = "en-US";
		internal CancellationToken cancellationToken;
		internal bool yesno;

		public MainPage()
		{
			InitializeComponent();
		}

		private void OnListenClicked(object sender, EventArgs e)
		{
			GetVocalResponse();
		}

		internal async void GetVocalResponse()
		{
			cancellationToken = new CancellationToken();

			var RecognitionText = "";

			ISpeechToText speechToText = SpeechToText.Default;

			var recognitionResult = await speechToText.ListenAsync(
												CultureInfo.GetCultureInfo(activeLanguage),
												new Progress<string>(partialText =>
												{
													RecognitionText += partialText + " ";
												}), cancellationToken);

			if (recognitionResult.IsSuccessful)
			{
				RecognitionText = recognitionResult.Text;

				if (RecognitionText.Contains("yes"))
				{
					yesno = true;
				}
				else
				{
					yesno = false;
				}
			}
		}
	}
}
