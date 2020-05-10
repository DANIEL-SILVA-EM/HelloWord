using Grpc.Core;
using Helloworld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord_Client
{
    class Program
    {
        public static void Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
            var client = new Greeter.GreeterClient(channel);

            var key = string.Empty;
            while (!key.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Escreva seu nome");
                var user = Console.ReadLine();

                var reply = client.SayHello(new HelloRequest { Name = user });

                Console.WriteLine("Saudação: " + reply.Message);

                Console.WriteLine("Entre com \"Q\" para sair ou \"Enter\" para continuar");
                key = Console.ReadLine();
            }
            channel.ShutdownAsync().Wait();
        }
    }
}
