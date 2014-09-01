
using Messages;

namespace HelloWorld
{
    using NServiceBus;

    /*
        This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
        can be found here: http://particular.net/articles/the-nservicebus-host
    */
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Client, IWantCustomInitialization
    {
        public void Init()
        {
            // Changes the namespace in the message itself.
            Configure.Serialization.Xml(s => s.Namespace("http://www.easyjet.com/"));

            // Convention used to resolve the message...
            Configure.With().DefiningMessagesAs(m => m.Assembly == typeof(RequestMessage).Assembly && m.Name.EndsWith("Message"));
        }
    }
}
