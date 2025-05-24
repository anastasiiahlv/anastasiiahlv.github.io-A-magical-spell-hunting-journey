using UnityEngine;
using UnityEngine.Events;

public class Inventory : MonoBehaviour
{
    public int NumberOfSpells { get; private set; }

    public UnityEvent<Inventory> OnSpellCollected;

    public void SpellCollected()
    {
        NumberOfSpells++;
        OnSpellCollected.Invoke(this);
    }
}
