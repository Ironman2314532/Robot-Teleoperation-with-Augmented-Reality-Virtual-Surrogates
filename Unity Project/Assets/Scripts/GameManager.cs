using System.Collections;
using System.Collections.Generic;
using UnityEngine;//For Base Unity
using UnityEngine.UI;//For Canvas Editing
using UnityEngine.InputSystem;//For Controller Inputs
using TMPro; //For Text Editing

public class GameManager : MonoBehaviour
{
    public DroneController _PrimaryDrone;
    public DroneController _VirtualSurrogate;
    ControllerInput controls;
    [SerializeField] public TextMeshProUGUI _ModeSelector;
    bool _virtual_surrogate_control_mode = true;
    Vector2 translate_drone;
    const int WAYPOINT_LENGTH = 10;
    int way_point_marker_position = 0;
    public GameObject[] way_point_tracker_array = new GameObject[WAYPOINT_LENGTH];
    [SerializeField] public TextMeshProUGUI[] way_point_label_array = new TextMeshProUGUI[WAYPOINT_LENGTH];
    [SerializeField] public TextMeshProUGUI _way_point_label_topic;

    float[,] way_point_array = new float[WAYPOINT_LENGTH, 4];//x,y,z,state

    void power_switch_pressed()
    {
        if (!_virtual_surrogate_control_mode)
        {
            _PrimaryDrone._drone_power_state = !_PrimaryDrone._drone_power_state;
            if (_PrimaryDrone._drone_power_state)
            {
                if (_PrimaryDrone.IsIdle())
                    _PrimaryDrone.TakeOff();
            }
            else
            {
                if (_PrimaryDrone.IsFlying())
                    _PrimaryDrone.Land();
            }
        }
        else
        {
            _VirtualSurrogate._drone_power_state = !_VirtualSurrogate._drone_power_state;
            if (_VirtualSurrogate._drone_power_state)
            {
                if (_VirtualSurrogate.IsIdle())
                    _VirtualSurrogate.TakeOff();
            }
            else
            {
                if (_VirtualSurrogate.IsFlying())
                    _VirtualSurrogate.Land();
            }
        }
    }

    void display_way_point_info(bool _display_status)
    {
        if (!_display_status)
        {
            for (int i = 0; i < WAYPOINT_LENGTH; i++)
            {
                way_point_array[i, 0] = 0;
                way_point_array[i, 1] = 0;
                way_point_array[i, 2] = 0;
            }
            way_point_marker_position = 0;
        }
        for (int i = 0; i < WAYPOINT_LENGTH; i++)
        {
            Vector3 tracker_pos = new Vector3(way_point_array[i, 0], way_point_array[i, 1], way_point_array[i, 2]);
            way_point_tracker_array[i].transform.position = tracker_pos;
            way_point_tracker_array[i].SetActive(_display_status);
            string output_waypoint_label = "" + (i + 1) + ". (" + way_point_array[i, 0] + "," + way_point_array[i, 1] + "," + way_point_array[i, 2] + ")";
            way_point_label_array[i].text = output_waypoint_label;
            if (way_point_marker_position == 0)
                way_point_label_array[i].enabled = !_display_status;
            else
                way_point_label_array[i].enabled = _display_status;
            _way_point_label_topic.enabled = _display_status;
        }
    }

    void save_way_point()
    {
        if (_virtual_surrogate_control_mode)
        {
            if (way_point_marker_position < 10)
            {
                Vector3 _pos = _VirtualSurrogate.GetDroneLocation();
                way_point_array[way_point_marker_position, 0] = _pos.x;
                way_point_array[way_point_marker_position, 1] = _pos.y;
                way_point_array[way_point_marker_position, 2] = _pos.z;
                way_point_marker_position += 1;
                display_way_point_info(true);
            }
            else
                Debug.Log("All Way Point Markers Placed");
        }
    }

    void delete_way_point() { }
    void scroll_way_point() { }
    void change_mode()
    {
        _virtual_surrogate_control_mode = !_virtual_surrogate_control_mode;
        if (_virtual_surrogate_control_mode)
        {
            _ModeSelector.text = "Virtual Surrogate Control Mode";
            _ModeSelector.color = new Color32(0, 135, 62, 255);
            _VirtualSurrogate.DroneVisible(true);
            display_way_point_info(true);
            if (_PrimaryDrone._drone_power_state)
                _VirtualSurrogate.TakeOff();
        }
        else
        {
            display_way_point_info(false);
            _ModeSelector.text = "Real Time Control Mode";
            _VirtualSurrogate.DroneVisible(false);
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
        change_mode();
    }

    void Update()
    {
        if (_virtual_surrogate_control_mode)
            _VirtualSurrogate.Move(translate_drone.x, translate_drone.y);
        else
        {
            _PrimaryDrone.Move(translate_drone.x, translate_drone.y);
            _VirtualSurrogate.Move(translate_drone.x, translate_drone.y);
        }
        Debug.Log("Primary Drone: " + _PrimaryDrone._State);
        Debug.Log("Virtual Surrogate: " + _VirtualSurrogate._State);
    }
}