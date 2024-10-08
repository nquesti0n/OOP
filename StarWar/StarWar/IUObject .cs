using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar
{
    public interface IUObject
    {
        public object GetProperty(string name);
        public void SetProperty(string name, object value);
        public void DeleteProperty(string name);
    }

}