using Gameplay.Utils;
using UnityEngine;

public sealed class BulletFactory : IFactory<Bullet>
{
    private LookUpTable<string, Bullet> _lookUpForBullets;
    private string _type;

    public BulletFactory(string type)
    {
        _type = type;

        if (_lookUpForBullets == null)
            _lookUpForBullets = new LookUpTable<string, Bullet>(SearchPrefab);
    }

    public Bullet Create() => Object.Instantiate(_lookUpForBullets.Get(_type));

    private Bullet SearchPrefab(string name) => Resources.Load<Bullet>("Prefabs/Bullets/" + name);
}
