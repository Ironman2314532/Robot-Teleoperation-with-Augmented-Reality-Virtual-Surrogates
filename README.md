Table of Contents

<!-- TOC -->

- [Introduction](#introduction)
- [How to run the project](#how-to-run-the-project)
- [Interested in Editing the project for your own use?](#interested-in-editing-the-project-for-your-own-use)
  - [Collect the Softwares to setup the project](#collect-the-softwares-to-setup-the-project)
    - [Collect the Project Files](#collect-the-project-files)
    - [Unity Hub](#unity-hub)
    - [Android Studio](#android-studio)
    - [Android NDK](#android-ndk)
    - [Visual Studio Code](#visual-studio-code)
  - [Let's start with environment setup](#lets-start-with-environment-setup)
    - [Setup Directories](#setup-directories)
  - [Setup Project Packages](#setup-project-packages)
    - [Launch Project in Unity](#launch-project-in-unity)
    - [Import Essential Packages](#import-essential-packages)
    - [Setup Android Device for App Emulation](#setup-android-device-for-app-emulation)
- [Tools Used](#tools-used)
- [Designer Details](#designer-details)
- [References](#references)

<!-- /TOC -->

# Introduction

The aim of the project is to design an Augmented Reality Tool which can make Drone Handling easier by allowing user to focus on high-level control like Motion Planning rather than lower-level tasks like Drone handling.

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

1. Download the .apk file from the repository.
2. Install it on an Android Device with Version 10 or higher.
3. Connect a gamePad Controller to it.
4. You are all set to go !!!

_Seems Like I am missing something... What am I missing?_

_My Bad, I forgot to show you what each controls on the GamePad does!_

# Interested in Editing the project for your own use?

Here Below is the guide on how you can use the project for your own purposes. The Complete Project sizes more than 5GB, so we are storing most of our project files on a Google Drive from where you can download the files for your use.

_Note: The current project is design and built for Unity Editor Version: 2020.3.42f1 - Android Build.
If you are interested in using any other version of Editor and platform, feel free to do so but take a quick moment to google on how to change editor or platform versions._

## Collect the Softwares to setup the project

### Collect the Project Files

[Click to Download Project Files](https://drive.google.com/drive/folders/1F6m2Nc7uq7a-VYWZzda4WF9UxTImIZbO?usp=share_link)

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

### Android Studio

1. [Click Link to Download Android Studio](https://developer.android.com/studio/?gclid=CjwKCAiAp7GcBhA0EiwA9U0mtlgnFQGdP97omDMtlMae11TxG08MUOjuRMRrdt3e83YcsLvDqmisWhoCT-UQAvD_BwE&gclsrc=aw.ds)
2. Install the Android Studio for your device

### Android NDK

### Visual Studio Code

Yes, I know. You can use any other IDE that you may like but I love VS Code. _So deal with it!!_

## Let's start with environment setup

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
code .
```

Extract the Project Files that you downloaded while collecting project file into current directory. You current `Robot-Teleoperation-with-Augmented-Reality-Virtual-Surrogates` directory should have the following files when you type `ls` into your terminal:

## Setup Project Packages

### Launch Project in Unity

![Unity Window](/Resources/Screenshots/Unity%20Launch.png)

_Note: When Launching the project, you might encounter issues like not Editor Version not matching, or missing packages. Don't worry, push through it and just launch the project. We'll sort the issues soon._

### Import Essential Packages

Click the `Window` button in the menu bar and click on `Package Manager` option. A new window as shown below will pop up.

![Package Manager](/Resources/Screenshots/Package%20Manager.png)

In the Top Left, you will see the current package registery option as `Packages: In Project`. Click the tab and choose `Unity Registry` to search from the global unity package registry.

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

Close the whole project and restart it again.

### Setup Android Device for App Emulation

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
  - RBE 526: Human Robot Interaction - Final Project
- Designed by:
  - [Parth Patel](mailto:parth.pmech@gmail.com)
  - [Thira Patel](mailto:thira.p23@gmail.com)

# References

- Android App Testing Guide: [Quickly preview your game on Android Device | Unity Tutorial](https://youtu.be/iCXwaehzRFQ)
- Research Guide: [Robot teleoperation with augmented reality virtual surrogates](https://ieeexplore.ieee.org/abstract/document/8673306)
- Understanding Augmented Reality in Unity: [Augmented Reality for Everyone - Full Course](https://youtu.be/WzfDo2Wpxks)
- Configuring Controller in Unity: [CONTROLLER INPUT in Unity!](https://youtu.be/p-3S73MaDP8)
- WayPoint Tracking Design: [Unity Basics - Waypoint Path system in Unity](https://youtu.be/EwHiMQ3jdHw)
- Drone Design and Control: [Unity AR foundation tutorial - AR drone for iOS and Android](https://youtu.be/MzFE2QfgohE)
- And a Super Huge help to [stackoverflow](https://stackoverflow.com/) for existing and making programming possible for us!!
