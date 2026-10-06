using UnityEngine;

public class DoubleJumpPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.EnableDoubleJump(); // Activa el doble salto

                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}
