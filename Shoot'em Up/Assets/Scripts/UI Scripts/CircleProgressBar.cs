using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleProgressBar : MonoBehaviour
{
    bool _isActive = false;
    float _indicatorTimer;
    float _maxIndicatorTimer;
    Image _radialProgressBar;

    private void Awake()
    {
        _radialProgressBar = GetComponent<Image>();
    }

    private void Update()
    {
        if (_isActive && Input.GetKeyDown(KeyCode.LeftShift))
        {
            _indicatorTimer -= Time.deltaTime;
            _radialProgressBar.fillAmount = (_indicatorTimer / _maxIndicatorTimer);
        }

        if(_indicatorTimer <= 0)
        {
            StopCountdown();
        }
    }

    public void ActivateCountdown(float countdownTime)
    {
        _isActive = true;
        _maxIndicatorTimer = countdownTime;
        _indicatorTimer = _maxIndicatorTimer;
    }

    public void StopCountdown()
    {
        _isActive = false;
    }
}
