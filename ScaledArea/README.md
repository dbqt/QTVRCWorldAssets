# Scaled Area

Also available on the [VketStore](https://store.vket.com/en/items/9293)

This prefab defines an area where users will automatically be scaled to a specific height, and going out of the area will restore the height back to what it was. For example, you can have people be automatically scaled to be tiny while in the area.

![Imgur](https://i.imgur.com/kn64j7L.gif)

[Japanese / 日本語](./README.ja.md)

## Requirements
You need the latest [VRCSDK](https://creators.vrchat.com/sdk/) for worlds installed. It's recommended to use the VRChat Creator Companion to setup a project with the correct VRCSDK.

## How to use
1. Download the latest package from the [releases](https://github.com/dbqt/QTVRCWorldAssets/releases).
2. Drag and drop the `ScaledAreaPrefab` into the scene.
3. On the instance of the prefab, on the `BoxCollider` component, adjust the size and center to cover the desired area.
4. On the instance of the prefab, on the `ScaledArea` script component, change the `Desired Scale` to the height the users in the area should be scaled to. You can also also customize the walk, run, jump settings while in the area.
5. That's it!

## Notes
If you are using this in a [Vket booth](https://event.vket.com/en), make sure to move the `Scripts` folder into the submission folder.

## Version history
v1.0.0 : Initial release

v1.0.1 : Fixed sometimes not working with multiple users

v1.0.2 : Added customization of walk speed, run speed, jump impulse

v1.0.3 : Added instructions for Japanese