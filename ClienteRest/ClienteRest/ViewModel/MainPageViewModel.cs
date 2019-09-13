namespace ClienteRest.ViewModel
{
    using Acr.UserDialogs;
    using ClienteRest.Model;
    using ClienteRest.Service;
    using ClienteRest.View;
    using GalaSoft.MvvmLight.Command;
    using Plugin.Connectivity;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class MainPageViewModel:BaseViewModel
    {
        #region Atributos
        private ApiService api;
        private bool isRefreshing;
        #endregion
        #region Propiedades
        public ObservableCollection<Cliente> Clientes { get; set; }
        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value; OnPropertyChanged();
            }
        }
        #endregion
        #region Constructor
        public MainPageViewModel()
        {
            Clientes = new ObservableCollection<Cliente>();
            api = new ApiService();
            LoadClients();
        }
        #endregion
        #region Commandos
        public ICommand Post
        {
            get
            {
                return new RelayCommand(Add);
            }
        }
        #endregion
        #region Metodos
        public async void LoadClients()
        {

            var resp = await api.GetAll<Cliente>("Clientes");
            if (!resp.isSuccess)
            {
                IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", resp.Message, "Aceptar");
                return;
            }
            Clientes = (ObservableCollection<Cliente>)resp.Result;
            IsRefreshing = false;
        }
        public void Add()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddClient());
        }
        #endregion

    }
}
