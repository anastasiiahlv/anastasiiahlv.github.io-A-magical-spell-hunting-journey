using UnityEngine;
using System.Collections;

public class SpellController : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = new Vector3(0, 1, 0);
    [SerializeField] private float rotationSpeed = 90f;

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Inventory playerInventory = other.GetComponent<Inventory>();

        if (playerInventory != null)
        {
            playerInventory.SpellCollected();
            gameObject.SetActive(false);
        }
    }
}