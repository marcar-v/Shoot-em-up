using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public delegate void SpecialAttackDelegate();
    public event SpecialAttackDelegate specialAttackReleased;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (specialAttackReleased != null)
            {
                Debug.Log("Bomb Released");
                specialAttackReleased();
            }
        }
    }
}
