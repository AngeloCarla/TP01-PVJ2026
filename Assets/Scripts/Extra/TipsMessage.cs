using UnityEngine;

public class TipsMessage : MonoBehaviour
{
    // Script para dar consejos por consola
    [SerializeField] private string message; // Mensaje

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"<color=yellow>Consejo: </color><color=cyan>{message}</color>");
        }
    }
}
