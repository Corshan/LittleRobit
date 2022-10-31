using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
    {
        public void Pause(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
            GameEvents.current.GamePaused();
                
            }
        }
    }
