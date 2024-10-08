using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar;

public interface IQueue
{
    void Add(ICommand cmd);
    ICommand Take();
}
