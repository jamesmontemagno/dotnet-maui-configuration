using Microsoft.Extensions.Configuration;

namespace MauiApp27;

public partial class MainPage : ContentPage
{
	int count = 0;
	IConfiguration configuration;
	public MainPage(IConfiguration config)
	{
		InitializeComponent();

		configuration = config;

		//configuration = MauiProgram.Services.GetService<IConfiguration>();

	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		count++;
		CounterLabel.Text = $"Current count: {count}";

		SemanticScreenReader.Announce(CounterLabel.Text);


		var settings = configuration.GetRequiredSection("Settings").Get<Settings>();
		await DisplayAlert("Config", $"{nameof(settings.KeyOne)}: {settings.KeyOne}" +
            $"{nameof(settings.KeyTwo)}: {settings.KeyTwo}" +
            $"{nameof(settings.KeyThree.Message)}: {settings.KeyThree.Message}", "OK");
	}
}

