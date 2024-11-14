
using Client.WPF.Services;

namespace Client.WPF.Commands
{
	public class ConnectCommand : AsyncCommand<string>
	{
		private readonly ConnectionService _service;

		public ConnectCommand(ConnectionService service)
		{
			_service = service;
		}

		protected override bool CanExecuteInternal(string? parameter)
		{
			return !string.IsNullOrWhiteSpace(parameter);
		}

		protected override async Task ExecuteInternalAsync(string? parameter)
		{
			await _service.ConnectAsync(parameter!);
		}
	}
}
