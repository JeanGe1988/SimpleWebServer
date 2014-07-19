using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication21
{
    public class Server
    {
        private static Server current;
        public static Server Current
        {
            get
            {
                if (current == null)
                {
                    current = new Server();
                }
                return current;
            }
        }
        public void Start()
        {
            string[] prefixes = { "http://localhost:8011/" };
            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Windows XP SP2 or Server 2003 is required to use the HttpListener class.");
                return;
            }

            // Create a listener.
            HttpListener listener = new HttpListener();
            // Add the prefixes.
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            Console.WriteLine("Listening...");
            int count = 0;
            while (true)
            {
                count++;
                // Note: The GetContext method blocks while waiting for a request. 
                HttpListenerContext context = listener.GetContext();

                Router.Current.Route(context.Request, context.Response);
            }
            listener.Stop();
        }
    }
}
