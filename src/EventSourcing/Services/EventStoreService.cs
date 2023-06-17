using EventSourcing.Interfaces;
using EventStore.ClientAPI;
using Microsoft.Extensions.Configuration;

namespace EventSourcing.Services
{
    public sealed class EventStoreService : IEventStoreService
    {
        private readonly IEventStoreConnection _connection;

        public EventStoreService(IConfiguration configuration)
        {
            var connection = configuration
                .GetConnectionString("EventStoreConnection");

            _connection = EventStoreConnection
                .Create(connection);

            _connection
                .ConnectAsync()
                .Wait();
        }

        public IEventStoreConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
