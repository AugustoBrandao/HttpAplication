using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; //Converter texto Json para objeto C# 

namespace HttpAplication
{
    class Tarefa
    {
        public int userId;
        public int id;
        public string title;
        public bool completed;

        public void Exibir()
        {
            Console.WriteLine(" -- OBJETO TAREFA -- ");
            Console.WriteLine($"User id:  {userId}");
            Console.WriteLine($"Id:       {id}");
            Console.WriteLine($"Title:    {title}");
            Console.WriteLine($"Finalizou:{completed}");
            Console.WriteLine(" ");
            Console.WriteLine("---------------------");
        }
    }
}