using DotNETAssesmentGA.Application.DTOs;

namespace DotNETAssesmentGA.Application.Interfaces
{
    public interface IMessengerSender
    {
        public void QueueMessage(ProductDTO product);
    }
}