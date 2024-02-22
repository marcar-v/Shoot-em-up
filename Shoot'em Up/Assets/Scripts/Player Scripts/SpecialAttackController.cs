using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttackController : MonoBehaviour
{
    public delegate void SpecialAttackDelegate();
    public event SpecialAttackDelegate specialAttackReleased;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (specialAttackReleased != null)
            {
                specialAttackReleased();
            }
        }
    }
}
