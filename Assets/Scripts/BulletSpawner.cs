using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [Header("Disparo")]
    [SerializeField] private float speed; // Velocidad
    [SerializeField] private float initTime; // Inicio del invokeRepeating
    [SerializeField] private float interval; // Intervalo para el invokeRepeating

    [Header("Bala")]
    [SerializeField] private GameObject bullet; // Bala Enemigo

    private void Start()
    {
        InvokeRepeating("ShootFast", initTime, interval); // Invoca la bala y simula disparo
    }

    public void ShootFast()
    {
        // Instantiate (gameObject, posicion, rotacion)
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation); // Crea bala
        Destroy(newBullet, 4f); // Destruye la bala despues de un tiempo
    }
}
