using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace S7_APASATO
{
    public interface database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
