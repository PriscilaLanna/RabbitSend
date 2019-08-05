using System;
using System.Text;
using RabbitMQ.Client;

namespace Send
{
    class Send
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using(var connection = factory.CreateConnection())
                using(var channel = connection.CreateModel()){
                    
                    channel.QueueDeclare(   queue:"FilaTeste", 
                                            durable:false, 
                                            exclusive:false, 
                                            autoDelete:false, 
                                            arguments:null);

                    string message = "Mensagem para fila";
                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish( exchange: "ExchangeTeste", 
                                          routingKey: "RoutingKeyTeste",
                                          mandatory:false, 
                                          basicProperties:null,
                                          body: body);

                Console.WriteLine($"Mensagem: {message}");
                }       

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();           
        }       
    }
}
