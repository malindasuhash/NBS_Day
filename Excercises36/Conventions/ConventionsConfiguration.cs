using System;
using System.Linq;
using System.Reflection;
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
                .DefiningTimeToBeReceivedAs(SetupTTL)
                .DefiningEncryptedPropertiesAs(EncryptionInfo)
                .RijndaelEncryptionService();
        }

        private bool EncryptionInfo(PropertyInfo propertyInfo)
        {
            var p = propertyInfo.GetCustomAttributes(true)
                                .Any(t => t.GetType().Name.Equals("EncryptedAttribute"));

            return p;
        }

        private TimeSpan SetupTTL(Type t)
        {
            dynamic expression = t.GetCustomAttributes(true)
             .SingleOrDefault(s => s.GetType().Name.Equals("ExpiresAttribute"));

            return expression == null ? TimeSpan.MaxValue : expression.ExpiresAfter;
        }
    }
}