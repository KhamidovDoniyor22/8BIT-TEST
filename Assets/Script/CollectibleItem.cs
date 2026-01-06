using System;
using UnityEngine;

public class CollectibleItem : MonoBehaviour, IInteractable
{
    public static event Action OnCollected;

    public void Interact()
    {
        Debug.Log("Item Picked Up!");
        OnCollected?.Invoke();
        Destroy(gameObject);
    }
}