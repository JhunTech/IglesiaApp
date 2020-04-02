using System;

namespace IglesiaApp
{
    public class HojasDominicalesRest
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Url1 { get; set; }
        public string Url2 { get; set; }
        public string Estado { get; set; }
    }

    public class HojasDominicales
    {
        public string Fecha { get; set; }
        public string Url1 { get; set; }
        public string Url2 { get; set; }
    }

}
