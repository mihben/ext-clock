using Client.WPF.Commands;
using Client.WPF.Services;
using System.ComponentModel;
using System.Windows.Input;

namespace Client.WPF.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private readonly ThemeService _theme;
		private readonly ConnectionService _connection;

		private string? _port;
		public string? Port
		{
			get { return _port; }
			set { _port = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Port))); }
		}

		public SetThemeToCommand SetThemeTo { get; }
		public ConnectCommand Connect { get; }

		public Theme Theme => _theme.Theme;
		public ConnectionStatus ConnectionStatus => _connection.Status;

		public MainViewModel(ThemeService theme, ConnectionService connection)
		{
			_theme = theme;
			_theme.ThemeChanged += (_, __) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Theme)));

			_connection = connection;
			_connection.StatusChanged += (_, __) =>
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConnectionStatus)));
			};

			SetThemeTo = new SetThemeToCommand(_theme);
			Connect = new ConnectCommand(_connection);
		}
	}

	file class Command<T> : ICommand
	{
		private readonly Func<T, bool> _canExecute;
		private readonly Func<T, Task> _execute;

		public Command(Func<T, bool> canExecute, Func<T, Task> execute)
		{
			_canExecute = canExecute;
			_execute = execute;
		}

		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter)
		{
			return _canExecute((T)parameter);
		}

		public void Execute(object? parameter)
		{
			Task.Run(async () => await _execute((T)parameter));
		}
	}

}
