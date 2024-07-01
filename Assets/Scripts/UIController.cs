using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using Google.XR.Cardboard;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class UIController : MonoBehaviour
{
    [SerializeField] PlayerCharacter _assignedPlayer;

    [SerializeField] Camera _assignedCamera;

    [SerializeField] UMLPanel _umlPanel;

    [SerializeField] List<GameObject> _umlObjs;

    private Button _button;

    private bool _hudGUIMode;
    private int _score;
    private Label _scoreTextField;
    private string _scoreTextString;
    private Vector2 _speedVector;

    private PlayerController _playerController;


    // Listeners attached during enable or disable
    void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.AddListener(GameEvent.CLOSE_UML_PANEL, CloseUMLView);
        Messenger.AddListener(GameEvent.OPEN_UML_PANEL, OpenUMLView);
        Messenger.AddListener(GameEvent.UML_PANEL_BUTTON, UMLButton);
        Messenger.AddListener(GameEvent.UML_ACTIVE, UMLActive);
        Messenger.AddListener(GameEvent.UML_INACTIVE, UMLInActive);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.RemoveListener(GameEvent.CLOSE_UML_PANEL, CloseUMLView);
        Messenger.RemoveListener(GameEvent.OPEN_UML_PANEL, OpenUMLView);
        Messenger.RemoveListener(GameEvent.UML_PANEL_BUTTON, UMLButton);
        Messenger.RemoveListener(GameEvent.UML_ACTIVE, UMLActive);
        Messenger.RemoveListener(GameEvent.UML_INACTIVE, UMLInActive);
    }

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _hudGUIMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_assignedPlayer == null || _assignedCamera == null)
        {
            Debug.Log("A player or camera object is missing for the UI Controller");
        }
        else
        {
            //if (Api.IsTriggerHeldPressed) Debug.Log("button pressed and held");
            //if (Api.IsTriggerPressed) Debug.Log("simple button press");
            // Check for GUI escape press
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Debug.Log("button pressed and held");
                if (_hudGUIMode)
                {
                    CloseWindows();
                }
                _hudGUIMode = !_hudGUIMode;
            }
            if (_hudGUIMode)
            {
                UMLActive();
            }
            else
            {
                UMLInActive();
            }
        }
    }

    public void LaunchSettings(ClickEvent evt)
    {
        //VisualElement _window = _documentUI.rootVisualElement.Q("ViewScreen") as VisualElement;
        //_window.visible = true;

        //Button _closeButton = _documentUI.rootVisualElement.Q("CloseButton") as Button;
        //_closeButton.visible = true;
    }

    public void CloseSettings(ClickEvent evt)
    {
        //// Check for slider changes
        //MinMaxSlider speedSlider = _documentUI.rootVisualElement.Q("SpeedSlider") as MinMaxSlider;
        //if (_speedVector != speedSlider.value)
        //{
        //    _speedVector = speedSlider.value;
        //    float speed = _speedVector.x;
        //    OnSpeedChange(speed);
        //}

        //TextField nameField = _documentUI.rootVisualElement.Q("PlayerName") as TextField;
        //_scoreTextField = _documentUI.rootVisualElement.Q("Score") as Label;

        //_scoreTextString = $"{nameField.text}'s Score: ";
        //_scoreTextField.text = _scoreTextString + _score.ToString();

        //VisualElement _window = _documentUI.rootVisualElement.Q("ViewScreen") as VisualElement;
        //_window.visible = false;
        //Button _closeButton = _documentUI.rootVisualElement.Q("CloseButton") as Button;
        //_closeButton.visible = false;
    }

    public void LaunchSettings()
    {

    }

    public void CloseWindows()
    {
        //VisualElement _window = _documentUI.rootVisualElement.Q("ViewScreen") as VisualElement;
        //_window.visible = false;
        //Button _closeButton = _documentUI.rootVisualElement.Q("CloseButton") as Button;
        //_closeButton.visible = false;
        //UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        //GameObject cPanel = GameObject.Find("CenterPanel");
        //CanvasGroup canvasGroup = cPanel.GetComponent<CanvasGroup>();

        //canvasGroup.alpha = 0;
        //canvasGroup.interactable = false;
        //Debug.Log("This is the close button");
        //TrackedPoseDriver trackedPose = _assignedCamera.GetComponent<TrackedPoseDriver>();
        //InputTracking.disablePositionalTracking = false;
        //Messenger<float>.Broadcast(GameEvent.CLOSE_UML_PANEL, true);
        //UnityEngine.Cursor.visible = false;
    }

    public void UMLButton()
    {
        if (_hudGUIMode)
        {
            CloseUMLView();
        }
        _hudGUIMode = !_hudGUIMode;
        if (_hudGUIMode)
        {
            OpenUMLView();
        }
    }

    public void CloseUMLView()
    {
        GameObject cPanel = GameObject.Find("CenterPanel");
        CanvasGroup canvasGroup = cPanel.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Debug.Log("This is the close window");
        TrackedPoseDriver trackedPose = _assignedCamera.GetComponent<TrackedPoseDriver>();
        //InputTracking.disablePositionalTracking = false;
        //Messenger<float>.Broadcast(GameEvent.CLOSE_UML_PANEL, true);
        //UnityEngine.Cursor.visible = false;
    }

    public void OpenUMLView()
    {
        GameObject cPanel = GameObject.Find("CenterPanel");
        CanvasGroup canvasGroup = cPanel.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        Debug.Log("This is the open window");
        TrackedPoseDriver trackedPose = _assignedCamera.GetComponent<TrackedPoseDriver>();
        //InputTracking.disablePositionalTracking = false;
        //Messenger<float>.Broadcast(GameEvent.CLOSE_UML_PANEL, true);
        //UnityEngine.Cursor.visible = false;
    }

    public void OnEnemyHit()
    {
        _score += 1;
        _scoreTextField.text = _scoreTextString + _score.ToString();
    }

    public void UMLActive()
    {
        //// Ugly hack to find the Tracked Pose Driver since it is not attached
        //// as a proper component (GetComponent does not work)
        //Component[] components = _assignedCamera.GetComponents(typeof(MonoBehaviour));
        //Debug.Log(components);
        //foreach (Component item in components)
        //{
        //    // Update tracking to position only
        //    if (item.ToString().Contains("TrackedPoseDriver"))
        //    {
        //        TrackedPoseDriver trackedPose = item as TrackedPoseDriver;
        //        trackedPose.trackingType = TrackedPoseDriver.TrackingType.PositionOnly;
        //        Debug.Log("Tracking Type changed to position only");
        //    }
        //}

        Debug.Log("Inside UML Active function");

        PlayerController pc = _assignedPlayer.GetComponent<PlayerController>();
        _playerController = pc;
        Destroy(pc);

    }

    public void UMLInActive()
    {
        //// Ugly hack to find the Tracked Pose Driver since it is not attached
        //// as a proper component (GetComponent does not work)
        //Component[] components = _assignedCamera.GetComponents(typeof(MonoBehaviour));
        //Debug.Log(components);
        //foreach (Component item in components)
        //{
        //    Debug.Log($"Component Name: {item.ToString()}");
        //    // Update tracking to position and rotation
        //    if (item.ToString().Contains("TrackedPoseDriver"))
        //    {
        //        TrackedPoseDriver trackedPose = item as TrackedPoseDriver;
        //        trackedPose.trackingType = TrackedPoseDriver.TrackingType.RotationAndPosition;
        //        Debug.Log("Tracking Type changed to normal");
        //    }
        //}

        Debug.Log("Inside UML InActive function");

        PlayerController pc = _assignedPlayer.GetComponent<PlayerController>();
        if (pc == null)
        {
            _assignedPlayer.gameObject.AddComponent<PlayerController>();
            pc = _playerController;
        }

        
        //PlayerController pc = _assignedPlayer.GetComponent<PlayerController>();
        
    }

    private void OnSpeedChange(float speed)
    {
        // Update settings
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }
}
