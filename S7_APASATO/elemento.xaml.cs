using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using S7_APASATO.models;

namespace S7_APASATO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection conn;
        IEnumerable<estudiante> resulDelete;
        IEnumerable<estudiante> resulUpdate;
        public elemento(int id)
        {
            InitializeComponent();
            conn = DependencyService.Get<database>().GetConnection();
            IdSeleccionado = id;
        }
        public static IEnumerable<estudiante> Delete(SQLiteConnection db, int id)
        {
            return db.Query<estudiante>("DELETE FROM estudiante where id = ?", id);
        }

        public static IEnumerable<estudiante> Update(SQLiteConnection db, string nombre, string usuario, string password, int id)
        {
            return db.Query<estudiante>("UPDATE estudiante SET nombre = ?, usuario = ?, " +
                "password = ? where id = ?", nombre, usuario, password, id);
        }

        private void btnactualiza_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db");
                var db = new SQLiteConnection(databasePath);
                resulUpdate = Update(db, lblnombre.Text, lblusuario.Text, lblpassword.Text, IdSeleccionado);
                DisplayAlert("Alerta", "Se Actualizo Correctamete", "cerrar");
                Navigation.PushAsync(new consultaRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }

        private void btnelimina_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db");
                var db = new SQLiteConnection(databasePath);
                resulDelete = Delete(db, IdSeleccionado);
                DisplayAlert("Alerta", "Se Elimino Correctamete", "cerrar");
                Navigation.PushAsync(new consultaRegistro());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "cerrar");
            }
        }
    }
}