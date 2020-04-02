using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IglesiaApp
{
    public static class ServiceRest
    {
        private static HttpClient client = new HttpClient();
        private static HttpResponseMessage httpResponse;
        public static async Task<bool> GetLogin(string strEmail, string strPassword)
        {
            ObservableCollection<UsuarioRest> respuestaUsuario = new ObservableCollection<UsuarioRest>();
            bool blnRespuesta = false;
            string strUrl = string.Empty;
            string strContent = string.Empty;
            try
            {                
                strUrl = ConstantesService.UrlBase + ConstantesService.Interroga  + ConstantesService.Action + ConstantesService.strAccionColaboradorLogin + ConstantesService.Ampersand+ ConstantesService.Email + strEmail + ConstantesService.Ampersand + ConstantesService.Password + strPassword;
                httpResponse = await client.GetAsync(strUrl);
                if (httpResponse.IsSuccessStatusCode)
                {
                    strContent = httpResponse.Content.ReadAsStringAsync().Result;
                    if (!strContent.Equals("[]"))
                    {
                        respuestaUsuario = JsonConvert.DeserializeObject<ObservableCollection<UsuarioRest>>(strContent);
                    }
                    else
                    {
                        strUrl = ConstantesService.UrlBase + ConstantesService.Interroga + ConstantesService.Action + ConstantesService.strAccionPersonaLogin + ConstantesService.Ampersand + ConstantesService.Email + strEmail + ConstantesService.Ampersand + ConstantesService.Password + strPassword;
                        httpResponse = await client.GetAsync(strUrl);
                        if (httpResponse.IsSuccessStatusCode)
                        {
                            strContent = httpResponse.Content.ReadAsStringAsync().Result;
                            if (!strContent.Equals("[]"))
                            {
                                respuestaUsuario = JsonConvert.DeserializeObject<ObservableCollection<UsuarioRest>>(strContent);
                            }
                        }
                    }
                }
                else
                {
                    strUrl = ConstantesService.UrlBase + ConstantesService.Action + ConstantesService.strAccionPersonaLogin + ConstantesService.Ampersand + ConstantesService.Email + strEmail + ConstantesService.Ampersand + ConstantesService.Password + strPassword;
                    httpResponse = await client.GetAsync(strUrl);
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        strContent = await httpResponse.Content.ReadAsStringAsync();
                        if (!strContent.Equals("[]"))
                        {
                            respuestaUsuario = JsonConvert.DeserializeObject<ObservableCollection<UsuarioRest>>(strContent);
                        }
                    }
                }
                if (respuestaUsuario != null)
                {
                    App.Current.Resources["emailUsuario"] = strEmail;
                    App.Current.Resources["nombreUsuario"] = respuestaUsuario[0].Nombre;
                    if (!string.IsNullOrEmpty(respuestaUsuario[0].Descripcion))
                    {
                        App.Current.Resources["descripcionUsuario"] = respuestaUsuario[0].Descripcion;
                    }
                    else
                    {
                        App.Current.Resources["descripcionUsuario"] = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(respuestaUsuario[0].Direccion))
                    {
                        App.Current.Resources["direccionUsuario"] = respuestaUsuario[0].Direccion;
                    }
                    else
                    {
                        App.Current.Resources["direccionUsuario"] = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(respuestaUsuario[0].Telefono))
                    {
                        App.Current.Resources["telefonoUsuario"] = respuestaUsuario[0].Telefono;
                    }
                    else
                    {
                        App.Current.Resources["telefonoUsuario"] = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(respuestaUsuario[0].Tipo))
                    {
                        App.Current.Resources["tipoUsuario"] = respuestaUsuario[0].Tipo;
                    }
                    else
                    {
                        App.Current.Resources["tipoUsuario"] = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(respuestaUsuario[0].Url))
                    {
                        App.Current.Resources["urlUsuario"] = respuestaUsuario[0].Url;
                    }
                    else
                    {
                        App.Current.Resources["urlUsuario"] = string.Empty;
                    }
                    blnRespuesta = true;
                    //UsuarioItem userBD = new UsuarioItem
                    //{
                    //    Descripcion = respuestaUsuario[0].Descripcion,
                    //    Direccion = respuestaUsuario[0].Direccion,
                    //    Email = strEmail,
                    //    Nombre = respuestaUsuario[0].Nombre,
                    //    Telefono = respuestaUsuario[0].Telefono,
                    //    Tipo = respuestaUsuario[0].Tipo,
                    //    Url = respuestaUsuario[0].Url
                    //};
                    //App.Database.BorrarUsuario(userBD);
                    //int intGuardarUser = App.Database.GuardarUsuario(userBD);
                    //if (intGuardarUser == 1)//0 si falla
                    //{
                    //    blnRespuesta = true;                        
                    //}
                    //else
                    //{
                    //    blnRespuesta = false;
                    //}
                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error method GetLogin: " + ex.Message);
                blnRespuesta = false;
            }
            return blnRespuesta;
        }
        public static async Task<bool> SavePersona(string strAccion, string strEmail, string strNombre, string strPassword)
        {
            bool blnRespuesta = false;
            string strRespuestaJason = string.Empty;
            RespuestaSaveRest respuestaRest = new RespuestaSaveRest();
            try
            {
                JObject objJson = new JObject
                {
                    { "action", strAccion },
                    { "email", strEmail },
                    { "nombre", strNombre },
                    { "password", strPassword }
                };
                Uri uri = new Uri(string.Format(ConstantesService.UrlBase+ "?action={0}&email={1}&nombre={2}&password={3}", strAccion, strEmail, strNombre, strPassword)); 
                HttpContent content = new StringContent(objJson.ToString(), Encoding.UTF8, "application/json");

                httpResponse = await client.PostAsync(uri, content);
                if (httpResponse.IsSuccessStatusCode)
                {
                    strRespuestaJason = await httpResponse.Content.ReadAsStringAsync();
                    respuestaRest = JsonConvert.DeserializeObject<RespuestaSaveRest>(strRespuestaJason);
                    if (respuestaRest.Status.Equals(ConstantesService.OK))
                    {
                        App.Current.Resources["emailUsuario"] = strEmail;
                        App.Current.Resources["nombreUsuario"] = strNombre;                        
                        blnRespuesta = true;
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Error method SavePersona, statusCode: " + httpResponse.StatusCode);
                    blnRespuesta = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error method SavePersona: " + ex.Message);
                blnRespuesta = false;
            }
            return blnRespuesta;
        }
        public static async Task<ObservableCollection<HojasDominicales>> GetHojasDominicales(DateTime fechaInicio, DateTime fechaFin, int intInicioLimite, int intLongitudLimite)
        {
            ObservableCollection<HojasDominicalesRest> respuestaHojasRest = new ObservableCollection<HojasDominicalesRest>();
            ObservableCollection<HojasDominicales> respuestaHojas = new ObservableCollection<HojasDominicales>();
            string strUrl = string.Empty;
            string strContent = string.Empty;
            try
            {
                strUrl = ConstantesService.UrlBase + ConstantesService.Interroga + ConstantesService.Action + ConstantesService.strAccionHojas + ConstantesService.Ampersand + ConstantesService.FechaInicio + fechaInicio.ToString("yyyy-MM-dd") + ConstantesService.Ampersand + ConstantesService.FechaFin + fechaFin.ToString("yyyy-MM-dd") + ConstantesService.Ampersand + ConstantesService.InicioLimite + intInicioLimite + ConstantesService.Ampersand + ConstantesService.LongitudLimite + intLongitudLimite;
                httpResponse = await client.GetAsync(strUrl);
                if (httpResponse.IsSuccessStatusCode)
                {
                    strContent = httpResponse.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(strContent))
                    {
                        respuestaHojasRest = JsonConvert.DeserializeObject<ObservableCollection<HojasDominicalesRest>>(strContent);
                        foreach (var hoja in respuestaHojasRest)
                        {
                            HojasDominicales hojaDom = new HojasDominicales
                            {
                                Fecha = hoja.Fecha.ToString("yyyy-MM-dd"),
                                Url1 = hoja.Url1,
                                Url2 = hoja.Url2
                            };
                            respuestaHojas.Add(hojaDom);
                        }
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Error method GetHojasDominicales, statusCode: " + httpResponse.StatusCode);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error method GetHojasDominicales: " + ex.Message);
            }
            return respuestaHojas;
        }
        public static async Task<ObservableCollection<GaleriaRest>> GetGaleria(string strAccion, int intSeccion, int intInicioLimite, int intLongitudLimite)
        {
            ObservableCollection<GaleriaRest> respuestaGaleriaRest = new ObservableCollection<GaleriaRest>();
            string strUrl = string.Empty;
            string strContent = string.Empty;
            try
            {
                switch (strAccion)
                {
                    case ConstantesService.AccionGaleria:
                        strUrl = ConstantesService.UrlBase + ConstantesService.Interroga + ConstantesService.Action + ConstantesService.AccionGaleria + ConstantesService.Ampersand + ConstantesService.Seccion + intSeccion;
                        break;
                    case ConstantesService.strAccionGaleriaGrupos:
                        strUrl = ConstantesService.UrlBase + ConstantesService.Interroga + ConstantesService.Action + ConstantesService.strAccionGaleriaGrupos + ConstantesService.Ampersand + ConstantesService.Seccion + intSeccion + ConstantesService.Ampersand + ConstantesService.InicioLimite + intInicioLimite + ConstantesService.Ampersand + ConstantesService.LongitudLimite + intLongitudLimite;
                        break;
                }
                
                httpResponse = await client.GetAsync(strUrl);
                if (httpResponse.IsSuccessStatusCode)
                {
                    strContent = httpResponse.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(strContent))
                    {
                        respuestaGaleriaRest = JsonConvert.DeserializeObject<ObservableCollection<GaleriaRest>>(strContent);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Error method GetGaleria, statusCode: " + httpResponse.StatusCode);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error method GetGaleria: " + ex.Message);
            }
            return respuestaGaleriaRest;
        }
        public static async Task<ObservableCollection<SeccionRest>> GetSeccion()
        {
            ObservableCollection<SeccionRest> respuestaSeccionRest = new ObservableCollection<SeccionRest>();
            string strUrl = string.Empty;
            string strContent = string.Empty;
            try
            {
                strUrl = ConstantesService.UrlBase + ConstantesService.Interroga + ConstantesService.Action + ConstantesService.strAccionSecciones + ConstantesService.Ampersand + ConstantesService.Seccion + ConstantesService.InicioSeccion;

                httpResponse = await client.GetAsync(strUrl);
                if (httpResponse.IsSuccessStatusCode)
                {
                    strContent = httpResponse.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(strContent))
                    {
                        respuestaSeccionRest = JsonConvert.DeserializeObject<ObservableCollection<SeccionRest>>(strContent);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Error method GetSeccion, statusCode: " + httpResponse.StatusCode);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error method GetSeccion: " + ex.Message);
            }
            return respuestaSeccionRest;
        }


    }
}
