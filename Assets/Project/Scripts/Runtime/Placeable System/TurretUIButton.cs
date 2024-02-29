using UnityEngine;
using Entities.Turrets;
using TMPro;

namespace PlaceableSystem
{
    public class TurretUIButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _turretName;
        [SerializeField] private TMP_Text _turretCost;

        public void UpdateTextValues(Turret turret)
        {
            _turretName.text = "Add\n" + turret.name;
            _turretCost.text = turret.GetTurretData().Cost + " coins";
        }
    }
}
