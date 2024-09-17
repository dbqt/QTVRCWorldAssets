# Scaled Area

This prefab defines an area where users will automatically be scaled to a specific height, and going out of the area will restore the height back to what it was. For example, you can have people be automatically scaled to be tiny while in the area.

![Imgur](https://i.imgur.com/kn64j7L.gif)

## Requirements
You need the latest [VRCSDK](https://creators.vrchat.com/sdk/) for worlds installed. It's recommended to use the VRChat Creator Companion to setup a project with the correct VRCSDK.

## How to use
1. Download the latest package from the [releases](https://github.com/dbqt/QTVRCWorldAssets/releases).
2. Drag and drop the `ScaledAreaPrefab` into the scene.
3. On the instance of the prefab, on the `BoxCollider` component, adjust the size and center to cover the desired area.
4. On the instance of the prefab, on the `ScaledArea` script component, change the `Desired Scale` to the height the users in the area should be scaled to.
5. That's it!

## Notes
If you are using this in a [Vket booth](https://event.vket.com/en), make sure to move the `Scripts` folder into the submission folder.