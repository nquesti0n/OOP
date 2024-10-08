
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hwdtech;

namespace StarWar;

    public interface IMoveCommandEndable
    {
        public BridgeCommand move { get; }
        public IUObject target { get; }
        public IEnumerable<string> property { get; }
    }

public class EndMovementCommand : ICommand
{
    private readonly IMoveCommandEndable allow_end;

    public EndMovementCommand(IMoveCommandEndable allow_end)
    {
        this.allow_end = allow_end;
    }

    public void Execute()
    {
        IoC.Resolve<string>("Game.Command.DeleteUObjectProperties", allow_end.target, allow_end.property);
        IoC.Resolve<IInjectableCommand>("Game.Command.Inject",
            allow_end.move,
            IoC.Resolve<ICommand>("Game.Command.CreateEmpty"));
    }
}
