using System.Collections;
using System.Collections.Generic;
using UnityEngine;//For Base Unity
using UnityEngine.UI;//For Canvas Editing
using UnityEngine.InputSystem;//For Controller Inputs
using TMPro; //For Text Editing

public class GameManager : MonoBehaviour
{
    public DroneController _DroneController;
    ControllerInput controls;
    public Button _FlyButton;
    public Button _LandButton;
    public TextMeshProUGUI _ModeSelector;
    bool _drone_power_state = false;
    bool _virtual_surrogate_control_mode = true;
    Vector2 translate_drone;

    void EventOnClickFlyButton()
    {
        if (_DroneController.IsIdle())
        {
            _DroneController.TakeOff();
            _FlyButton.gameObject.SetActive(false);
            _drone_power_state = true;
        }
    }

    void EventOnClickLandButton()
    {
        if (_DroneController.IsFlying())
        {
            _DroneController.Land();
            _LandButton.gameObject.SetActive(false);
            _drone_power_state = false;
        }
    }

    void power_switch_pressed()
    {
        _drone_power_state = !_drone_power_state;
        if (_drone_power_state)
            EventOnClickFlyButton();
        else
            EventOnClickLandButton();
    }

    void save_way_point() { }
    void delete_way_point() { }
    void scroll_way_point() { }
    void change_mode()
    {
        _virtual_surrogate_control_mode = !_virtual_surrogate_control_mode;
        if (_virtual_surrogate_control_mode)
        {
            _ModeSelector.text = "Virtual Surrogate Control Mode";
            _ModeSelector.color = new Color32(0, 135, 62, 255);
        }
        else
        {
            _ModeSelector.text = "Real Time Control Mode";
            _ModeSelector.color = new Color32(128, 0, 0, 255);
        }

    }


    void Awake()
    {
        controls = new ControllerInput();
        controls.Power.DronePowerSwitch.performed += ctx => power_switch_pressed();
        controls.Translate.Move.performed += ctx => translate_drone = ctx.ReadValue<Vector2>();
        controls.Translate.Move.canceled += CollectionExtensions => translate_drone = Vector2.zero;
        controls.WayPoint.SaveWayPoint.performed += ctx => save_way_point();
        controls.WayPoint.DeleteWayPoint.performed += ctx => delete_way_point();
        controls.WayPoint.ScrollWayPoint.performed += ctx => scroll_way_point();
        controls.ModeSelection.ChangeMode.performed += ctx => change_mode();

    }

    void OnEnable()
    {
        controls.Power.Enable();
        controls.Translate.Enable();
        controls.WayPoint.Enable();
        controls.ModeSelection.Enable();
    }

    void OnDisable()
    {
        controls.Power.Disable();
        controls.Translate.Disable();
        controls.WayPoint.Disable();
        controls.ModeSelection.Disable();
    }

    void Start()
    {
        _FlyButton.onClick.AddListener(EventOnClickFlyButton);
        _LandButton.onClick.AddListener(EventOnClickLandButton);
        _LandButton.gameObject.SetActive(false);
        _FlyButton.gameObject.SetActive(false);
        _ModeSelector = FindObjectOfType<TextMeshProUGUI>();
        change_mode();
    }

    void Update()
    {
        if (_DroneController.IsFlying())
            _LandButton.gameObject.SetActive(true);
        if (_DroneController.IsIdle())
            _FlyButton.gameObject.SetActive(true);
        _DroneController.Move(translate_drone.x, translate_drone.y);
    }
}
