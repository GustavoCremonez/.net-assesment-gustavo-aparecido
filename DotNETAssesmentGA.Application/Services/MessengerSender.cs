using DotNETAssesmentGA.Application.DTOs;
using DotNETAssesmentGA.Application.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace DotNETAssesmentGA.Application.Services
{
    public class MessengerSender : IMessengerSender
    {
        public void QueueMessage(ProductDTO product)
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (IConnection connection = factory.CreateConnection())

            using (IModel channel = connection.CreateModel())
            {
                string name = $"the product with id {(product.Id == 0 ? product._Id : product.Id)} and name {product.Name} has been added";

                channel.QueueDeclare(name, false, false, false, null);

                byte[] body = Encoding.UTF8.GetBytes(name);

                channel.BasicPublish("", name, null, body);
            }
        }
    }
}