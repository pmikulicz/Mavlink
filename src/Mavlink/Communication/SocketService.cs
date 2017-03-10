using System.Threading.Tasks;

namespace Mavlink.Communication
{
    internal sealed class SocketService : ICommunicationService
    {
        //        private readonly Socket _socket;
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task WriteAsync(byte[] buffer)
        {
            throw new System.NotImplementedException();
        }

        public int Read(byte[] buffer)
        {
            throw new System.NotImplementedException();
        }
    }
}