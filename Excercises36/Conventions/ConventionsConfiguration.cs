using System;
using System.Linq;
using NServiceBus;

namespace Conventions
{
    public class ConventionsConfiguration : IWantToRunBeforeConfiguration
    {
        public void Init()
        {
            Configure.Instance.DefiningMessagesAs(type =>
                     type.GetCustomAttributes(true)
                         .Any(t => t.GetType().Name == "MessageAttribute"))
                .DefiningTimeToBeReceivedAs(SetupTTL);
        }

        private TimeSpan SetupTTL(Type t)
        {
            dynamic expression = t.GetCustomAttributes(true)
             .SingleOrDefault(s => s.GetType().Name.Equals("ExpiresAttribute"));

            return expression == null ? TimeSpan.MaxValue : expression.ExpiresAfter;
        }
    }
}