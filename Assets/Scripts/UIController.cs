using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Google.XR.Cardboard;
using UnityEngine.SpatialTracking;
using UnityEngine.XR;

public class UIController : MonoBehaviour
{
    [SerializeField] PlayerCharacter _assignedPlayer;

    [SerializeField] Camera _assignedCamera;

    [SerializeField] UMLPanel _umlPanel;

    private Button _button;

    private bool _hudGUIMode;
    private int _score;
    private Label _scoreTextField;
    private string _scoreTextString;
    private Vector2 _speedVector;


    // Listeners attached during enable or disable
    void OnEnable()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.AddListener(GameEvent.CLOSE_UML_PANEL, CloseUMLView);
        Messenger.AddListener(GameEvent.OPEN_UML_PANEL, OpenUMLView);
        Messenger.AddListener(GameEvent.UML_PANEL_BUTTON, UMLButton);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
        Messenger.RemoveListener(GameEvent.CLOSE_UML_PANEL, CloseUMLView);
        Messenger.RemoveListener(GameEvent.OPEN_UML_PANEL, OpenUMLView);
        Messenger.RemoveListener(GameEvent.UML_PANEL_BUTTON, UMLButton);
    }

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _hudGUIMode = false;
        //_umlPanel = new UMLPanel();

        //_documentUI = GetComponent<UIDocument>();
        //VisualElement _window = _documentUI.rootVisualElement.Q("ViewScreen") as VisualElement;
        //_window.visible = false;

        //Button _closeButton = _documentUI.rootVisualElement.Q("CloseButton") as Button;
        //_closeButton.visible = false;


        //_scoreTextField = _documentUI.rootVisualElement.Q("Score") as Label;


        //TextField _setnameField = _documentUI.rootVisualElement.Q("PlayerName") as TextField;
        //_scoreTextString = $"{_setnameField.text}'s Score: ";

        //_scoreTextField.text = _scoreTextString + _score.ToString();

        //_umlPanel.Close();

        //UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        //UnityEngine.Cursor.visible = false;
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
            // Get the component objects
            //MouseLook mousePlayer = _assignedPlayer.GetComponent<MouseLook>();
            //MouseLook mouseCamera = _assignedCamera.GetComponent<MouseLook>();
            //RayShooter rayHandler = _assignedCamera.GetComponent<RayShooter>();
            if (Api.IsTriggerHeldPressed) Debug.Log("button pressed and held");
            if (Api.IsTriggerPressed) Debug.Log("simple button press");
            // Check for GUI escape press
            if (Input.GetKeyDown(KeyCode.Escape) || Api.IsTriggerHeldPressed)
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
                // Fix the mouse for GUI operatons
                //mousePlayer.freezeCamera = true;
                //mouseCamera.freezeCamera = true;
                //rayHandler.freezeCamera = true;
                // Adjust the mouse mode
                //UnityEngine.Cursor.lockState = CursorLockMode.None;

                TrackedPoseDriver trackedPose = _assignedCamera.GetComponent<TrackedPoseDriver>();
                //trackedPose.
                //InputTracking.disablePositionalTracking = true;
                _umlPanel.Open();
                //UnityEngine.Cursor.visible = true;

                //_button = _documentUI.rootVisualElement.Q("SettingsButton") as Button;
                //_button.RegisterCallback<ClickEvent>(LaunchSettings);

                //Button _closebutton = _documentUI.rootVisualElement.Q("CloseButton") as Button;
                //_closebutton.RegisterCallback<ClickEvent>(CloseSettings);
            }
            else
            {
                // Go ahead and let the rest of the mouse operations take over
                //mousePlayer.freezeCamera = false;
                //mouseCamera.freezeCamera = false;
                //rayHandler.freezeCamera = false;
            }
            #if !UNITY_EDITOR
                Api.UpdateScreenParams();
            #endif
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

        GameObject cPanel = GameObject.Find("CenterPanel");
        CanvasGroup canvasGroup = cPanel.GetComponent<CanvasGroup>();

        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        Debug.Log("This is the close button");
        TrackedPoseDriver trackedPose = _assignedCamera.GetComponent<TrackedPoseDriver>();
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
            // Fix the mouse for GUI operatons
            //mousePlayer.freezeCamera = true;
            //mouseCamera.freezeCamera = true;
            //rayHandler.freezeCamera = true;
            // Adjust the mouse mode
            //UnityEngine.Cursor.lockState = CursorLockMode.None;

            //TrackedPoseDriver trackedPose = _assignedCamera.GetComponent<TrackedPoseDriver>();
            //trackedPose.
            //InputTracking.disablePositionalTracking = true;
            //_umlPanel.Open();
            //UnityEngine.Cursor.visible = true;

            //_button = _documentUI.rootVisualElement.Q("SettingsButton") as Button;
            //_button.RegisterCallback<ClickEvent>(LaunchSettings);

            //Button _closebutton = _documentUI.rootVisualElement.Q("CloseButton") as Button;
            //_closebutton.RegisterCallback<ClickEvent>(CloseSettings);
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

    private void OnSpeedChange(float speed)
    {
        // Update settings
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, speed);
    }
}
