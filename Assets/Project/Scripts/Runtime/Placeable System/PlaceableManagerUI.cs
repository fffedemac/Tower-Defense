using UnityEngine;
using Entities.Turrets;

namespace PlaceableSystem
{
    public class PlaceableManagerUI : MonoBehaviour
    {
        [SerializeField] private TurretUIButton[] _turretButtons;

        public void ShowPlaceTurretButtons(Turret[] turrets)
        {
            int length = (turrets.Length > _turretButtons.Length) ? _turretButtons.Length : turrets.Length;

            for (int i = 0; i < length; i++)
            {
                _turretButtons[i].gameObject.SetActive(true);
                _turretButtons[i].UpdateTextValues(turrets[i]);
            }
        }

        public void StopShowingTurretButtons()
        {
            foreach (TurretUIButton button in _turretButtons)
                button.gameObject.SetActive(false);
        }
    }
}