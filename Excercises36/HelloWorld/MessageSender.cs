using Messages;
using NServiceBus;
using NServiceBus.Logging;

namespace HelloWorld
{
    public class MessageSender : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }
        
        public void Start()
        {
            var msg = new Request()
                {
                    SaySomething = "SAY SOMETHING!!"
                };

            Bus.OutgoingHeaders["Username"] = "malinda"; // Authorisation

            Bus.Send(msg);

            LogManager.GetLogger("MessageSender").Info("Sent message.");

        }

        public void Stop()
        {
           
        }
    }
}