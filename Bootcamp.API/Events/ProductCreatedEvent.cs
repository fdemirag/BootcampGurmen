using MediatR;

namespace Bootcamp.API.Events
{
    public class ProductCreatedEvent : INotification
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
