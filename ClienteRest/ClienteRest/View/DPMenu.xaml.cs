using ClienteRest.Model;
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
	public partial class DPMenu
    {
        public DPMenu(Cliente item)
		{
			InitializeComponent ();
            BindingContext = new DPMenuViewModel(item);
		}
	}
}