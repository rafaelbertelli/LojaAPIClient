using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LojaAPIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:53067/api/carrinho/1/produto/6237");
            request.Method = "DELETE";
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);
            Console.Read();
        }

        static void TestaGet()
        {
            string conteudo;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:53067/api/carrinho/1");
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaGetXml()
        {
            string conteudo;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:53067/api/carrinho/1");
            request.Method = "GET";
            request.Accept = "application/xml"; // forca o retorno ser XML
            //request.Accept = "application/json"; // forca o retorno ser JSON

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }
    
        static void TestaGetJson()
        {
            string conteudo;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:53067/api/carrinho/1");
            request.Method = "GET";
            //request.Accept = "application/xml"; // forca o retorno ser XML
            request.Accept = "application/json"; // forca o retorno ser JSON

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaPostJson()
        {
            string conteudo;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:53067/api/carrinho");
            request.Method = "POST";
            //request.Accept = "application/xml"; // forca o retorno ser XML
            request.Accept = "application/json"; // forca o retorno ser JSON

            string json = "{'Produtos':[{'Id':5622,'Preco':1500.0,'Nome':'Colchão\'','Quantidade':4}],'Endereco':'Rua Vergueiro 3185, 8 andar, Sao Paulo','Id':3}";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
            request.GetRequestStream().Write(jsonBytes, 0, jsonBytes.Length);

            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaPostXml()
        {
            string conteudo;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:53067/api/carrinho");
            request.Method = "POST";
            request.Accept = "application/xml"; // forca o retorno ser XML
            //request.Accept = "application/json"; // forca o retorno ser JSON

            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/Loja.Models'><Endereco>Rua Vergueiro 3185, 8 andar, Sao Paulo</Endereco><Id>1</Id><Produtos><Produto><Id>1542</Id><Nome>Bike GTS 26</Nome><Preco>2000</Preco><Quantidade>1</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);

            request.ContentType = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaPostXml2()
        {
            string conteudo;

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.mocky.io/v2/52aaf5deee7ba8c70329fb7d");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:53067/api/carrinho");
            request.Method = "POST";
            request.Accept = "application/xml"; // forca o retorno ser XML
            //request.Accept = "application/json"; // forca o retorno ser JSON

            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/Loja.Models'><Endereco>Rua Vergueiro 3185, 8 andar, Sao Paulo</Endereco><Id>1</Id><Produtos><Produto><Id>1542</Id><Nome>Bike GTS 26</Nome><Preco>2000</Preco><Quantidade>1</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);

            request.ContentType = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.Write(conteudo);
            Console.Read();
        }

        static void TestaPostWebResponse()
        {
            string conteudo;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:53067/api/carrinho");
            request.Method = "POST";
            request.Accept = "application/xml"; // forca o retorno ser XML

            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/Loja.Models'><Endereco>Rua Vergueiro 3185, 8 andar, Sao Paulo</Endereco><Id>1</Id><Produtos><Produto><Id>1542</Id><Nome>Bike GTS 26</Nome><Preco>2000</Preco><Quantidade>1</Quantidade></Produto></Produtos></Carrinho>";
            byte[] xmlBytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlBytes, 0, xmlBytes.Length);

            request.ContentType = "application/xml";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers["Location"]);
            Console.Read();
        }
    }
}
