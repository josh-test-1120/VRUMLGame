//-----------------------------------------------------------------------
// <copyright file="CardboardStartup.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using Google.XR.Cardboard;
using UnityEngine;

/// <summary>
/// Initializes Cardboard XR Plugin.
/// </summary>
public class CardboardStartup : MonoBehaviour
{
    private int _buttonCounter;
    private bool _buttonReady;
    private int _frameCounter;
    private bool _umlActive;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        // Configures the app to not shut down the screen and sets the brightness to maximum.
        // Brightness control is expected to work only in iOS, see:
        // https://docs.unity3d.com/ScriptReference/Screen-brightness.html.
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;

        // Checks if the device parameters are stored and scans them if not.
        if (!Api.HasDeviceParams())
        {
            Api.ScanDeviceParams();
        }
        // Set the button held timer to a lower setting
        Api.MinTriggerHeldPressedTime = 1.0;
        _buttonCounter = 0;
        _frameCounter = 0;
        _buttonReady = true;
        _umlActive = false;
    }

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {
        // Update frame counter
        _frameCounter++;

        if (Api.IsGearButtonPressed)
        {
            Api.ScanDeviceParams();
        }

        if (Api.IsCloseButtonPressed)
        {
            Application.Quit();
        }

        if (Api.IsTriggerHeldPressed)
        {
            Debug.Log("button pressed and held");
            Debug.Log($"This is the hold time: {Api.MinTriggerHeldPressedTime}");
            Messenger.Broadcast(GameEvent.MOVEMENT_NOTIFY);
            //Api.MinTriggerHeldPressedTime = 1.0;
            if (_umlActive)
            {
                Messenger.Broadcast(GameEvent.FREEZE_MOVEMENT);
                
                //_umlActive = !_umlActive;
            }
            else
            {
                Messenger.Broadcast(GameEvent.FREEZE_MOVEMENT);
                //_umlActive = !_umlActive;
            }
            _umlActive = !_umlActive;
            //Api.Recenter();
        }
        if (Api.IsTriggerPressed)
        {
            _buttonCounter++;
            if (_buttonCounter >= 1)
            {
                Debug.Log($"button presses over 1: {_buttonCounter}");
                if (_frameCounter > 5)
                {
                    Debug.Log($"frame counter over 5: {_frameCounter}");
                    _frameCounter = 0;
                    _buttonReady = true;
                }
                else
                {
                    _buttonReady = false;
                }
            }
            if (_buttonReady)
            {
                Debug.Log($"button message state: {_buttonReady}");
                _buttonReady = false;
                _buttonCounter = 0;
                //Messenger.Broadcast(GameEvent.UML_PANEL_BUTTON);
            }
            Debug.Log("simple button press");
            Debug.Log($"button counter: {_buttonCounter}");
            Debug.Log($"frame counter: {_frameCounter}");
            //Api.Recenter();
        }
        if (Api.HasNewDeviceParams())
        {
            Api.ReloadDeviceParams();
        }
        #if !UNITY_EDITOR
            Api.UpdateScreenParams();
        #endif
    }
}
