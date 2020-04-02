using SQLite;
using System.Collections.Generic;

namespace IglesiaApp
{
    public class UsuarioDatabase
    {
        readonly SQLiteConnection database;

        public UsuarioDatabase(string dpPath)
        {
            database = new SQLiteConnection(dpPath);
            database.CreateTable<UsuarioItem>();
        }

        public List<UsuarioItem> ListadoUsuarios()
        {
            return database.Table<UsuarioItem>().ToList();
        }
        public UsuarioItem DatosUsuario(string strEmail)
        {
            return database.Table<UsuarioItem>().Where(i => i.Email == strEmail).FirstOrDefault();
        }
        public int GuardarUsuario(UsuarioItem usr)
        {
            return database.Insert(usr);
        }
        public int ModificarUsuario(UsuarioItem usr)
        {
            return database.Update(usr);
        }
        public int BorrarUsuario(UsuarioItem usr)
        {
            return database.Delete(usr);
        }
    }
}
