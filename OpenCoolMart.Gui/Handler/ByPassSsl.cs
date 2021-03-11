using System.Net.Http;

namespace OpenCoolMart.Gui.Handler
{
    public static class ByPassSsl
    {

        public static HttpClientHandler GetHandler()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            return clientHandler;
        }
    }
}