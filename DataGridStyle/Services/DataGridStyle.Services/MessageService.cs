using DataGridStyle.Services.Interfaces;

namespace DataGridStyle.Services
{
    public class MessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hello from the Message Service";
        }
    }
}
