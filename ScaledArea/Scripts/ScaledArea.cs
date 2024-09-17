
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ScaledArea : UdonSharpBehaviour
{
    [SerializeField, Tooltip("Set the desired height for the avatar to scale to while inside the area")]
    private float desiredScale;

    private float originalScale;

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        originalScale = player.GetAvatarEyeHeightAsMeters();
        player.SetAvatarEyeHeightByMeters(desiredScale);

        base.OnPlayerTriggerEnter(player);
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        player.SetAvatarEyeHeightByMeters(originalScale);

        base.OnPlayerTriggerExit(player);
    }
}
