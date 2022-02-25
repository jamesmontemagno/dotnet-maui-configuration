using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace MauiApp27;

public partial class App : Application
{
	public App(MainPage page)
	{
		InitializeComponent();

		MainPage = page;
	}
}
