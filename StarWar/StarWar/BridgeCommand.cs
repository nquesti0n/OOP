using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar
{
    public interface IInjectableCommand
    {
        public void Inject(ICommand obj);
    }

    public class BridgeCommand : ICommand, IInjectableCommand
    {
        private ICommand internalCommand;
        public BridgeCommand(ICommand command)
        {
            internalCommand = command;
        }
        public void Inject(ICommand other)
        {
            internalCommand = other;
        }
        public void Execute()
        {
            internalCommand.Execute();
        }
    }
}
