using Mavlink.Messages;
using Mavlink.Messages.Models;
using System;
using System.IO;
using System.IO.Ports;
using System.Threading.Tasks;

namespace Mavlink.Playground
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FileStream file = File.Open(@"E:\Desktop\Test.txt", FileMode.Open);

            var mavlinkcommunicatorFactory = new MavlinkCommunicatorFactory();

            IMavlinkCommunicator mavlinkCommunicator = mavlinkcommunicatorFactory.Create(file);

            IMessageNotifier messageNotifier = mavlinkCommunicator.SubscribeForReceive(m => m.Id == 0);
            messageNotifier.MessageReceived += MessageReceived;
        }

        private static void MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Message message = e.Message;
        }
    }
}