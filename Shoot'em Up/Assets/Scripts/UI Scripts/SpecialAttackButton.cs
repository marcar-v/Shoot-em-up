using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAttackButton : MonoBehaviour
{
    [SerializeField] GameObject specialAttack;
    bool specialAttackAvaliable;
    [SerializeField] float duration;

    private void Start()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            CanUseSpecialAttack(duration);
        }
    }

    void CanUseSpecialAttack(float duration)
    {
        specialAttackAvaliable = true;
        specialAttack.SetActive(true);

        StartCoroutine(CantUseSpecialAttack(duration));
    }

    public IEnumerator CantUseSpecialAttack(float delay)
    {
        yield return new WaitForSeconds(delay);

        specialAttackAvaliable = false;
        specialAttack.SetActive(false);
    }
}
