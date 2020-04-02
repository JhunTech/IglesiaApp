using System;
using System.Collections.Generic;
using System.Text;

namespace IglesiaApp
{
    public class GaleriaRest
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int Orden { get; set; }
        public int Estado { get; set; }
        public string Descripcion { get; set; }
        public int Id_Dispositivo { get; set; }
        public int Id_Seccion { get; set; }
    }
}
