using System.Threading.Tasks;

namespace Infrastructure.StateMachine
{
    public interface IStateBase
    {
        public Task EnterState();
        public Task ExitState();
    }
}