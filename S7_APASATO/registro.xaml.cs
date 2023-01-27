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
    public partial class registro : ContentPage
    {
        private SQLiteAsyncConnection conn;
        public registro()
        {
            InitializeComponent();
            conn = DependencyService.Get<database>().GetConnection();
        }

        private void btnagregar_Clicked(object sender, EventArgs e)
        {
            var datoregistro = new estudiante { nombre = lblnombre.Text, usuario = lblusuario.Text, password = lblpassword.Text };
            conn.InsertAsync(datoregistro);
            limpiarFormulario();
        }

        void limpiarFormulario()
        {
            lblnombre.Text = "";
            lblusuario.Text = "";
            lblpassword.Text = "";
            DisplayAlert("Alerta", "Se agrego correctamente", "cerrar");
            Navigation.PushAsync(new login());

        }
    }
}