using ClienteRest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClienteRest.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddClient : ContentPage
	{
		public AddClient ()
		{
			InitializeComponent ();
            BindingContext = new AddClientViewModel();
		}
	}
}