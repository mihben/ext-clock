namespace Client.WPF.Services
{
	public enum ConnectionStatus
	{
		Disconnected,
		Connected,
		Connecting
	}


	public class ConnectionService
	{
		private ConnectionStatus _status = ConnectionStatus.Disconnected;
		public ConnectionStatus Status
		{
			get { return _status; }
			set
			{
				_status = value;
				StatusChanged?.Invoke(this, Status);
			}
		}

		public event EventHandler<ConnectionStatus>? StatusChanged;

		public async Task ConnectAsync(string port)
		{
			Status = ConnectionStatus.Connecting;
			await Task.Delay(10000);
			Status = ConnectionStatus.Connected;
		}
	}
}
