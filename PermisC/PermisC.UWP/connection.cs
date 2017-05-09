using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace PermisC.UWP
{
    static class connection
    {

        public static Boolean IsInternet()
        {
            ConnectionProfile connections = NetworkInformation.GetInternetConnectionProfile();
            Boolean internet = connections != null && connections.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
            return internet;
        }
    }
}
