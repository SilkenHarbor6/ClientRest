using ClienteRest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClienteRest.Service
{
    public class ApiService
    {
        public HttpClient cliente = new HttpClient();
        public async Task<Response> GetAll<T>(String url)
        {
            try
            {
                var response = await cliente.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        isSuccess = false,
                        Message = "Error de respuesta del servidor"
                    };
                }
                var result = await response.Content.ReadAsStringAsync();
                var list = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<T>>(result);
                return new Response
                {
                    isSuccess = true,
                    Result = list
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    isSuccess = false,
                    Message = "Error al cargar los datos"
                };
            }
        }
    }
}
