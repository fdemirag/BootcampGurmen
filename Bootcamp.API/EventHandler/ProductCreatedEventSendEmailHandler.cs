using Bootcamp.API.Events;
using MediatR;

namespace Bootcamp.API.EventHandler
{
    public class ProductCreatedEventSendEmailHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly ILogger<ProductCreatedEventSendEmailHandler> _logger;

        public ProductCreatedEventSendEmailHandler(ILogger<ProductCreatedEventSendEmailHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Email Gönderildi:Ürün id={notification.ProductId} Ürün ismi : {notification.ProductName}");

            return Task.CompletedTask;
        }
    }
}
