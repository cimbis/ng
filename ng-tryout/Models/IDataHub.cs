using System;
using System.Threading.Tasks;

namespace Ngtryout.Models
{
    public interface IDataHub
    {
        bool Equals(object obj);
        int GetHashCode();
        Task OnConnectedAsync();
        Task OnDisconnectedAsync(Exception exception);
        string ToString();
    }
}