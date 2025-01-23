# Teleport Area

This prefab defines an area where users entering will automatically be teleported to a specific destination.

## Requirements
You need the latest [VRCSDK](https://creators.vrchat.com/sdk/) for worlds installed. It's recommended to use the VRChat Creator Companion to setup a project with the correct VRCSDK.

## How to use
1. Download the latest package from the [releases](https://github.com/dbqt/QTVRCWorldAssets/releases).
2. Drag and drop the `TeleportAreaPrefab` into the scene.
3. On the instance of the prefab, on the `BoxCollider` component, adjust the size and center to cover the desired area.
4. On the instance of the prefab, on the `TeleportArea` script component, you can customize whether the player will keep its orientation after teleporting.
5. Move the `Destination` object to where the player should be teleported (or assign a new `Transform` to the script).
6. That's it - now when the player enters the defined area, the player will be teleported.

## Notes
If you are using this in a [Vket booth](https://event.vket.com/en), make sure to move the `Scripts` folder into the submission folder.

## Version history
v1.0.0 : Initial release