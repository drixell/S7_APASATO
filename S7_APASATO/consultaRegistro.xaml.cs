using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using S7_APASATO.models;

namespace S7_APASATO
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class consultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection conn;
        private ObservableCollection<estudiante> tableEstudiante;
        public consultaRegistro()
        {
            InitializeComponent();
            conn = DependencyService.Get<database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var resulRegistros = await conn.Table<estudiante>().ToListAsync();
            tableEstudiante = new ObservableCollection<estudiante>(resulRegistros);
            ListaUsuarios.ItemsSource = tableEstudiante;
            base.OnAppearing();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (estudiante)e.SelectedItem;
            var item = obj.id.ToString();
            int Id = Convert.ToInt32(item);

            try
            {
                Navigation.PushAsync(new elemento(Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }
    }
}