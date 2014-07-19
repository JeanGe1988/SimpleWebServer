using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication21
{
    public class Router
    {
        Dictionary<string, Handler> routerMaps;
        private static Router current;
        public static Router Current
        {
            get
            {
                if (current == null)
                {
                    current = new Router();
                }
                return current;
            }
        }

        public Router()
        {
            routerMaps = new Dictionary<string, Handler>();
            routerMaps.Add("/A/", HandlerContainer.Current.Handlers[0]);
            routerMaps.Add("/B/", HandlerContainer.Current.Handlers[1]);
        }

        public void Route(HttpListenerRequest request, HttpListenerResponse response)
        {
            if (routerMaps.ContainsKey(request.Url.AbsolutePath))
            {
                routerMaps[request.Url.AbsolutePath](request, response);
            }
            else
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes("<HTML><BODY> Oops, Not Found</BODY></HTML>");
                response.ContentLength64 = buffer.Length;
                response.StatusCode = 404;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
        }
    }
}
