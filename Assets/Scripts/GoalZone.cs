using UnityEngine;

public class GoalZone : MonoBehaviour
{
    [SerializeField] private Transform goal;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PickItem pickItem = other.GetComponent<PickItem>();
            if (pickItem != null)
            {
                GameObject item = pickItem.DropItem();

                if (item != null)
                {
                    ItemInZone(item);
                    Debug.Log($"<color=green>Felicidades GANASTE!</color>");
                }
                else
                {
                    Debug.Log($"<color=red>Te falta el item</color>");
                }
            }
        }
    }

    private void ItemInZone(GameObject item)
    {
        item.transform.SetParent(goal);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        Collider collider = item.GetComponent<Collider>();
        if (collider != null) collider.enabled = true;
    }
}
