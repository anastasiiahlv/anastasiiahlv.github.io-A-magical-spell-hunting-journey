using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI diamondText;
    void Start()
    {
        diamondText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateDiamondText(Inventory playerInventory)
    {
        diamondText.text = playerInventory.NumberOfSpells.ToString();
    }
}
