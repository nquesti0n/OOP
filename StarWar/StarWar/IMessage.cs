using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar;

public interface IMessage
{
    public string OrderType
    {
        get;
    }

    public string GameID
    {
        get;
    }

    public string GameItemID
    {
        get;
    }

    public IDictionary<string, object> Properties
    {
        get;
    }
}