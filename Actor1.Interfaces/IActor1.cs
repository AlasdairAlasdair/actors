using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace Actor1.Interfaces
{
    public interface IActor1 : IActor
    {
        Task StartJob();
    }
}
