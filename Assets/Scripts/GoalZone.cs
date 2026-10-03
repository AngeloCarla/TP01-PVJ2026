using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [SerializeField] private Transform goal; // Zona de entrega
    private bool completed = false; // Desafio completo

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !completed)
        {
            PickItem pickItem = other.GetComponent<PickItem>();
            if (pickItem != null)
            {
                GameObject item = pickItem.DropItem(); // Deja el objto que tiene el jugador

                if (item != null)
                {
                    ItemInZone(item); // Coloca al item en la zona de entrega
                    Debug.Log($"<color=green>Felicidades GANASTE!</color>");
                    completed = true;
                }
                else
                {
                    Debug.Log($"<color=red>Falta el item</color>");
                }
            }
        }
    }

    private void ItemInZone(GameObject item)
    {
        item.transform.SetParent(goal);
        item.transform.localPosition = new Vector3(0f, 5f, 0f);
        item.transform.localRotation = Quaternion.identity;

        Collider collider = item.GetComponent<Collider>();
        if (collider != null) collider.enabled = true;
    }
}
