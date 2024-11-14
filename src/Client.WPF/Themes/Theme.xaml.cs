using Client.WPF.Services;
using System.Windows;

namespace Client.WPF.Styles
{
	partial class Theme : ResourceDictionary
	{
		public ThemeService ThemeSelector { get; }

		public Theme(ThemeService themeSelector)
		{
			ThemeSelector = themeSelector;
			ThemeSelector.ThemeChanged += OnThemeChanged;

			InitializeComponent();
		}

		private void OnThemeChanged(object? sender, Services.Theme theme)
		{
			MergedDictionaries[0].Source = new Uri($"Theme.{theme}.xaml", UriKind.Relative);
		}
	}
}
