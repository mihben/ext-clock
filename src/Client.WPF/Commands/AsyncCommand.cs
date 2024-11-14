using System.Windows.Input;

namespace Client.WPF.Commands
{
	public abstract class AsyncCommand<TParameter> : ICommand
	{
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter) => CanExecuteInternal((TParameter?)parameter);
		public void Execute(object? parameter) => Task.Run(async () => await ExecuteInternalAsync((TParameter?)parameter));

		protected virtual bool CanExecuteInternal(TParameter? parameter)
		{
			return true;
		}

		protected abstract Task ExecuteInternalAsync(TParameter? parameter);
	}
}
