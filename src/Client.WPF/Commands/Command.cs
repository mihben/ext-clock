using System.Windows.Input;

namespace Client.WPF.Commands
{
	public abstract class Command<TParameter> : ICommand
	{
		public event EventHandler? CanExecuteChanged;

		public bool CanExecute(object? parameter) => CanExecuteInternal((TParameter?)parameter);
		public void Execute(object? parameter) => ExecuteInternal((TParameter?)parameter);

		protected virtual bool CanExecuteInternal(TParameter? parameter)
		{
			return true;
		}
		protected abstract void ExecuteInternal(TParameter? parameter);
	}
}
