using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hwdtech;

namespace StarWar
{

    public class BuildTree : ICommand
    {
        private readonly string _path;

        public BuildTree(string path)
        {
            _path = path;
        }

        public void Execute()
        {
            IoC.Resolve<ITreeBuilder>("Game.CollisionTree.Build").BuildFromFile(_path);
        }
    }
}
