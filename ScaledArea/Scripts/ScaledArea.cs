namespace QTVRCWorldAssets
{
    using UdonSharp;
    using UnityEngine;
    using VRC.SDKBase;

    public class ScaledArea : UdonSharpBehaviour
    {
        [SerializeField, Tooltip("Whether to use direct scaling or proportional scaling. Direct scaling will set the avatar to a specific height, while proportional scaling will scale the avatar by a multiplier of their original height.")]
        private bool directScaling = true;

        [SerializeField, Tooltip("Set the desired height for the avatar to scale to while inside the area. If direct scaling is enabled, this is the scale in meters. Otherwise, this is a percentage of the original scale.")]
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

        private bool isInScaledArea = false;
        private bool isAvatarChanging = false;

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            if (player.isLocal)
            {
                originalScale = player.GetAvatarEyeHeightAsMeters();
                originalJumpImpulse = player.GetJumpImpulse();
                originalWalkSpeed = player.GetWalkSpeed();
                originalRunSpeed = player.GetRunSpeed();

                if (directScaling) 
                {
                    player.SetAvatarEyeHeightByMeters(desiredScale);
                }
                else
                {
                    player.SetAvatarEyeHeightByMultiplier(desiredScale);
                }

                player.SetJumpImpulse(desiredJumpImpulse);
                player.SetStrafeSpeed(desiredWalkSpeed);
                player.SetWalkSpeed(desiredWalkSpeed);
                player.SetRunSpeed(desiredRunSpeed);

                isInScaledArea = true;
            }

            base.OnPlayerTriggerEnter(player);
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

                isInScaledArea = false;
            }

            base.OnPlayerTriggerExit(player);
        }

        public override void OnAvatarChanged(VRCPlayerApi player)
        {
            if (player.isLocal && isInScaledArea)
            {
                isAvatarChanging = true;
            }

            base.OnAvatarChanged(player);
        }

        public override void OnAvatarEyeHeightChanged(VRCPlayerApi player, float prevEyeHeightAsMeters)
        {
            // Only reapply scaling if this height change was caused by an avatar change
            if (player.isLocal && isInScaledArea && isAvatarChanging)
            {
                // Save new original scale
                originalScale = player.GetAvatarEyeHeightAsMeters();

                player.SetAvatarEyeHeightByMeters(desiredScale);
                player.SetJumpImpulse(desiredJumpImpulse);
                player.SetStrafeSpeed(desiredWalkSpeed);
                player.SetWalkSpeed(desiredWalkSpeed);
                player.SetRunSpeed(desiredRunSpeed);
            }

            isAvatarChanging = false;
            base.OnAvatarEyeHeightChanged(player, prevEyeHeightAsMeters);
        }
    }
}