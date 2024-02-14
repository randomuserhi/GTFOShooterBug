using API;
using HarmonyLib;
using Player;
using UnityEngine;

namespace ShooterBugFix.Patches {
    [HarmonyPatch]
    internal static class ColliderPatch {
        [HarmonyPatch(typeof(Dam_PlayerDamageLocal), nameof(Dam_PlayerDamageLocal.Setup), new Type[] {
            typeof(PlayerAgent),
        })]
        [HarmonyPostfix]
        private static void Setup(Dam_PlayerDamageLocal __instance, PlayerAgent owner) {
            CapsuleCollider collider = owner.PlayerCharacterController.m_characterController.gameObject.AddComponent<CapsuleCollider>();
            collider.enabled = false;
            APILogger.Debug($"Attached capsule collider. [{owner.PlayerCharacterController.m_characterController.gameObject.GetComponents<CapsuleCollider>().Length}]");
        }
    }
}