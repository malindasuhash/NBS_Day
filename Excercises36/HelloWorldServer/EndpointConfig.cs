
using Messages;

namespace HelloWorldServer
{
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.Serialization.Xml(s => s.Namespace("http://www.easyjet2.com/"));

            Configure.With()
                .DefiningMessagesAs(t => t.Assembly == typeof(RequestMessage).Assembly
                                       && t.Name.EndsWith("Message"));
        }
    }
}