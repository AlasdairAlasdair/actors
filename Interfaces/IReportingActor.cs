using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;

namespace Interfaces
{
    public interface IReportingActor : IActor
    {
        Task SendMessage(string id);
    }
}