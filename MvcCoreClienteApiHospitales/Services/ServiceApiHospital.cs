using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using MvcCoreClienteApiHospitales.Models;
using System.Net.Http;

namespace MvcCoreClienteApiHospitales.Services
{
    public class ServiceApiHospital
    {
        private string url;
        //UN OBJETO EN EL HEADER DE LA PETICION AL API PARA INDICAR QUE ES JSON
        private MediaTypeWithQualityHeaderValue header;

        //OPCION CON LA URL DEL SERVICIO DENTRO DE LA CLASE

        public ServiceApiHospital()
        {
            //LA URL SOLO ES LA DIRECCION WEB DEL ALOJAMIENTO
            this.url = "https://apihospitalesazureafg.azurewebsites.net/";
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        //CONSTRUCTOR RECIBIENDO LA URL DEL SERVICO DESDE STARTUP
        public ServiceApiHospital(string url)
        {
            this.url = url;
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        //METODOS ASINCRONOS
        public async Task<List<Hospital>> GetHospitalesAsync()
        {
            //UTILIZAMOS UN OBJETO HTTPCLIENT PARA LA PETICION
            using  (HttpClient client = new HttpClient())
            {
                string request = "/api/hospitales";
                //ANADIMOS AL OBJETO CLIENT LA DIRECCION URL
                client.BaseAddress = new Uri(this.url);
                //LIMPIAMOS LAS CEBECERAS DE PETICION
                client.DefaultRequestHeaders.Clear();
                //USAMOS EL HEADER PARA INDICAR QUE CONSUMIMOS JSON
                client.DefaultRequestHeaders.Accept.Add(this.header);
                //REALIZAMOS LA PETICION CON EL METODO GET
                //Y NOS DEVOLVERA UNA RESPUESTA HttpResponseMessage
                HttpResponseMessage response = await client.GetAsync(request);
                //SI LA RESPUESTA ES CORRECTA, DEVOLVEMOS LOS DATOS
                if (response.IsSuccessStatusCode)
                {
                    //EN LA PROPIEDAD Content DE LA RESPUESTA VIENEN LOS DATOS
                    //MEDIANTE UN METODO LLAMADO ReadAsync RECUPERAMOS LOS DATOS Y
                    //HACE AUTOMATICAMENTE EL CASTING AL OBJETO
                    List<Hospital> hospitales =
                        await response.Content.ReadAsAsync<List<Hospital>>();
                    return hospitales;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
