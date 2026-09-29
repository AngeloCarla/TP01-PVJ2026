using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField] private float speed; // Velocidad
    private Vector3 dir = Vector3.forward; // Se mueve en Z, hacia adelante

    void Update()
    {
        // --- MOVIMIENTO ---
        Vector3 z = dir.normalized * speed * Time.deltaTime;
        transform.Translate(z, Space.Self);
    }
}
