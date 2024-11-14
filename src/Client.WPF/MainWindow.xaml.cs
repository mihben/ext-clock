using Client.WPF.ViewModels;
using System.Windows;

namespace Client.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow(Styles.Theme theme, MainViewModel viewModel)
		{
			Resources.MergedDictionaries.Add(theme);

			DataContext = viewModel;

			InitializeComponent();
		}
	}
}