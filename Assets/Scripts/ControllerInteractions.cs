using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using static UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation.XRDeviceSimulator;

public class ControllerInteractions : MonoBehaviour
{
    static readonly Dictionary<string, InputFeatureUsage<bool>> availableButtons = new Dictionary<string, InputFeatureUsage<bool>>
        {
            {"triggerButton", UnityEngine.XR.CommonUsages.triggerButton },
            {"thumbrest", UnityEngine.XR.CommonUsages.thumbrest },
            {"primary2DAxisClick", UnityEngine.XR.CommonUsages.primary2DAxisClick },
            {"primary2DAxisTouch", UnityEngine.XR.CommonUsages.primary2DAxisTouch },
            {"menuButton", UnityEngine.XR.CommonUsages.menuButton },
            {"gripButton", UnityEngine.XR.CommonUsages.gripButton },
            {"secondaryButton", UnityEngine.XR.CommonUsages.secondaryButton },
            {"secondaryTouch", UnityEngine.XR.CommonUsages.secondaryTouch },
            {"primaryButton", UnityEngine.XR.CommonUsages.primaryButton },
            {"primaryTouch", UnityEngine.XR.CommonUsages.primaryTouch },
        };

    public enum ButtonOption
    {
        triggerButton,
        thumbrest,
        primary2DAxisClick,
        primary2DAxisTouch,
        menuButton,
        gripButton,
        secondaryButton,
        secondaryTouch,
        primaryButton,
        primaryTouch
    };

    [Tooltip("Button Mapped")]
    public InputActionReference button;

    // to check whether it's being pressed
    public bool IsPressed { get; private set; }
    bool inputValue;

    List<UnityEngine.XR.InputDevice> inputDevices;
    InputFeatureUsage<bool> inputFeature;

    // Start is called before the first frame update
    void Start()
    {
        // get label selected by the user
        string featureLabel = Enum.GetName(typeof(ButtonOption), ButtonOption.triggerButton);
        Debug.Log($"Feature Label: {featureLabel}");
        // find dictionary entry
        availableButtons.TryGetValue(featureLabel, out inputFeature);

        Debug.Log($"input feature: {inputFeature}");

        // init list
        inputDevices = new List<UnityEngine.XR.InputDevice>();
        Debug.Log("Trigger Interaction Script");
        foreach (UnityEngine.XR.InputDevice item in inputDevices)
        {
            Debug.Log($"Item string: {item.ToString()}");
        }
        InputDevices.GetDevices(inputDevices);
        foreach (var item in inputDevices)
        {
            Debug.Log($"Device found with name '{item.name}' and role '{item.role.ToString()}'");
        }
        var device = new UnityEngine.XR.InputDevice();
        var devices = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand,
            devices);
        if (devices.Count == 1)
        {
            device = devices[0];
            Debug.Log($"Device name '{device.name}' with role '{device.role.ToString()}'");
        }
        else if (devices.Count > 1)
        {
            Debug.Log($"Found more than one '{device.role.ToString()}'!");
            device = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        InputDevices.GetDevicesWithRole(InputDeviceRole.LeftHanded, inputDevices);

        //Debug.Log($"input device count: {inputDevices.Count}");

        for (int i = 0; i < inputDevices.Count; i++)
        {
            Debug.Log($"input devices: {inputDevices[i]}");
            if (inputDevices[i].TryGetFeatureValue(inputFeature,
                out inputValue) && inputValue)
            {
                Debug.Log($"Input Action: {inputValue}");
                // if start pressing, trigger event
                if (!IsPressed)
                {
                    IsPressed = true;
                    Debug.Log("Trigger Pressed");
                }
            }

            // check for button release
            else if (IsPressed)
            {
                IsPressed = false;
                Debug.Log("Trigger Released");
            }
        }
    }

    private void OnEnable()
    {
        button.action.started += MenuPressed;
    }

    private void OnDisable()
    {
        button.action.started -= MenuPressed;

    }

    private void MenuPressed(InputAction.CallbackContext context)
    {
        Debug.Log("MenuPressed!");
        Debug.Log(context);
    }
}
