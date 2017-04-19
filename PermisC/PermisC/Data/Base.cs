using System;
using SQLite.Net;

namespace Permis.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}