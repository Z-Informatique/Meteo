using Meteo.ViewModels;

namespace Meteo.Views;

public partial class Next7DWidget
{
	public Next7DWidget()
	{
		InitializeComponent();
		BindingContext = new HomeViewModel();
	}
}