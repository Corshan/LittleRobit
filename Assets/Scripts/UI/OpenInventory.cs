using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenInventory : MonoBehaviour
{
    public void onOpenInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameEvents.current.InventoryOpened();
        }
    }
}
