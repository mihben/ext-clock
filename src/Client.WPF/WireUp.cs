using Client.WPF.Services;
using Client.WPF.ViewModels;
using LightInject;

namespace Client.WPF
{
	public static class WireUp
	{
		public static void ConfigureServices(this IServiceRegistry registry)
		{
			registry.RegisterSingleton<Styles.Theme>();

			registry.RegisterSingleton<MainWindow>();
			registry.RegisterSingleton<MainViewModel>();

			registry.RegisterSingleton<ThemeService>();
			registry.RegisterSingleton<ConnectionService>();
		}
	}
}
