using LightInject;
using System.Windows;

namespace Client.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		private readonly ServiceContainer _services;

		public App()
		{
			var container = new ServiceContainer();
			container.ConfigureServices();
			_services = container;
		}

		private void OnStartup(object sender, StartupEventArgs e)
		{
			_services.GetInstance<MainWindow>().Show();
		}
	}

}
