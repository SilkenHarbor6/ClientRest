using Acr.UserDialogs;
using ClienteRest.Model;
using ClienteRest.Service;
using ClienteRest.View;
using GalaSoft.MvvmLight.Command;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClienteRest.ViewModel
{
    public class DPMenuViewModel
    {
        private Cliente _cliente;
        private ApiService api;
        public DPMenuViewModel(Cliente item)
        {
            _cliente = item;
            api = new ApiService();
        }
        #region Commands
        public ICommand Update
        {
            get
            {
                return new RelayCommand(Actualizar);
            }
        }
        public ICommand Delete
        {
            get
            {
                return new RelayCommand(Eliminar);
            }
        }
        #endregion
        #region Metodo
        public void Actualizar()
        {
            PopupNavigation.PopAsync();
            App.Current.MainPage.Navigation.PushAsync(new AddClient("Actualizar", _cliente));
        }
        public async void Eliminar()
        {
            if (!await UserDialogs.Instance.ConfirmAsync(new ConfirmConfig().SetMessage("Desea eliminar este registro?").SetTitle("Confirmacion").SetOkText("Aceptar").SetCancelText("Cancelar")))
            {
                return;
            }
            bool resp = await api.Delete<Cliente>("Clientes/", _cliente.id_Cliente);
            if (!resp)
            {
               await UserDialogs.Instance.AlertAsync(new AlertConfig().SetMessage("No se ha podido eliminar el registro").SetTitle("Error").SetOkText("Aceptar"));
                return;
            }
            await UserDialogs.Instance.AlertAsync(new AlertConfig().SetMessage("El registro ha sido eliminado").SetTitle("Exito").SetOkText("Aceptar"));
            PopupNavigation.PopAsync();
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
        #endregion
    }
}
