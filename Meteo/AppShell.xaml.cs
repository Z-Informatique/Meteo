using System.Diagnostics;

namespace Meteo;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        if (DeviceInfo.Idiom == DeviceIdiom.Phone)
        {
			CurrentItem = PhoneTabs;
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		try
		{
			await Shell.Current.GoToAsync($"///settings");
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"err: {ex.Message}");
		}
    }
}
