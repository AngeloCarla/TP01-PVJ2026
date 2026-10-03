using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimiento")]
    [SerializeField] private float walkSpeed; // Velocidad al caminar
    private Vector3 dir = Vector3.zero; // Direccion. Comienza en 0
    private Vector3 externalMoveSpeed; // Velocidad externa

    [Header("Salto")]
    [SerializeField] private float JumpForce; // Fuerza de salto
    private Rigidbody rb; // Rigidbody
    [SerializeField] private bool isGrounded; // Esta en el suelo

    [Header("Doble Salto")]
    [SerializeField] private int maxJumps = 1; // Maximo de saltos
    private float doubleJumpTime = 10f; // Tiempo de PowerUp
    private int jumpCount = 0; // Contador de saltos
    private bool doubleJumpActive = false; // PowerUp Activo

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
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            jumpCount++;
        }
    }


    private void OnCollisionEnter(Collision collision) // Detecta el suelo
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit(Collision collision) // Detecta el suelo
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private IEnumerator DoubleJump()
    {
        doubleJumpActive = true;
        maxJumps = 2; // Doble salto
        Debug.Log($"<color=cyan>Doble Salto ACTIVADO</color>");

        yield return new WaitForSeconds(doubleJumpTime);

        doubleJumpActive = false;
        maxJumps = 1;
        Debug.Log($"<color=red>Doble Salto DESACTIVADO</color>");
    }

    public void EnableDoubleJump()
    {
        if (!doubleJumpActive)
        {
            StartCoroutine(DoubleJump()); // Ativa corrutina
        }
    }

    public Vector3 ExternalMoveSpeed { get => externalMoveSpeed; set => externalMoveSpeed = value; }
}
