using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Handlers
{
    public class HandlerBase
    {
        protected HttpListenerRequest Request { get; set; }
        protected HttpListenerResponse Response { get; set; }

        public virtual void Render()
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes("<HTML><BODY> Hello ! I'm Base</BODY></HTML>");
            Response.ContentLength64 = buffer.Length;
            Response.StatusCode = 200;
            Response.OutputStream.Write(buffer, 0, buffer.Length);
            Response.OutputStream.Close();
        }
    }
}
