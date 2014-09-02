
using System;
using System.Linq;
using Messages;

namespace HelloWorldServer
{
    using NServiceBus;

    /*
        This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
        can be found here: http://particular.net/articles/the-nservicebus-host
    */
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization, ISpecifyMessageHandlerOrdering
    {
        public void Init()
        {
            Configure.Serialization.Xml(s => s.Namespace("http://www.easyjet2.com/"));

            Configure.With()
                     .DefaultBuilder()
                     .RunCustomAction(() => Configure.Instance.Configurer.ConfigureComponent<ISaySomething>(SaySomethingFactory, DependencyLifecycle.SingleInstance));
        }

        public void SpecifyOrder(Order order)
        {
            order.SpecifyFirst<Auth>();
        }

        private ISaySomething SaySomethingFactory()
        {
            return new SaySomething();
        }
    }
}
