namespace Client.WPF.Services
{
	public enum Theme
	{
		Light,
		Dark
	}

	public class ThemeService
	{
		private Theme _theme = Theme.Dark;
		public Theme Theme
		{
			get { return _theme; }
			set
			{
				_theme = value;
				ThemeChanged?.Invoke(this, Theme);
			}
		}

		public event EventHandler<Theme>? ThemeChanged;
	}
}
