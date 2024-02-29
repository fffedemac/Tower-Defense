using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using PlaceableSystem;

public class PlayerInputs
{
    
    private PlayerInputActions.PlayerActions _playerInputActions;

    public PlayerInputs()
    {
        _playerInputActions = new PlayerInputActions().Player;
        _playerInputActions.Enable();
        _playerInputActions.MouseSelect.performed += MouseInput;
    }

    private void MouseInput(InputAction.CallbackContext context)
    {
        if (CheckIfTouchingUI()) return;

        PlacePoint placePoint = null;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit rayHit))
        {
            if (rayHit.collider.TryGetComponent(out placePoint))
            {
                if (placePoint.Usable)
                    PlaceableManager.Instance.SelectPoint(placePoint);
                else
                    placePoint = null;
            } 
        }
        
        if (placePoint == null)
            PlaceableManager.Instance.CancelShowingUI();
    }

    private bool CheckIfTouchingUI()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);

        return results.Count > 0;
    }
}
