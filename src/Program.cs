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
    class Program
    {
        static void Main(string[] args)
        {
            //ListaRequisicao(); 
            RequisicaoUnica();
            Console.ReadLine();
        }

        //Requisição de vários ids (dados)
        static void ListaRequisicao()
        {
            //Requisição Web para uma URL 
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/");
            requisicao.Method = "GET";  //Requisição direta (Get)
            var resposta = requisicao.GetResponse(); //Resposta da requisição

            //Existem duas formas de trabalhar com requisição web (com ou sem using)
            //Se não utilizar o using, você deverá abrir e fechar as suas conexões web manualmente

            using(resposta) //Abre e fecha automaticamente com a classe web request
            {
                //Pegar os dados da requisição do site
                var stream = resposta.GetResponseStream();

                //Decodificar os dados (ler os dados)
                StreamReader leitor = new StreamReader(stream);

                //Pegar os dados 
                object dados = leitor.ReadToEnd();

                //Converter texto Json em uma lista do tipo classe Tarefa 
                //Tudo será transformado em string
                List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>(dados.ToString());

                //Exibir cada tarefa na lista de Tarefas
                foreach(Tarefa tarefa in tarefas)
                {
                    tarefa.Exibir();
                }

                stream.Close();
                resposta.Close(); //Finalizar com o servidor
            }

            Console.ReadLine();
        }
    
        //Requisição de apenas 1 id (dado)
        static void RequisicaoUnica()
        {
            //Requisição Web para uma URL 
            var requisicao = WebRequest.Create("https://jsonplaceholder.typicode.com/todos/10");
            requisicao.Method = "GET";  //Requisição direta (Get)
            var resposta = requisicao.GetResponse(); //Resposta da requisição

            //Existem duas formas de trabalhar com requisição web (com ou sem using)
            //Se não utilizar o using, você deverá abrir e fechar as suas conexões web manualmente

            using(resposta) //Abre e fecha automaticamente com a classe web request
            {
                //Pegar os dados da requisição do site
                var stream = resposta.GetResponseStream();

                //Decodificar os dados (ler os dados)
                StreamReader leitor = new StreamReader(stream);

                //Pegar os dados 
                object dados = leitor.ReadToEnd();

                //Converter texto Json em uma lista do tipo classe Tarefa 
                //Tudo será transformado em string
                Tarefa tarefa = JsonConvert.DeserializeObject<Tarefa>(dados.ToString());

                //Exibir detalhes da única tarefa
                tarefa.Exibir();

                stream.Close();
                resposta.Close(); //Finalizar com o servidor
            }

            Console.ReadLine();            
        }
    }
}
