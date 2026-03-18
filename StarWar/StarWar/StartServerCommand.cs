using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar;
using Hwdtech;

public class StartServerCommand : ICommand
{
    private readonly int _size;
    public StartServerCommand(int size)
    {
        _size = size;
    }
    public void Execute()
    {
        Enumerable.Range(0, _size).ToList().ForEach(id =>
            
            IoC.Resolve<ICommand>("Server.Thread.Start", id).Execute()
        );
    }
}
