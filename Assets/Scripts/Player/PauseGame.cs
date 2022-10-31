using UnityEngine;
using UnityEngine.InputSystem;

public class PauseGame : MonoBehaviour
    {
        public void Pause(InputAction.CallbackContext context)
        {
            GameEvents.current.GamePaused();
        }
    }
