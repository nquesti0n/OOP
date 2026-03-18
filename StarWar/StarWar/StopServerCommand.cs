using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar;
using System.Collections.Concurrent;
using Hwdtech;

public class StopServerCommand : ICommand
{
    public void Execute()
    {
       
        var threadQueues = IoC.Resolve<ConcurrentDictionary<int, BlockingCollection<ICommand>>>("Server.Thread.SenderDictionary");

        threadQueues.ToList().ForEach(sender =>
            IoC.Resolve<ICommand>(
                "Server.Thread.SendCommand",
                
                sender.Key,
               
                IoC.Resolve<ICommand>("Server.Thread.SoftStop", sender.Key, IoC.Resolve<Action>("Server.Thread.SoftStop.Action"))
            ).Execute()
        );
    }
}
