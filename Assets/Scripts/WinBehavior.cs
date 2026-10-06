using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.ParticleSystem;

public class WinBehavior : MonoBehaviour
{
    // Script de victoria
    [SerializeField] private ParticleSystem confetiR;
    [SerializeField] private ParticleSystem confetiL;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("<color=green>GANASTE!!! Felicidades, lograste sobrevivir</color>");
            confetiL.Play();
            confetiR.Play();
        }
    }
}
