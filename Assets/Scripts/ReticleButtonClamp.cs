using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleButtonClamp : MonoBehaviour
{
    // Public Variables

    // Private Variables
    protected int _buttonCounter;
    protected float _timeDelta;
    protected float _firstPress;
    protected float _lastPress;
    protected bool _buttonReady;
    protected bool _buttonSuppress;


    // Start is called before the first frame update
    void Start()
    {
        _buttonCounter = 0;
        _timeDelta = 0.0f;
        _buttonReady = true;
        _buttonSuppress = false;
        _firstPress = 0.0f;
        _lastPress = 0.0f;
    }

    void Update()
    {
        //_buttonCounter = 0;
        //_timeDelta = 0;
        //_buttonReady = true;
        //_buttonSuppress = false;
        _timeDelta += Time.deltaTime;
    }

    protected bool ReticleNormalize()
    {
        Debug.Log("Reticle Clamp Normalization");
        // Update counters
        _buttonCounter++;
        //_timeDelta += Time.deltaTime;

        // Clamp button presses
        if (_buttonCounter > 0)
        {
            if (_firstPress == 0.0f) _firstPress = _timeDelta;
            else _lastPress = _timeDelta;
            // Default state after button press
            if (_buttonSuppress) _buttonReady = false;

            Debug.Log($"button presses over 0: {_buttonCounter}");

            // Calculate delta
            if (_firstPress != 0.0f && _lastPress != 0.0f)
            {
                float timeDelay = _lastPress - _firstPress;
                if (timeDelay > 3.0f)
                {
                    Debug.Log($"time counter over 3: {_timeDelta}");
                    _timeDelta = 0.0f;
                    _buttonCounter = 0;
                    _buttonReady = true;
                    _buttonSuppress = false;
                    _firstPress = 0.0f;
                    _lastPress = 0.0f;
                }
                else
                {
                    _buttonSuppress = true;
                }
            }
            else
            {
                _buttonSuppress = true;
            }

        }

        Debug.Log($"button message state: {_buttonReady}");
        Debug.Log($"button counter: {_buttonCounter}");
        Debug.Log($"first press timedelta: {_firstPress}");
        Debug.Log($"last press timedelta: {_lastPress}");

        return _buttonReady;
    }
}

