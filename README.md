Gameplay Feature Mechanic – Floating Island Prototype

Project Overview
Floating Island is a small 3D gameplay prototype developed in Unity 2022.3.62f1 for GDT-110. The purpose of this project is to demonstrate how Unity's game engine systems work together to support player movement, platform traversal, collision detection, and object interaction.
The environment was originally created in Blender and imported into Unity. The player begins on a lower section of a floating island and must jump from platform to platform to reach a well at the top.

Gameplay Objective
The player's objective is to reach the well on the upper island and interact with it to complete the level.
The player must navigate the environment by moving and jumping between platforms. Once the player enters the well's interaction area, a message appears asking them to press E.
Pressing E completes the objective and displays a completion message. Pressing Escape resets the interaction, allowing the player to demonstrate the mechanic again without restarting the game.

Gameplay Controls
Input	                      Action
W,A,S,D	                    Move the player
Space	                      Jump
Mouse Right and Movement	  Rotate Camera
Mouse Scroll	              Zoom in and out
E	                          Interact when prompted
Escape	                    Reset completed message

Gameplay Mechanics

Player Movement and Jumping
The PlayerMovement script uses Unity's Character Controller to handle player movement, jumping, and gravity. Collision detection allows the player to stand on the terrain and jump between platforms.

Camera System
The CameraFollow script provides a third-person camera that follows the player. The player can rotate the camera and adjust its distance using the mouse.

Collision and Trigger Detection
The terrain and platforms use solid colliders to prevent the player from passing through them. The well uses a Sphere Collider configured as a trigger to detect when the player enters or exits its interaction area.

Well Interaction
The WellInteract script checks whether the player is within the interaction area and whether the E key has been pressed.
When the interaction is successful, the system changes the completion state and displays a message using Unity's UI system.

Reset Functionality
After completing the objective, the player can press Escape to reset the interaction. This allows the same mechanic to be demonstrated repeatedly.

Unity Engine Features Demonstrated
This prototype demonstrates Unity's component-based architecture, which I discussed in my Topic 1 research assignment.
Unity uses GameObjects and Components to separate different responsibilities within a game. This project demonstrates that structure through:
  •	Input Manager: Detects keyboard and mouse input.
  •	Character Controller: Handles player movement and collision responses.
  •	Physics and Colliders: Support platform traversal and trigger detection.
  •	Rendering: Displays the imported 3D environment, materials, and player.
  •	C# Scripting: Controls gameplay rules, interactions, and state changes.
  •	UI System: Provides feedback when interactions become available and when the objective is completed.
Separating these systems makes gameplay behaviors easier to manage, test, and modify.

Software Requirements
  •	Unity Editor 2022.3.62f1
  •	Unity Hub
  •	A computer capable of running the Unity Editor

Installation and Setup
  1.	Download or clone this GitHub repository.
  2.	Open Unity Hub.
  3.	Select Add Project from Disk and choose the downloaded project folder.
  4.	Open the project using Unity Editor 2022.3.62f1.
  5.	Open the Floating Island gameplay scene in the Assets/Scenes folder.
  6.	Press Play in the Unity Editor.

How to Reproduce the Demonstration
  1.	Start the game and locate the player on the lower island.
  2.	Use WASD to move around the environment.
  3.	Use Space to jump onto the platforms leading upward.
  4.	Rotate the camera using the right mouse button and adjust zoom using the scroll wheel.
  5.	Continue climbing until reaching the upper island.
  6.	Approach the well until the interaction message appears.
  7.	Press E to activate the well and display the completion message.
  8.	Press Escape to reset the interaction.
  9.	Press E again while still within range to repeat the interaction.

Gameplay Flowchart
The gameplay flowchart illustrates the player's movement, platform traversal, well trigger detection, interaction conditions, completion state, and reset functionality.
Chart: https://github.com/robertstahldev/Gameplay_Feature_GDT110/blob/main/GameplayFeatureDiagram.png

Project Repository
GitHub: https://github.com/robertstahldev/Gameplay_Feature_GDT110

Video Demonstration
Video: https://www.loom.com/share/ac16171274ec44aaba108178cdca0556

Development Tools
  •	Unity 2022.3.62f1
  •	Blender
  •	C#
  •	Visual Studio
  •	Lucidchart

References
Gregory, J. (2018). Game engine architecture (3rd ed.). CRC Press.

