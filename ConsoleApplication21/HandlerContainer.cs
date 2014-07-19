using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication21
{
    public class HandlerContainer
    {
        public List<Handler> Handlers;

        private static HandlerContainer current;
        public static HandlerContainer Current
        {
            get
            {
                if (current == null)
                {
                    current = new HandlerContainer();
                }
                return current;
            }
        }

        public HandlerContainer()
        {
            Handlers = new List<Handler>();
            Handlers.Add(handlerA);
            Handlers.Add(handlerB);
        }

        private Handler handlerA = delegate(HttpListenerRequest request, HttpListenerResponse response)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes("<HTML><BODY> Hello ! I'm A</BODY></HTML>");
            response.ContentLength64 = buffer.Length;
            response.StatusCode = 200;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        };
        private Handler handlerB = delegate(HttpListenerRequest request, HttpListenerResponse response)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes("<HTML><BODY> Hello ! I'm B</BODY></HTML>");
            response.ContentLength64 = buffer.Length;
            response.StatusCode = 200;
            response.OutputStream.Write(buffer, 0, buffer.Length);
            response.OutputStream.Close();
        };
    }
    public delegate void Handler(HttpListenerRequest request, HttpListenerResponse response);
}
