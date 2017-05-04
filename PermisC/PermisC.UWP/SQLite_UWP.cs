using System;
using System.IO;
using Xamarin.Forms;
using PermisC.WinPhone;
using Windows.Storage;
using PermisC.Data;

[assembly: Dependency(typeof(SQLite_WinPhone))]


namespace PermisC.WinPhone
{
    public class SQLite_WinPhone : ISQLite
    {
        public SQLite_WinPhone()
        {
        }

        #region ISQLite implementation

        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "RandomThought.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, fileName);

            var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }

        #endregion
    }
}