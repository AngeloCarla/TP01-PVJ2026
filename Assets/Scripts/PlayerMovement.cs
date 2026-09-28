using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float walkSpeed; // Velocidad al caminar
    private Vector3 dir = Vector3.zero; // Direccion. Comienza en 0
    public Vector3 externalMoveSpeed; // Velocidad externa

    [Header("Salto")]
    [SerializeField] private float JumpForce; // Fuerza de salto
    private Rigidbody rb; // Rigidbody
    [SerializeField] private bool isGrounded = true; // Esta en el suelo

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

        Vector3 mover = dir.normalized * walkSpeed * Time.deltaTime + externalMoveSpeed * Time.deltaTime;

        transform.Translate(mover, Space.Self); // Se mueve en el eje local (Space.Self)

        // --- SALTO ---
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Detecta el suelo
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision) // Detecta el suelo
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
