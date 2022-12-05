# Table of Contents

- [Table of Contents](#table-of-contents)
- [Introduction](#introduction)
- [How to setup the project](#how-to-setup-the-project)
  - [Install ROS2 Humble Hawksbill](#install-ros2-humble-hawksbill)
  - [Environment Setup](#environment-setup)
  - [Gazebo Installation Tutorials](#gazebo-installation-tutorials)
  - [Simulation](#simulation)
  - [PlotJuggler](#plotjuggler)
- [How to use the project](#how-to-use-the-project)
  - [Assignment 1](#assignment-1)
    - [**Forward Kinematics Node**](#forward-kinematics-node)
    - [**Inverse Kinematics Node**](#inverse-kinematics-node)
  - [Assignment 2](#assignment-2)
    - [**Joint Efforts Control Node**](#joint-efforts-control-node)
  - [Assignment 3](#assignment-3)
- [Tools Used](#tools-used)
- [Designer Details](#designer-details)

# Introduction

_Note: This project is designed on Windows 11 and not tested on any other platforms_

_Super Note: Remember, If anything doesnt work as it is supposed to, just use the rules of IT. Close it and restart it again :)_

# How to setup the project

## Collect the Project Files

**Download Project Files from Google Drive Link**

[Download Project Files](https://drive.google.com/drive/folders/1F6m2Nc7uq7a-VYWZzda4WF9UxTImIZbO?usp=share_link)

**Download Unity Hub**

<br>

# How to use the project

## Assignment 1

1. Compile the project by using the command:
   ```
   colcon build
   ```

### **Forward Kinematics Node**

2. Launch the RVIZ model in a new terminal using:

   ```
   ros2 launch rrbot_description view_robot.launch.py
   ```

   This will launch a Rviz windows which shows the robot model along with a a small window titled **Joint State Publisher** with three sliders to control three joints.

   1. Rviz Model Window:
      ![RViz Model Window](/Submissions/Group%20Project%201/RVIZ%20Window.png)
   2. Joint Publisher Model:

      ![Joint State Publisher Window](/Submissions/Group%20Project%201/Joint%20State%20Publisher%20Window.png)

3. In a new Terminal, Launch the Forward Kinematics node using:

   ```
   ros2 run rrbot_gazebo fkin_publisher
   ```

   The Node will take the Joint States from the topic `/joint_states` in the format `sensor_msgs::msg::JointState`

   The Calculated Pose is published on the topic `/forward_position_controller/commands` in format `std_msgs::msg::Float64MultiArray`

4. In a new Terminal, Echo the Forward Kinematics Topic using

   ```
   ros2 topic echo /forward_position_controller/commands
   ```

   The output data will be displayed as follows:

   ![FKIN Topic Echo](/Submissions/Group%20Project%201/FKIN%20Topic%20Echo.png)

   The x coordinates is displayed at line 4.

   The y coordinates is displayed at line 8.

   The z coordinates is displayed at line 12.

5. Move around the sliders in the _Joint State Publisher_ Window to see the End Effector Position change.

### **Inverse Kinematics Node**

The Inverse Kinematics Node works on a server service node setup. The user can type the end-effector pose after launching the server node and request node to calculate the Joint States using a Service Call.

6. In a new terminal (_You can close all other terminals if you wish to_), Launch the Inverse Kinematics Server Node using:
   ```
   ros2 run rrbot_gazebo ikin_publisher
   ```
7. In a new terminal launch the service using

   ```
   ros2 service call /inverse_kinematics custom_interfaces/srv/FindJointStates "{x: 1, y: 0, z: 2}"
   ```

   Change the end effector position by changing the values for (x,y,z).

   The service Call will return the output in following format:

   ![IKIN Service Call](/Submissions/Group%20Project%201/Ikin%20Service%20Call.png)

   The service results two sets of possible response:

   - (q11, q21, q31)
   - (q12, q22, q32)

## Assignment 2

1. Compile the project by using the command:
   ```
   colcon build
   ```
2. Launch RRBOT in Gazebo using:

   ```
   ros2 launch rrbot_gazebo rrbot_world.launch.py
   ```

   This will launch the Gazebo Window with the RRBOT spawned.

   ![RRBOT Gazebo Spawn](/Submissions/Group%20Project%202/Gazebo%20Model.png)

### **Joint Efforts Control Node**

3. Launch the Joint Control Node using:
   ```
   ros2 run rrbot_gazebo joint_control
   ```
   The control strategy used for the Joint Control Strategy is PD Control. The system is broken down into individual joints where each joint has it's own control system. This strategy divides the whole system into 3 individual SISO System allowing us to tune Kp and Kd parameters individually.
   $$u = -K_{p}*e_{x} - K_{d}*e_{v}$$
   where:
   - $e_{x}$ is position error: $e_{x} = x_{reference} - x_{current}$
   - $e_{v}$ is velocity error: $e_{v} = v_{reference} - v_{current}$
4. Call the Joint Control service using:

   ```
   ros2 service call /joint_state_controller custom_interfaces/srv/SetJointStates '{rq1: 1, rq2: 2, rq3: 2}'
   ```

   Change the Joint States by trying different values for (rq1,rq2,rq3)
   <!-- [Reference Video](https://youtu.be/P_8ERXKMxVg) -->
   <!-- _Yes I am this dumb that I need YouTube to show my video as I could not find a working example of how to embed video in Markdown. Don't act Sassy About it now !!_ -->

5. Echo the topic to see the reference Joint Position:
   ```
   ros2 topic echo /reference_joint_states/commands
   ```
6. We can visualize the efforts and joint states using PlotJuggler.
   Launch Plot Juggler using the following:

   ```
   ros2 run plotjuggler plotjuggler
   ```

   Once the plot Juggler is launched, configure the system to view the joint data as follows:

   1. Set the Streaming Tab for `ROS2 Topic Subscriber` and Buffer to `60` and press Start Button as shown:

      ![Plot Juggler Streaming Tab](/Submissions/Group%20Project%202/PlotJuggler%20Streaming.png)

   2. After pressing the Start Button a new window will pop up with all the available topics labelled `Select ROS messages`

      ![Plot Juggler ROS Messages Tab](/Submissions/Group%20Project%202/PlotJuggler%20Select%20Rosmessages.png)

   3. Select the Following three topics from list:
      1. `/forward_effort_controller/commands`
      2. `/joint_states`
      3. `/reference_joint_states/commands`
   4. Right Click on the `tab1 canvas` and Select `Split Horizontally` twice so you get a layout as shown below:

      ![Plot Juggler Canvas](/Submissions/Group%20Project%202/PlotJuggler%20Canvas.png)

   5. Drag and Drop the Following Topics in each Canvas from the Publishers Tab:

      1. Canvas 1:
         1. `/forward_effort_controller/commands/data.0`
         2. `/joint_states/joint1/position`
         3. `/joint_states/joint1/velocity`
         4. `/reference_joint_states/commands/data.0`
      2. Canvas 2:
         1. `/forward_effort_controller/commands/data.1`
         2. `/joint_states/joint2/position`
         3. `/joint_states/joint2/velocity`
         4. `/reference_joint_states/commands/data.1`
      3. Canvas 3:
         1. `/forward_effort_controller/commands/data.2`
         2. `/joint_states/joint3/position`
         3. `/joint_states/joint3/velocity`
         4. `/reference_joint_states/commands/data.2`
            The complete setup for visualization should look as below:

      ![Plot Juggler Complete Set Canvas](/Submissions/Group%20Project%202/PlotJugger%20Set%20Canvas.png)

## Assignment 3

# Tools Used

<img width="30px" align="left" alt="C" src="Resources/Logos/C Logo.jpeg">
<img width="25px" align="left" alt="CPP" src="Resources/Logos/CPP Logo.jpeg">
<img width="80px" align="left" alt="Git" src="Resources/Logos/Git Logo.jpeg">
<img width="35px" align="left" alt="GitHub" src="Resources/Logos/GitHub Logo.jpeg">
<img width="35px" align="left" alt="VS Code" src="Resources/Logos/VS Code.jpeg">

<br><br>

# Designer Details

- Designed for:
  - Worcester Polytechnic Institute
  - RBE 500: Foundation of Robotics - Final Project
- Designed by:
  - [Parth Patel](mailto:parth.pmech@gmail.com)
  - [Cameron Schloer](mailto:cameronschloer@gmail.com)
