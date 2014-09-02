using NServiceBus;
using NServiceBus.MessageMutator;

namespace NsbFront
{
    public class AuthenticationMutator : IMutateOutgoingTransportMessages, INeedInitialization
    {
        public void MutateOutgoing(object[] messages, TransportMessage transportMessage)
        {
            // This adds the header to the outgoing message so 
            // that the server can process it (run the authentication).
            transportMessage.Headers["Username"] = "malinda";
        }

        public void Init()
        {
            // We need to manually register mutators in the container.
            // Think about IMessageHandlers, IProvideConfiguration stuff
            // that does not require any explicit configuration.
            Configure.Component<AuthenticationMutator>(DependencyLifecycle.InstancePerCall);
        }
    }
}