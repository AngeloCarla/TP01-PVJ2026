using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float walkSpeed; // Velocidad al caminar
    private Vector3 dir = Vector3.zero; // Direccion. Comienza en 0

    [Header("Salto")]
    [SerializeField] private float JumpForce; // Fuerza de salto
    private Rigidbody rb; // Rigidbody
    
     void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // --- MOVIMIENTO ---
        // Entradas
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // Direccion
        dir = new Vector3(h, 0f, v);

        Vector3 mover = dir.normalized * walkSpeed * Time.deltaTime;

        transform.Translate(mover, Space.Self); // Se mueve en el eje local (Space.Self)

        // --- SALTO ---
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}
