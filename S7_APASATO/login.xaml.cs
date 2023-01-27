using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using S7_APASATO.models;

namespace S7_APASATO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        private SQLiteAsyncConnection conn;
        public login()
        {
            InitializeComponent();
            conn = DependencyService.Get<database>().GetConnection();
        }

        public static IEnumerable<estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string password)
        {
            return db.Query<estudiante>("SELECT * FROM estudiante where usuario = ? and password = ?", usuario, password);
        }

        private void btningreso_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<estudiante>();
                IEnumerable<estudiante> resultado = SELECT_WHERE(db, lblusuario.Text, lblpassword.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new consultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Verifique su Usuario o Contraseña", "cerrar");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "cerrar");
            }
        }

        private async void btnregistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registro());
        }
    }
}