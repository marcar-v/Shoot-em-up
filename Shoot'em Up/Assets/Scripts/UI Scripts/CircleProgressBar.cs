using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CircleProgressBar : MonoBehaviour
{
    public delegate void SpecialAttackDelegate();
    public event SpecialAttackDelegate specialAttackReleased;

    [SerializeField] Image _circleFill;
    [SerializeField] int _duration;
    [SerializeField] int _remainingTime;
    bool _pause;
    
    private void Start()
    {
        Begin(_duration);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Begin(_duration);
        }
    }
    void Begin(int second)
    {
        if(specialAttackReleased != null)
        {
            _remainingTime = second;
            StartCoroutine(UpdateTimer());
            specialAttackReleased();
        }
    }

    IEnumerator UpdateTimer()
    {
        while(_remainingTime >= 0)
        {
            if(!_pause)
            {
                _circleFill.fillAmount = Mathf.InverseLerp(0, _duration, _remainingTime);
                _remainingTime--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }

    //bool _isActive = false;
    //float _indicatorTimer;
    //float _maxIndicatorTimer;
    //Image _radialProgressBar;

    //private void Awake()
    //{
    //    _radialProgressBar = GetComponent<Image>();
    //}

    //private void Update()
    //{
    //    if (_isActive && Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        _indicatorTimer -= Time.deltaTime;
    //        _radialProgressBar.fillAmount = (_indicatorTimer / _maxIndicatorTimer);
    //    }

    //    if(_indicatorTimer <= 0)
    //    {
    //        StopCountdown();
    //    }
    //}

    //public void ActivateCountdown(float countdownTime)
    //{
    //    _isActive = true;
    //    _maxIndicatorTimer = countdownTime;
    //    _indicatorTimer = _maxIndicatorTimer;
    //}

    //public void StopCountdown()
    //{
    //    _isActive = false;
    //}
}
