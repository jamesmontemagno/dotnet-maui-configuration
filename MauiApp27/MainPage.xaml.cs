using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MauiApp27;

public partial class MainPage : ContentPage
{
	int count = 0;
	IConfiguration configuration;
	public MainPage(IConfiguration config, ILogger<MainPage> logger)
	{
		InitializeComponent();

		configuration = config;
		logger.LogInformation("Test");
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

