namespace QTVRCWorldAssets
{
    using UdonSharp;
    using UnityEngine;
    using VRC.SDKBase;

    public class TeleportInteractable : UdonSharpBehaviour
    {
        [SerializeField, Header("The transform of where the player should be teleporter to.")]
        private Transform destination;

        [SerializeField, Header("If on, this will keep the player's orientation on teleporting.\nIf off, the player will align with the destination.")]
        private bool keepPlayerOrientation;

        public override void Interact()
        {
            Networking.LocalPlayer.TeleportTo(destination.position, keepPlayerOrientation ? Networking.LocalPlayer.GetRotation() : destination.rotation);
        }
    }
}
