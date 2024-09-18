
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ScaledArea : UdonSharpBehaviour
{
    [SerializeField, Tooltip("Set the desired height for the avatar to scale to while inside the area")]
    private float desiredScale = 0.1f;

    [SerializeField, Tooltip("Set the desired jump impulse force for the avatar to use inside the area")]
    private float desiredJumpImpulse = 2f;

    [SerializeField, Tooltip("Set the desired walk speed for the avatar to use inside the area")]
    private float desiredWalkSpeed = 0.5f;

    [SerializeField, Tooltip("Set the desired run speed for the avatar to use inside the area")]
    private float desiredRunSpeed = 1f;

    private float originalScale;
    private float originalJumpImpulse;
    private float originalWalkSpeed;
    private float originalRunSpeed;

    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (player.isLocal)
        {
            originalScale = player.GetAvatarEyeHeightAsMeters();
            originalJumpImpulse = player.GetJumpImpulse();
            originalWalkSpeed = player.GetWalkSpeed();
            originalRunSpeed = player.GetRunSpeed();

            player.SetAvatarEyeHeightByMeters(desiredScale);
            player.SetJumpImpulse(desiredJumpImpulse);
            player.SetStrafeSpeed(desiredWalkSpeed);
            player.SetWalkSpeed(desiredWalkSpeed);
            player.SetRunSpeed(desiredRunSpeed);

            base.OnPlayerTriggerEnter(player);
        }
    }

    public override void OnPlayerTriggerExit(VRCPlayerApi player)
    {
        if (player.isLocal)
        {
            player.SetAvatarEyeHeightByMeters(originalScale);
            player.SetJumpImpulse(originalJumpImpulse);
            player.SetWalkSpeed(originalWalkSpeed);
            player.SetStrafeSpeed(originalWalkSpeed);
            player.SetRunSpeed(originalRunSpeed);

            base.OnPlayerTriggerExit(player);
        }
    }
}
