using System.Threading;
using Android.Content;
using Android.Net;
using Android.Telephony;
using Java.IO;
using Java.Net;
using Android.App;

namespace PermisC.Droid
{

    /**
	 * Check device's network connectivity and speed
	 * @author emil http://stackoverflow.com/users/220710/emil
	 *
	 */
    public class Connection
    {
        private NetworkState _state;
        
        public NetworkState State
        {
            get
            {
                UpdateNetworkStatus();
                return _state;
            }
        }
        public void UpdateNetworkStatus()
        {
            _state = NetworkState.Unknown;
            // Retrieve the connectivity manager service
            var connectivityManager = (ConnectivityManager)
                Application.Context.GetSystemService(
                    Context.ConnectivityService);
            // Check if the network is connected or connecting.
            // This means that it will be available,
            // or become available in a few seconds.
            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            if (activeNetworkInfo != null &&  activeNetworkInfo.IsConnectedOrConnecting)
            {
                // Now that we know it's connected, determine if we're on WiFi or something else.
                _state = activeNetworkInfo.Type == ConnectivityType.Wifi ?
                    NetworkState.ConnectedWifi : NetworkState.ConnectedData;
            }
            else
            {
                _state = NetworkState.Disconnected;
            }
        }
    }
    public enum NetworkState
    {
        Unknown,
        ConnectedWifi,
        ConnectedData,
        Disconnected
    }
}