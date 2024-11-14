using Client.WPF.Services;

namespace Client.WPF.Commands
{
	public class SetThemeToCommand : Command<Theme>
	{
		private readonly ThemeService _service;

		public SetThemeToCommand(ThemeService service)
		{
			_service = service;
		}

		protected override void ExecuteInternal(Theme parameter)
		{
			_service.Theme = parameter;
		}
	}
}
