using Meteo.ViewModels;

namespace Meteo.Pages;

public partial class FavoritesPage : ContentPage
{
	public FavoritesPage()
	{
		InitializeComponent();
		BindingContext = new FavoritesViewModel();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();

		await Task.Delay(300);
        TransitionIn();
	}
	int tileCount = 0;
	List<Frame> tiles = new List<Frame>();
    private async void TransitionIn()
    {
		foreach (var item in tiles)
		{
			await item.FadeTo(1, 800);
			await Task.Delay(50);
		}
    }

	void OnHandlerChanged(object sender, EventArgs e)
	{
		Frame f = (Frame)sender;
		tiles.Add(f);
		tileCount++;
	}
}