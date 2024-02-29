using UnityEngine;
using Gameplay.Utils;

namespace Entities.Enemies
{
    public sealed class EnemyFactory : IFactory<Enemy>
    {
        private LookUpTable<string, Enemy> _lookUpForEnemies;
        private string _type;

        public EnemyFactory(string type)
        {
            _type = type;

            if (_lookUpForEnemies == null)
                _lookUpForEnemies = new LookUpTable<string, Enemy>(SearchPrefab);
        }

        public Enemy Create() => Object.Instantiate(_lookUpForEnemies.Get(_type));

        private Enemy SearchPrefab(string name) => Resources.Load<Enemy>("Prefabs/Enemies/" + name);
    }
}
