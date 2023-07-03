using System.Timers;

namespace Meteo.Views;

public partial class WindLiveWidget
{
	Random rand;
    System.Timers.Timer aTimer;
	public WindLiveWidget()
	{
		InitializeComponent();
	}

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
		if (aTimer == null && DeviceInfo.Platform != DevicePlatform.Android)
		{
			Start();
		}
    }

    public void Start()
    {
		rand = new Random();
		aTimer = new System.Timers.Timer(300);

		aTimer.Elapsed += UpdateLiveWind;
		aTimer.AutoReset = true;
		aTimer.Enabled = true;
    }
	public void Stop()
	{
		aTimer.Enabled = false;
	}
    private void UpdateLiveWind(object sender, System.Timers.ElapsedEventArgs e)
    {
		var direction = GetDirection();

		this.Dispatcher.Dispatch(() =>
		{
			Needle.RotateTo(WindValues[direction], 50, Easing.SpringOut);
		});
    }

	readonly double[] WindValues = { 98, 84, 140, 92, 55 };
    private int GetDirection()
    {
		return rand.Next(0, WindValues.Length - 1);
    }
}