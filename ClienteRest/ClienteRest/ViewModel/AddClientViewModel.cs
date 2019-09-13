using Acr.UserDialogs;
using ClienteRest.Model;
using ClienteRest.Service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClienteRest.ViewModel
{
    public class AddClientViewModel:BaseViewModel
    {
        #region Atributo
        private string _nombre { get; set; }
        private string _apellido { get; set; }
        private string _direccion { get; set; }
        private string _telefono { get; set; }
        private ApiService api;
        #endregion
        #region Propiedad
        public string nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;OnPropertyChanged("nombre");
            }
        }
        public string apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;OnPropertyChanged("apellido");
            }
        }
        public string direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;OnPropertyChanged("direccion");
            }
        }
        public string telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;OnPropertyChanged();
            }
        }
        #endregion
        #region Constructor
        public AddClientViewModel()
        {
            api = new ApiService();
        }
        #endregion
        #region Comando
        public ICommand Post
        {
            get
            {
                return new RelayCommand(Add);
            }
        }
        #endregion
        #region Metodo
        public async void Add()
        {
            ConfirmConfig conf = new ConfirmConfig();
            conf.OkText = "Aceptar";
            conf.Title = "Error";
            if (String.IsNullOrEmpty(nombre))
            {
                await UserDialogs.Instance.ConfirmAsync(conf.Message="El nombre no puede quedar vacio");
                return;
            }
            if (String.IsNullOrEmpty(apellido))
            {
                await UserDialogs.Instance.ConfirmAsync(conf.Message = "El apellido no puede quedar vacio");
                return;
            }
            if (String.IsNullOrEmpty(direccion))
            {
                await UserDialogs.Instance.ConfirmAsync(conf.Message = "la direccion no puede quedar vacio");
                return;
            }
            if (String.IsNullOrEmpty(telefono))
            {
                await UserDialogs.Instance.ConfirmAsync(conf.Message = "El telefono no puede quedar vacio");
                return;
            }
            Cliente oCli = new Cliente
            {
                nombre = nombre,
                apellido = apellido,
                direccion = direccion,
                telefono = telefono,
                email = "abc",
                fecha_nacimiento = DateTime.Now
            };
            var resp = await api.Post<Cliente>("Clientes",oCli);
            if (!resp)
            {
                conf.Message = "No se ha podido agregar el cliente";
                conf.Title = "Error";
                await UserDialogs.Instance.ConfirmAsync(conf);
                return;
            }
            conf.Message="El cliente ha sido agregado exitosamente";
            conf.Title = "Exito";
            await UserDialogs.Instance.ConfirmAsync(conf);
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
        #endregion
    }
}
