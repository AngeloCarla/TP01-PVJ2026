using UnityEngine;

public class PickItem : MonoBehaviour
{
    [SerializeField] private Transform zone; // Zona de agarre
    [SerializeField] private GameObject currentItem = null; // Item actual

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Item") && currentItem == null)
        {
            if (Input.GetKeyDown(KeyCode.E)) Pick(other.gameObject); // Recoge el item con E
        }
    }

    private void Pick(GameObject item)
    {
        currentItem = item;

        item.transform.SetParent(zone);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        Collider collider = item.GetComponent<Collider>();
        if (collider != null) collider.enabled = false;
    }

    public GameObject DropItem()
    {
        GameObject temp = currentItem;
        currentItem = null;
        return temp;
    }
}
