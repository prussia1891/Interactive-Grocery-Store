# Interactive Grocery Store

- A small interactive Unity scene created for the interactive elements assignment.

- The project uses the free **Lite Grocery Store Pack** from the Unity Asset Store as the environment. The interaction logic and scene modifications were implemented for this assignment.

## Unity Version

Unity 6000.6.2f1

## Controls

- W / Up Arrow: Move crosshair up
- S / Down Arrow: Move crosshair down
- A / Left Arrow: Move crosshair left
- D / Right Arrow: Move crosshair right
- E: Interact with the object under the crosshair

## Interactive Elements

### 1. Physics Interaction
When the crosshair is placed over a box or milk carton and `E` is pressed, the object is released and falls under gravity.

### 2. Color Interaction
When a chocolate bar is selected and `E` is pressed, its material color changes. Different chocolate bars use different interaction colors.

### 3. Scale Interaction
When a tomato is selected and `E` is pressed, the tomato increases in size. Pressing `E` again returns it to its original size.

### 4. Position Interaction
When a fruit case is selected and `E` is pressed, the case slides outward. Pressing `E` again moves it back to its original position.

### 5. UI Interaction
When the cashier is selected and `E` is pressed, the following message appears on screen:

**You little troublemaker!**

The message automatically disappears after a short period.

## Interaction System

- A movable UI crosshair is used to select objects in the scene.

- The crosshair screen position is converted into a ray from the Main Camera using `ScreenPointToRay`. A physics raycast detects the object under the crosshair.

- Interactive objects inherit from a common `Interactable` class and implement their own `Interact()` behavior.

## Third-Party Asset

- Environment: **Lite Grocery Store Pack**  - Unity Asset Store

- **The original third-party asset files are not included in this repository.**

- To reproduce the complete scene, import the Lite Grocery Store Pack into the Unity project before opening the grocery store scene.

## Demo Video

YouTube demo:

[]
