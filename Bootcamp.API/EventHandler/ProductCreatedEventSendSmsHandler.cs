using Bootcamp.API.Events;
using MediatR;

namespace Bootcamp.API.EventHandler
{
    public class ProductCreatedEventSendSmsHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ILogger<ProductCreatedEventSendSmsHandler> _logger;

        public ProductCreatedEventSendSmsHandler(ILogger<ProductCreatedEventSendSmsHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Sms Gönderildi : Ürün id={notification.ProductId} Ürün ismi : {notification.ProductName}");

            return Task.CompletedTask;
        }
    }
}
