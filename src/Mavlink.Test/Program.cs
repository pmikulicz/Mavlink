using Mavlink.Messages.Configuration;

namespace Mavlink.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var hbConfiguration = new HeartbeatMessageConfiguration();

            hbConfiguration.Configure();

            var messageDetails = ((IMessageDetailsProvider)hbConfiguration).Provide();
            
        }
    }
}