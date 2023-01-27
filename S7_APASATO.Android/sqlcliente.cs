using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SQLite;
using S7_APASATO.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(sqlcliente))]

namespace S7_APASATO.Droid
{
    public class sqlcliente : database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "uisrael.db");
            return new SQLiteAsyncConnection(path);
        }
    }
}