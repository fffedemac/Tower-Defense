using UnityEngine;
using Entities.Turrets;

namespace PlaceableSystem
{
    [RequireComponent(typeof(PlaceableManagerUI))]
    public class PlaceableManager : MonoBehaviour
    {
        public static PlaceableManager Instance;

        [SerializeField] private Player _player;
        [SerializeField] private PlaceableManagerUI _managerUI;
        private PlacePoint _selectedPoint;

        private void Awake() => Instance = this;

        public void SelectPoint(PlacePoint point) 
        {
            _selectedPoint = point;
            _selectedPoint.ChangeColor(Color.green);

            _managerUI.ShowPlaceTurretButtons(_selectedPoint.AvailableTurrets);
        }

        public void CancelShowingUI()
        {
            _managerUI.StopShowingTurretButtons();

            if (_selectedPoint != null )
                _selectedPoint.ChangeColor(Color.yellow);
        }

        public void SpawnTurret(int turretPos)
        {
            Turret turret = _selectedPoint.AvailableTurrets[turretPos];
            if (_player.Coins >= turret.GetTurretData().Cost)
            {
                Instantiate(_selectedPoint.AvailableTurrets[turretPos].gameObject, _selectedPoint.transform.position, Quaternion.identity);
                _player.UpdateMoney(-turret.GetTurretData().Cost);
                _selectedPoint.Usable = false;
                CancelShowingUI();
            }
        }
    }
}