using Hwdtech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar
{
    public interface ITreeBuilder
    {
        public void BuildFromFile(string path);
    }

    public class TreeBuilder : ITreeBuilder
    {
        private static IEnumerable<IEnumerable<int>> ReadFileData(string path)
        {
            return File.ReadAllLines(path).Select(line => line.Split().Select(int.Parse));
        }

        public void BuildFromFile(string path)
        {
            ReadFileData(path).ToList().ForEach(vector =>
            {
                var Trie = IoC.Resolve<IDictionary<int, object>>("Game.CollisionTree");

                vector.ToList().ForEach(feature =>
                {
                    Trie.TryAdd(feature, new Dictionary<int, object>());
                    Trie = (IDictionary<int, object>)Trie[feature];
                });
            });
        }
    }
}
