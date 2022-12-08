**Table of Contents**
<!-- TOC -->

- [Introduction](#introduction)
- [How to run the project](#how-to-run-the-project)
- [Interested in Editing the project for your own use?](#interested-in-editing-the-project-for-your-own-use)
    - [Collect the Softwares to setup the project](#collect-the-softwares-to-setup-the-project)
        - [Collect the Project Files](#collect-the-project-files)
        - [Unity Hub](#unity-hub)
        - [Visual Studio Code](#visual-studio-code)
    - [Setup Environment](#setup-environment)
        - [Setup Directories](#setup-directories)
    - [Setup Project](#setup-project)
        - [Launch Project in Unity](#launch-project-in-unity)
        - [Import Essential Packages](#import-essential-packages)
        - [Setup Android Device for App Emulation](#setup-android-device-for-app-emulation)
        - [What each scripts contain?](#what-each-scripts-contain)
        - [Export the Android App](#export-the-android-app)
- [Designer Details](#designer-details)
- [Acknowledgements](#acknowledgements)
- [License](#license)

<!-- /TOC -->

# Introduction

The aim of the project is to design a waypoint tracking system with the help of Augmented Reality which can help users to focus more on high-level tasks like motion planning or path planning and less on learning and understanding control dynamics of the drone.

We took the knowledge from the [research paper](https://ieeexplore.ieee.org/abstract/document/8673306) and tried to replicate as close as possible for our learning and understanding. We provide all the project files for general public to use and adapt for their own usage if you find them useful.

We have designed the complete project on [Unity Engine](https://unity.com/) V2020.3.42f1. The project is built for Android Device using [Android Studio](https://developer.android.com/studio/?gclid=CjwKCAiAp7GcBhA0EiwA9U0mtkEpRfebCZN0bh7VVITwbL350F0rY_PM6F03cEG6pZOch3nfhviDmxoCNusQAvD_BwE&gclsrc=aw.ds) at the moment but can easily be build fir any other systems with our How to Guide provided below.

We were heavily inspired and took deep notes on the project from the Research paper published by:

1. Michael E Walker
2. Hooman Hedayati
3. Daniel Szafir

Citation:
[Walker, M.E., Hedayati, H. and Szafir, D., 2019, March. Robot teleoperation with augmented reality virtual surrogates. In 2019 14th ACM/IEEE International Conference on Human-Robot Interaction (HRI) (pp. 202-210). IEEE.](https://ieeexplore.ieee.org/abstract/document/8673306)

_Note: This project is designed on Windows 11 and built for Android V11/12 not tested on any other platforms_

_Super Note: Remember, If anything doesnt work as it is supposed to, just use the rules of IT. Close it and restart it again :)_

# How to run the project

1. Download the .apk file from the `/Resources/Build/`.
2. Install it on an Android Device with Version 10 or higher.
3. Provide Camera Access to the app for Augmented Reality usage.
4. Connect a gamePad Controller to it. You might need a USB Type-A to Type-C or Micro Type-B connector based on your phone.
5. You are all set to go !!!

_Seems Like I am missing something... What am I missing?_

_My Bad, I forgot to show you what each controls on the GamePad does!_

![Controller Instruction](/Resources/Screenshots/Controller%20Guide.png)

_Yes this Handmade thing does not look too professional but I got my new **Samsung Galaxy Tab S8 Ultra** So I am flaunting it and not hiding the fact that I was too lazy to make the guide in a professional software like Adobe Illustrator_

# Interested in Editing the project for your own use?

Here Below is the guide on how you can use the project for your own purposes. The Complete Project sizes a lot, so we are storing most of our project files on a Google Drive from where you can download the files for your use.

_Note: The current project is design and built for Unity Editor Version: 2020.3.42f1 - Android Build.
If you are interested in using any other version of Editor and platform, feel free to do so but take a quick moment to google on how to change editor or platform versions._

## Collect the Softwares to setup the project

### Collect the Project Files

[Click to Download Project Files](https://drive.google.com/file/d/1_Y-TImn0QyTHC3sWtdGCLgOvxjm7Fr0U/view?usp=share_link)

### Unity Hub

First task for making the project run is to download UnityHub.

1. [Click Link to Download UnityHub](https://unity3d.com/get-unity/download)
2. Once on the website, Select the `Download Unity Hub` Button. We want the complete unity hub, not just unity software.
3. Install the Unity Hub, when asked for license, select and create a Personal License.
4. Go to the `Installs` Tab and Select `Install Editor` on top-right of the window.
5. Our Project is using V2020.3.42f1 so it is adviced to locate that.(_Note: You can Install other versions if you want to but please google on how to port the files from our project to other versions of unity_)
6. When the required version is found, press `Install` button.
7. Under the Platforms tab, choose the required one:
   1. `Android Build Support`
   2. `Windows Build Support (IL2CPP)`
   3. `iOS Build Support`
   4. `Linux Build Support`
   5. `Mac Build Support (Mono)`
8. Finally Press the `Install` on bottom right and wait for the whole setup to finish.
9. After the Install, close the Unity Hub.

### Visual Studio Code

Yes, I know. You can use any other IDE that you may like but I love VS Code. _So deal with it!!_

1. Download VS Code by clicking the [link](https://code.visualstudio.com/).
2. Install VS Code. Once the Installation is complete, launch it.
3. Click the Extensions tab and install the following extensions by clicking these links

   1. [Better Comments](https://marketplace.visualstudio.com/items?itemName=aaron-bond.better-comments)
   2. [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
   3. [Prettier - Code formatter](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode)
   4. [VSC-Essentials](https://marketplace.visualstudio.com/items?itemName=Gydunhn.vsc-essentials)
   5. [Prettier ESLint](https://marketplace.visualstudio.com/items?itemName=rvest.vs-code-prettier-eslint)

   _(Note: This Extensions are not neccesary but will surely make your life a bit easier when you are on the verge of unaliving yourself for picking up a project like this!!! Believe me... you are reading this ReadMe just due to their help!!)_

## Setup Environment

### Setup Directories

Go to the Desktop and Right Click to Open new Terminal. Type the Following Command inside it

```
mkdir virtual_surrogate_ar_project
cd virtual_surrogate_ar_project
```

Clone the GitHub Repository here with by typing the following in terminal

```
git clone https://github.com/parth-20-07/Robot-Teleoperation-with-Augmented-Reality-Virtual-Surrogates
```

Wait for the cloning to Finish and then open the project in VS Code by typing

```
cd Robot-Teleoperation-with-Augmented-Reality-Virtual-Surrogates
mkdir Unity_Files
code .
```

Extract the Project Files that you downloaded while collecting project file into current directory. You extracted files will look something like this.

![Extracted Files](/Resources/Screenshots/Extracted%20Files.png)

Copy all the files and Folders inside this and paste it into the directory just created by you in `virtual_surrogate_ar_project/Robot-Teleoperation-with-Augmented-Reality-Virtual-Surrogates/Unity_Files`.
The `Robot-Teleoperation-with-Augmented-Reality-Virtual-Surrogates` directory should have the following files and folders

![Setup Directories](/Resources/Screenshots/Collected%20Folder.png)

You are all set with setting up the directories.

## Setup Project

### Launch Project in Unity

1. Press the windows button and search for `Unity Hub`
2. Once launched, press the `Open` Button on top right. Guide to the `Unity_Files` folder just created and press `Open`.
3. It will take some time to load and launch the project. Maybe make a coffee meanwhile?

Once the complete setup is done, the following window will be visible.

![Unity Window](/Resources/Screenshots/Unity%20Launch.png)

_Note: When Launching the project, you might encounter issues like not Editor Version not matching, or missing packages. Don't worry, push through it and just launch the project. We'll sort the issues soon._

### Import Essential Packages

1. Click the `Window` button in the menu bar and click on `Package Manager` option. A new window as shown below will pop up.

   ![Package Manager](/Resources/Screenshots/Package%20Manager.png)

2. In the Top Left, you will see the current package registery option as `Packages: In Project`. Click the tab and choose `Unity Registry` to search from the global unity package registry.

   1. **Input System**

      In the top right search tab, search for `Input System` and press enter. The window will be uploaded as shown below

      ![Input Systems](/Resources/Screenshots/Input%20System.png)

      Press `Install` in Bottom-Right to install it and let the installation finish.

      After the installation of this package is finished, you will recieve a warning box as shown below. This just allows your system to use different versions of input systems.

      ![Input Systems Confirm](/Resources/Screenshots/Input%20Systems%20Confirmation.png)

      Press `Yes` to confirm. Let Unity restart and reinitialize the project.
   2. **AR Foundation**

      In the top right search tab, search for `AR Foundation` and press enter. The window will be uploaded as shown below

      ![AR Foundation](/Resources/Screenshots/AR%20Foundation.png)

      Press `Install` in Bottom-Right to install it and let the installation finish.
   3. **ARCore XR Plugin**

      In the top right search tab, search for `ARCore XR Plugin` and press enter. The window will be uploaded as shown below

      ![ARCore XR Plugin](/Resources/Screenshots/ARCore%20XR.png)

      Press `Install` in Bottom-Right to install it and let the installation finish.
3. Close the whole project and restart it again. You are all set for editing the project.

### Setup Android Device for App Emulation

This step of the setup is not essential in building project but we do this often because during development, there might happen that your code might have bugs. If each and every time when trying out a new feature, you export project as .apk and install it in the android device, it will take a lot of time and hassle. This setup will help you mirror you unity app directly on your android device without the need to install the app after every change and make the process of updating the designs a bit more hassle free.

1. Connect the phone to your laptop with USB Cable. There is option to build the emulation wirelessly but I prefer wired method for better speed and response.
2. Download and Install [Unity Remote 5](https://play.google.com/store/apps/details?id=com.unity3d.mobileremote&hl=en_US&gl=US) from Google Play Store.
3. Turn ON `Developer Settings` for your Android Device. _(You might need to google on how to turn it on for your specific device.)_
4. After Turning On `Developer Settings`, open the Developer Settings tab in your android device settings and turn on `USB Debugging`.

   Setup from the Android Side is complete, now switch to Unity on your computer for the remaining setup.
5. Click on `Edit > Project Settings` in the Menu Bar. A Project Settings window as shown will pop-up.

   ![Project Manager](/Resources/Screenshots/Project%20Manager.png)
6. Click on `Editor` tab on the Left Panel. The Window will be updated as shown

   ![Project Manager - Editor](/Resources/Screenshots/Project%20Settings%20Editor.png)
7. Set the settings as follows:

   1. Set `Device` dropdown, select `Any Android Device`.
   2. Set `Compression` dropdown, select `JPEG`.
   3. Set `Resolution` dropdown, select `Normal`.
8. Close the `Project Settings` tab. We are all done.
9. Press the `Play` Button and you can see the Unity Game window replicate on your Android Device.

Congratulations, we are all ready for emulation !!

You can click the video below if you prefer the video guide on how to setup the Android Emulation.

<a href="https://youtu.be/iCXwaehzRFQ">
  <img src="Resources/Screenshots/Android Emulator Image.jpg" width="480" />
</a>

_Credits: Youtube - Coco Code_

### What each scripts contain?

There are multiple essential scripts in the `Assets/Scripts` folder. The top essential scripts are:

- `ControllerInput.cs` : This script contains all the mapping for the controller Inputs. **_(Note: Never touch this file.)_**
- `DroneController.cs` : This script contains the primary drone control strategies including what and how each drone will behave and be controlled.
- `WayPointManager.cs` : This script contains the Waypoint system design. This file is used to log and provide the waypoint data as requested by `DroneController.cs` and `GameManager.cs` scripts.
- `GameManager.cs` : This is an supervisory and control script. This file is connects all the remaining scripts together for them to function properly and ensure that the simulation works smoothly.
- `Animation/` : This folder contains multiple scripts which manage how the drone should behave for visual asthetics.

**DroneController.cs**

- `public enum DroneState` : This enum variable holds different drone states. This can be referenced both with index number or index value name.
  - `DRONE_STATE_IDLE` : The Drone is powered off
  - `DRONE_STATE_START_TAKINGOFF` : The drone is just powered on and in the instructed to take off.
  - `DRONE_STATE_TAKINGOFF` : The drone is in the process of throttling to take off.
  - `DRONE_STATE_MOVING_UP` : The drone is fully throttled and is gaining height to take off completely.
  - `DRONE_STATE_FLYING` : The drone is in flying state and ready to control.
  - `DRONE_STATE_START_LANDING` : The drone just recieved the instruction to power down.
  - `DRONE_STATE_LANDING` : The drone has started the process of reducing altitude.
  - `DRONE_STATE_LANDED` : The drone has touched the ground but propellers are still throttled.
  - `DRONE_STATE_WAIT_ENGINE_STOP` : The Propellers are slowing down and we are waiting for them to stop completely.
  - `DRONE_STATE_WAY_POINT_FOLLOW` : The Drone is instructed to Follow the WayPoint Path and is in the process of going through them.
- `float distance_error = 0.001f;` : This variable indicates how much error is acceptable for the drone to move on to the next waypoint. This helps to limit the control effort chattering and acts like a boundary layer to reduce chatter.
- `public float _SpeedMultipler = 10.0f;` : Determines the Drone Speed in simulation. Value is in m/s.
- `public bool _drone_power_state = false;` : Determines the power of the drone. Value of this variable is modulated often on gamePad Input in the GameManager.cs script.
- `public bool IsIdle()` : This function returns whether the drone is powered down.
- `public bool IsFlying()` : This function returns whether the drone is powered up and in flying state.
- `public void TakeOff()` : This function makes the drone change from Idle State to Flying State.
- `public void Land()` : This function makes the drone change from Flying State to Idle State.
- `public void SetDroneLocation(Vector3 _position)` : This function sets the drone to a specific coordinates as passed into `_position` variable.
- `public Vector3 GetDroneLocation()` : This function returns the drone location in Vector3 Format.

_Note: `Vector3` data type holds the (x,y,z) coordinate values and can be accessed as follows:_

```
Vector3 location = GetDroneLocation();
float x = location.x;
float y = location.y;
float z = location.z;
```

**WayPointManager.cs**

- `public static int max_way_points = 10;` : Limits the Maximum Number of WayPoint user can store
- `public static int current_way_point_location;` : This Variable holds the index of the WayPoint that is being accessed.
- `public static Vector3[] way_point_array = new Vector3[max_way_points];` : This array stores the location fo all waypoints that are saved.
- `GameObject way_point_marker_parent;` : This variable holds the address of the Parent GameObject under which the child markers for the sphere are spawned when a way point is saved.
  The variable is updated using:
  `way_point_marker_parent = GameObject.Find("/VisualUI/WayPointManager");`
- `[SerializeField] TextMeshProUGUI[] way_point_label_array = new TextMeshProUGUI[max_way_points];` : This GameObject holds the array of all the text labels which are updated with the coordinates of waypoint when the waypoint is saved.
- `public void set_waypoint(Vector3 _position)` : This function saves the waypoint data. This function performs three actions:
  - Create the Marker:

    ```
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
    ```

    Here how's the marker is spawned:
    This creates the sphere on request.
    
    `GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);`

    Set the size of Sphere to the radius of 0.5m:
    
    `marker.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);`

    Set the sphere as child of the `way_point_marker_parent`:
    
    `marker.transform.parent = way_point_marker_parent.transform;`

    Set the location of the sphere on the wayPoint location:

    `marker.transform.position = _position;`

    Find the color renderer component of the sphere:

    `var sphereRenderer = marker.GetComponent<Renderer>();`

    Set the color of the marker as Green for the First Marker, Red for the 10th marker and white for the rest:

    ```
    if (current_way_point_location == 0)
      sphereRenderer.material.SetColor("_Color", new Color32(0, 255, 0, 10));
    else if (current_way_point_location == max_way_points - 1)
      sphereRenderer.material.SetColor("_Color", new Color32(255, 0, 0, 10));
    else
      sphereRenderer.material.SetColor("_Color", new Color32(255, 255, 255, 10));
    ```
  - Create Connecting Lines between Markers:

    ```
    //For drawing line between markers
    LineRenderer waypoint_line = GetComponent<LineRenderer>();
    waypoint_line.positionCount = current_way_point_location + 1;
    waypoint_line.SetPosition(current_way_point_location, way_point_array[current_way_point_location]);
    current_way_point_location += 1;
    ```

    Finding the Line Renderer Component initiated in `void Start()`
 
    `LineRenderer waypoint_line = GetComponent<LineRenderer>();`

    The LineRenderer Object takes four inputs to plot the line:

    - Starting Point Index
    - Starting Point Coordinates
    - Ending Point Index
    - Ending Point Coordinates
      Everytime when a WayPoint is saved, we save the index of the waypoint in the lineRenderer along with the coordinates of the way point. This way, the lineRenderer coordinates increase to form lines between multiple points.
      `waypoint_line.SetPosition(current_way_point_location,way_point_array[current_way_point_location]);`

**GameManager.cs**

- Create Instance of the Scripts for the GamePlay

  ```
  public DroneController _PrimaryDrone;
  public DroneController _VirtualSurrogate;
  public WayPointManager WayPointManager;
  ControllerInput controls;
  ```
- `bool _virtual_surrogate_control_mode = true;` : Variable holds the state of whether controller is used to control the Actual Drone of the Virtual Surrogate.
- `Vector3 translate_drone;` : Hold the value of Joystick Movement to control the direction and speed of drone.
- `[SerializeField] public TextMeshProUGUI _ModeSelector;` : Text Label to display the `Virtual Surrogate Control Mode` or `Real Time Control Mode` Tag.
- `void power_switch_pressed()` : Function switches the power of drone based on the control mode.

  ```
  void power_switch_pressed()
    {
        if (!_virtual_surrogate_control_mode)
        {
            _PrimaryDrone._drone_power_state = !_PrimaryDrone._drone_power_state;
            if (_PrimaryDrone._drone_power_state)
            {
                if (_PrimaryDrone.IsIdle())
                {
                    _PrimaryDrone.TakeOff();
                    _VirtualSurrogate.TakeOff();
                }
            }
            else
            {
                if (_PrimaryDrone.IsFlying())
                {
                    _PrimaryDrone.Land();
                    _VirtualSurrogate.Land();
                }
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
  ```
- `void save_way_point()` : This Function is called only in Virtual Surrogate Control mode when user presses the button to save waypoint.
  It Stores the waypoints into the WayPoint Array in the WayPointManager Script.

  ```
    void save_way_point()
    {
        if (_virtual_surrogate_control_mode)
        {
            if (WayPointManager.current_way_point_location < 10)
            {
                Vector3 _pos = _VirtualSurrogate.GetDroneLocation();
                WayPointManager.set_waypoint(_pos);
            }
            else
                Debug.Log("All Way Point Markers Placed");
        }
    }
  ```
- `void retrace_way_points()` : Retrace all the way points using the virtual surrogate to determine how the actual drone will behave. Benifical to confirm the behaviour of actual drone before performing the action.

  ```
    void retrace_way_points()
    {
        if (_virtual_surrogate_control_mode)
        {
            _VirtualSurrogate.SetDroneLocation(_PrimaryDrone.GetDroneLocation());
            _VirtualSurrogate._State = DroneController.DroneState.DRONE_STATE_WAY_POINT_FOLLOW;
            _VirtualSurrogate.current_waypoint_tracking_index = -1;
        }
    }
  ```
- `void execute_way_points()` : Make the Actual Drone retrace all the waypoints. The WayPoints are cleared when the tracking is completed.

  ```
    void execute_way_points()
    {
        if (_virtual_surrogate_control_mode)
        {
            if (_PrimaryDrone.IsIdle())
                _PrimaryDrone.TakeOff();
            retrace_path = true;
        }
    }
  ```
- `void change_mode()` : Change the selection of control between Virtual Surrogate and the Actual Drone.

  ```
    void change_mode()
    {
        _virtual_surrogate_control_mode = !_virtual_surrogate_control_mode;
        if (_virtual_surrogate_control_mode)
        {
            // display_way_point_info(true);
            _ModeSelector.text = "Virtual Surrogate Control Mode";
            _ModeSelector.color = new Color32(0, 135, 62, 255);
            if (_PrimaryDrone.IsFlying() && _VirtualSurrogate.IsIdle())
                _VirtualSurrogate.TakeOff();
            else if (_PrimaryDrone.IsIdle() && _VirtualSurrogate.IsFlying())
                _VirtualSurrogate.Land();
            merge_position = true;
            _VirtualSurrogate._SpeedMultipler = 4.0f;
        }
        else
        {
            _ModeSelector.text = "Real Time Control Mode";
            _ModeSelector.color = new Color32(128, 0, 0, 255);
            WayPointManager.clear_waypoints();
            if (_VirtualSurrogate.IsFlying() && _PrimaryDrone.IsIdle())
                _VirtualSurrogate.Land();
            else if (_PrimaryDrone.IsFlying() && _VirtualSurrogate.IsIdle())
                _VirtualSurrogate.TakeOff();
            merge_position = true;
            _VirtualSurrogate._SpeedMultipler = 10.0f;
        }
    }
  ```
- `void Awake()` : Maps all the controller inputs to their specified call back functions.

  ```
    void Awake()
    {
        controls = new ControllerInput();
        controls.Power.DronePowerSwitch.performed += ctx => power_switch_pressed();
        controls.Translate.Move.performed += ctx => translate_drone = new Vector3(ctx.ReadValue<Vector2>()[0], 0, ctx.ReadValue<Vector2>()[1]);
        controls.Translate.Move.canceled += CollectionExtensions => translate_drone = Vector3.zero;
        controls.Translate.Height.performed += ctx => translate_drone = new Vector3(0, ctx.ReadValue<float>(), 0);
        controls.Translate.Height.canceled += CollectionExtensions => translate_drone = Vector3.zero;
        controls.WayPoint.SaveWayPoint.performed += ctx => save_way_point();
        controls.WayPoint.DeleteWayPoint.performed += ctx => delete_way_point();
        controls.WayPoint.ScrollWayPoint.performed += ctx => scroll_way_point();
        controls.WayPoint.RetraceWayPoints.performed += ctx => retrace_way_points();
        controls.WayPoint.ExecuteWayPoints.performed += ctx => execute_way_points();
        controls.ModeSelection.ChangeMode.performed += ctx => change_mode();
    }
  ```
- Enable and Disable Control Inputs when in need.

  ```
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
  ```

### Export the Android App

Now you have made all the changes you need and tested it via emulation. Here are the steps on how to export it to an Android App.

1. Click `File > Build Settings` from the menu bar. Make Sure `Android` is the chosen option in the Platform list. If not, select it.
   A Completely setup build settings should look close to like this
 
   ![Build Settings](/Resources/Screenshots/Build%20Settings.png)

2. Click `Player Settings...` on the bottom left. A new window with the name `Project Settings` will pop up as shown.

   ![Project Settings](/Resources/Screenshots/Project%20Settings.png)

3. Set the following details in the window as necessary:
   1. Company Name
   2. Product Name
   3. Version Name
   4. Default Icon
4. Click the `Other Settings` Drop down. Scroll down to `Identification` Section to set the minimum version of Android your app should support under `Minimum API Level`.
5. Under `Configuration`, choose `Scripting Backend` as `IL2CPP` and make sure that `ARM64` box is checked.
6. Close the `Project Settings` window and press `Build` button.
7. A window will pop up asking you where to build and save the android .apk file. We have chosen `/Resources/Build` directory for our project but you can choose whichever place you feel like is the best for you.
8. Just sitback and let the build complete. This should take between 1-5 minutes depeneding on your computer performance.
9. After Build is complete, transfer and install the app to your phone. It might ask you for some permission to install from unknown sources which you'll need to allow.
10. Connect your controller now and flaunt it to your friends about your new project now.

# Designer Details

- Designed for:
  - Worcester Polytechnic Institute
  - RBE 526: Human Robot Interaction - Final Project
- Designed by:
  - [Parth Patel](mailto:parth.pmech@gmail.com)
  - [Thira Patel](mailto:thira.p23@gmail.com)

# Acknowledgements

- Research Guide: [Robot teleoperation with augmented reality virtual surrogates](https://ieeexplore.ieee.org/abstract/document/8673306)
- Android App Testing Guide: [Quickly preview your game on Android Device | Unity Tutorial](https://youtu.be/iCXwaehzRFQ)
- Export Unity Project to Android: [How to Export your game in Unity for Android](https://youtu.be/fbcJjZInt-A)
- Understanding Augmented Reality in Unity: [Augmented Reality for Everyone - Full Course](https://youtu.be/WzfDo2Wpxks)
- Configuring Controller in Unity: [CONTROLLER INPUT in Unity!](https://youtu.be/p-3S73MaDP8)
- WayPoint Tracking Design: [Unity Basics - Waypoint Path system in Unity](https://youtu.be/EwHiMQ3jdHw)
- Drone Design and Control: [Unity AR foundation tutorial - AR drone for iOS and Android](https://youtu.be/MzFE2QfgohE)
- And a Super Huge help to [stackoverflow](https://stackoverflow.com/) for existing and making programming possible for us!!

# License

This project is licensed under [GNU General Public License v3.0](https://www.gnu.org/licenses/gpl-3.0.en.html) (see [LICENSE.md](LICENSE.md)).

Copyright 2022 Parth Patel

Licensed under the GNU General Public License, Version 3.0 (the "License"); you may not use this file except in compliance with the License.

You may obtain a copy of the License at

_https://www.gnu.org/licenses/gpl-3.0.en.html_

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.

<!-- # Documentation TODO

- [X] Introduction
- [X] How to run the project
- [X] Interested in editing the project for your own use?
  - [X] Collect the Softwares to setup the project
    - [X] Collect the Project Files
    - [X] Unity Hub
    - [X] Android Studio
    - [X] Android NDK
    - [X] VS Code
  - [X] Setup Environment
    - [X] Setup Directories
  - [X] Setup Project
    - [X] Launch Project in Unity
    - [X] Import Essential Packages
    - [X] Setup Android Device for App Emulation
    - [X] What each script contains?
    - [X] Export the Android App
- [X] Tools Used
- [X] Designer Details
- [X] Acknowledgements
- [X] License -->
