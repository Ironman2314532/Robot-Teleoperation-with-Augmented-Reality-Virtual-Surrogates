using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WayPointManager : MonoBehaviour
{
    public static int max_way_points = 10;//Maximum Possible Number of Way Points
    public static int current_way_point_location;//Holds the index of the current way point that is being used
    public static Vector3[] way_point_array = new Vector3[max_way_points];

    GameObject way_point_marker_parent;
    GameObject way_point_label_parent;
    [SerializeField] TextMeshProUGUI[] way_point_label_array = new TextMeshProUGUI[max_way_points];
    [SerializeField] TextMeshProUGUI way_point_label_topic;
    public DroneController _PrimaryDrone;

    void Start()
    {
        way_point_marker_parent = GameObject.Find("/VisualUI/WayPointManager");
        way_point_label_parent = GameObject.Find("/VisualUI/WayPointLabels");
        LineRenderer waypoint_line = gameObject.AddComponent<LineRenderer>();
        waypoint_line.startWidth = 0.01f;
        waypoint_line.endWidth = 0.01f;
        waypoint_line.useWorldSpace = true;
    }

    public void set_waypoint(Vector3 _position)
    {
        way_point_label_topic.enabled = true;
        way_point_array[current_way_point_location] = _position;//Filling the Array with location points

        //Creating Way Point Marker Sphere
        GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        marker.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        marker.transform.parent = way_point_marker_parent.transform;
        marker.transform.position = _position;
        var sphereRenderer = marker.GetComponent<Renderer>();
        if (current_way_point_location == 0)
            sphereRenderer.material.SetColor("_Color", new Color32(0, 255, 0, 10));
        else if (current_way_point_location == max_way_points - 1)
            sphereRenderer.material.SetColor("_Color", new Color32(255, 0, 0, 10));
        else
            sphereRenderer.material.SetColor("_Color", new Color32(255, 255, 255, 10));

        //Updating the Locations Label
        string output_waypoint_label = "" + (current_way_point_location + 1) + ". " + way_point_array[current_way_point_location];
        way_point_label_array[current_way_point_location].enabled = true;
        way_point_label_array[current_way_point_location].text = output_waypoint_label;

        //For drawing line between markers
        LineRenderer waypoint_line = GetComponent<LineRenderer>();
        waypoint_line.positionCount = current_way_point_location + 1;
        waypoint_line.SetPosition(current_way_point_location, way_point_array[current_way_point_location]);
        current_way_point_location += 1;
    }

    public void clear_waypoints()
    {
        way_point_label_topic.enabled = false;

        for (int i = 0; i < max_way_points; i++)//Clearing All Labels
        {
            string output_waypoint_label = "(NaN,NaN,NaN)";
            way_point_label_array[i].text = output_waypoint_label;//Clear the Label
            way_point_label_array[i].enabled = false;
        }

        foreach (Transform child in way_point_marker_parent.transform) //Destroying all children
            GameObject.Destroy(child.gameObject);

        LineRenderer waypoint_line = GetComponent<LineRenderer>();
        for (int i = 0; i < current_way_point_location; i++)//Clearing All Lines
            waypoint_line.SetPosition(i, new Vector3(0.0f, 0.0f, 0.0f));

        current_way_point_location = 0;
    }

    public Vector3 next_waypoints(int current_waypoint)
    {
        if (current_waypoint < current_way_point_location - 1)
            return (way_point_array[current_waypoint + 1]);
        else
            return (new Vector3(-1f, -1f, -1f));
    }

    void Update()
    {

    }

}
