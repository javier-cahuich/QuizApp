using QuizApp.ViewModel;
using QuizApp.Model;

namespace QuizApp.Views
{
	public partial class NewPage1 : ContentPage
	{
		public NewPage1()
		{
			InitializeComponent();
            BindingContext = new QuizAppViewModel();
        }
	}
}