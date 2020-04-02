namespace IglesiaApp
{
    public class ConstantesService
    {
        #region Urls
        public const string UrlBase = "https://santaritaservice.000webhostapp.com/index.php";
        //public const string strUrlAccion = "https://santaritaservice.000webhostapp.com/index.php?action={0}";
        //public const string strUrlId = "https://santaritaservice.000webhostapp.com/index.php?action={0}&id={1}";
        //public const string strUrlFechas = "https://santaritaservice.000webhostapp.com/index.php?action={0}&fInicio={1}&fFin={2}";
        //public const string strUrlIdDesc = "https://santaritaservice.000webhostapp.com/index.php?action={0}&id={1}&desc={2}";
        //public const string strUrlGuardarCI = "https://santaritaservice.000webhostapp.com/index.php?action={0}&cedula={1}&nombre={2}&telf={3}&email={4}";
        //public const string strUrlActualizarCI = "https://santaritaservice.000webhostapp.com/index.php?action={0}&id={1}&cedula={2}&nombre={3}&telf={4}&email={5}";
        #endregion

        #region Identificadores Paginas    
        public const string strIdSeccionInicio = "1";
        public const string strIdSeccionIglesia = "2";
        public const string strIdSeccionGaleria = "3";
        public const string strIdDataIglesia = "1";
        #endregion

        #region Acciones
        public const string strAccionPersonaLogin = "PERSONA_LOGIN";
        public const string strAccionColaboradorLogin = "COLABORADOR_LOGIN";
        public const string strAccionInsertarLogin = "INSERTAR_LOGIN";
        public const string strAccionActualizarLogin = "ACTUALIZAR_LOGIN";
        public const string strAccionInsertar = "INSERTAR";
        public const string strAccionActualizar = "ACTUALIZAR";
        public const string strAccionIglesia = "IGLESIA";
        public const string strAccionPersona = "PERSONA"; 
        public const string strAccionPersonas = "PERSONAS";
        public const string AccionGaleria = "GALERIA";
        public const string strAccionSecciones = "SECCIONES";
        public const string strAccionGaleriaGrupos = "GALERIA_GRUPOS";
        public const string strAccionColaborador = "COLABORADOR";
        public const string strAccionCursos = "CURSOS";
        public const string strAccionNoticias = "NOTICIA";
        public const string strAccionProducto = "PRODUCTO";
        public const string strAccionEucaristia = "EUCARISTIA";
        public const string strAccionHojas = "HOJAS";
        public const string strAccionPushNoticia = "NNOTICIA";
        public const string strAccionPushCursos = "NCURSOS";
        public const string strAccionPushProducto = "NPRODUCTO";
        #endregion

        #region BDD
        public const string strBDDName = "IglesiaBdd.db3";
        #endregion

        #region Texto Url
        public const string Action = "action=";
        public const string Email = "email=";
        public const string Password = "password=";
        public const string Ampersand = "&";
        public const string Interroga = "?";
        public const string OK = "OK";
        public const string FechaInicio = "fInicio=";
        public const string FechaFin = "fFin=";
        public const string InicioLimite = "iLimite=";
        public const string LongitudLimite = "lLimite=";
        public const string Seccion = "seccion=";
        public const int InicioSeccion = 3;
        #endregion
    }
    public class ConstantesMensajes
    {
        #region Texto
        public const string Error = "Error";
        public const string Aceptar = "Aceptar";
        public const string Atencion = "Atención";
        public const string Bienvenido = "Bienvenido(a)";
        #endregion

        #region Errores
        public const string ErrorCamposObligatorios = "Todos los campos son obligatorios";
        public const string ErrorUsuarioNoEncontrado = "Usuario o Password incorrectos";
        public const string ErrorPasswordsDiferentes = "El password1 y el password2 deben ser iguales";
        public const string ErrorAlmacenarPersona = "No se pudo almacenar los datos personales, intentalo más tarde";
        #endregion

        #region Mensajes
        public const string MensajePersonaAlmacenada = "Datos personales almacenados correctamente";
        #endregion
    }
}
