using System;
using SQLite.Net;

namespace PermisC.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}