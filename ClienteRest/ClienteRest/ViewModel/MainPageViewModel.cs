namespace ClienteRest.ViewModel
{
    using ClienteRest.Model;
    using ClienteRest.Service;
    using System.Collections.ObjectModel;
    public class MainPageViewModel:BaseViewModel
    {
        private ApiService api;
        private bool isRefreshing;
        public ObservableCollection<Cliente> Clientes { get; set; }
        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;OnPropertyChanged();
            }
        }
        public MainPageViewModel()
        {
            Clientes = new ObservableCollection<Cliente>();
            api = new ApiService();
            LoadClients();
        }
        public async void LoadClients()
        {
            var resp = await api.GetAll<Cliente>("http://cdsapirest.somee.com/api/Clientes");
            if (resp.isSuccess)
            {
                IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", resp.Message, "Aceptar");
                return;
            }
            Clientes =(ObservableCollection<Cliente>) resp.Result;
            IsRefreshing = false;
        }
    }
}
