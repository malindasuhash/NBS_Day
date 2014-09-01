
using NServiceBus;
using NServiceBus.Logging;

namespace HelloWorld
{
    using NServiceBus;

	/*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
    public class EndpointConfig : IWantCustomLogging, IConfigureThisEndpoint, IWantToRunWhenBusStartsAndStops, AsA_Client
    {
	    public void Start()
	    {
            LogManager.GetLogger("EndpointConfig").Info("Hello World!");
	    }

	    public void Stop()
	    {
	       
	    }

	    public void Init()
	    {
            SetLoggingLibrary.Log4Net(() => log4net.Config.XmlConfigurator.Configure());
	    }
    }
}
