using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;
using System.Configuration;

namespace Microfono
{
    class Program
    {
        static void Main(string[] args)
        {
            NamedPipeClientStream npcs = new NamedPipeClientStream(".", "microfono", PipeDirection.In);
            NamedPipeServerStream npss = new NamedPipeServerStream("mic-aur", PipeDirection.Out);

            //conectamos el cliente
            npcs.Connect();
            //servidor esperando conexion
            npss.WaitForConnection();

            //creamos un reader para el cliente y un writer para el servidor
            StreamReader sr = new StreamReader(npcs);
            StreamWriter sw = new StreamWriter(npss);

            //creamos el mensaje
            string mensaje = sr.ReadLine();
            sw.WriteLine(mensaje);
        }
    }
}
