using UnityEngine;
using Entities.Turrets;

namespace PlaceableSystem
{
    public class PlacePoint : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [field: SerializeField] public Turret[] AvailableTurrets { get; private set; }
        public bool Usable { get; set; } = true;

        public void ChangeColor(Color color) => _spriteRenderer.color = color;
    }
}