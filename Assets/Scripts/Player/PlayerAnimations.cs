using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimations : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _animator.SetBool("Walk_Anim", true);
        }
        else
        {
            _animator.SetBool("Walk_Anim", false);
        }
    }
}
