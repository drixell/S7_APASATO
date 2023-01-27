using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace S7_APASATO.models
{
    public class estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(50)]
        public string nombre { get; set; }

        [MaxLength(50)]
        public string usuario { get; set; }

        [MaxLength(50)]
        public string password { get; set; }
    }
}
