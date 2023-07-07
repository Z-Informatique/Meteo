using Meteo.ViewModels;

namespace Meteo.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		BindingContext = new SettingsViewModel();
	}

	async void OnSignOut(object sender, EventArgs e)
	{
		var result = await DisplayAlert("D�connexion", "�tes-vous sur de vouloir vous d�connecter ?", "OUI", "NON");
		if (result.ToString() == "OUI" )
		{
			await DisplayAlert("Message", "Vous avez �t� d�connecter avec succ�s", "OK");
		}
	}

	async void OnSupportTapped(object sender, EventArgs e)
	{
		string action = await DisplayActionSheet("Obtenir de l'aide", "Annuler", null, "Email", "Chat", "T�l�phone");
		await DisplayAlert("Votre choix est", action, "OK");
	}

	void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		AppTheme val = (AppTheme)((RadioButton)sender).Value;
		if (App.Current.UserAppTheme == val)
		{
			return;
		}
		App.Current.UserAppTheme = val;
	}


}