using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Puntos")]
    [SerializeField] private Transform pointA; // Punto A
    [SerializeField] private Transform pointB; // Punto B

    [Header("Movimiento")]
    [SerializeField] private float speed; // Velocidad
    [SerializeField] private float waitTime; // Tiempo de espera
    private bool waiting; // Esperando
    private Vector3 currentTarget; // Punto al que se dirige la plataforma (Objetivo)
    private Vector3 dir; // Direccion en la que se mueve
    private float proximityThreshold = 0.2f; // Proximidad al punto al que quiere llegar


    void Start()
    {
        pointA.parent = null;
        pointB.parent = null;

        currentTarget = pointB.position; // Primer Destino
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, currentTarget); // Distancia entre la plataforma y el punto al que quiere llegar

        if (distanceToTarget < proximityThreshold && !waiting)
        {
            transform.position = currentTarget;
            waiting = true;
            Invoke("ChangeDirection", waitTime); // Espera para volver al objetivo
        }

        dir = (currentTarget - transform.position).normalized; // Calcula la direccion de la plataforma al objetivo
        transform.position += dir * speed * Time.deltaTime; // Mueve la plataforma
    }

    private void OnTriggerStay(Collider other) // Mientras algo este dentro del Trigger
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
                player.ExternalMoveSpeed = dir * speed; // Suma la velocidad externa
            }
        }
    }

    private void OnTriggerExit(Collider other) // Cuando sale del Trigger
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                player.ExternalMoveSpeed = Vector3.zero; // Velocidad externa 0
            }
        }
    }

    private void ChangeDirection()
    {
        // Objetivo Actual = El objetivo Actual es A? SI = cambia el objetivo a B : NO = cambia el objetivo a A
        currentTarget = currentTarget == pointA.position ? pointB.position : pointA.position;
        waiting = false;
    }
}
