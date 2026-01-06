using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _interactionRadius = 3f;
    [SerializeField] private LayerMask _interactableLayer; 
    [SerializeField] private KeyCode _interactKey = KeyCode.F;

    [Header("UI")]
    [SerializeField] private GameObject _interactionUI;

    private IInteractable _nearestInteractable;

    private void Update()
    {
        FindNearestInteractable();

        if (_nearestInteractable != null && Input.GetKeyDown(_interactKey))
        {
            _nearestInteractable.Interact();
            _interactionUI.SetActive(false);
            _nearestInteractable = null;
        }
    }

    private void FindNearestInteractable()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _interactionRadius, _interactableLayer);

        if (colliders.Length > 0)
        {
            if (colliders[0].TryGetComponent(out IInteractable interactable))
            {
                _nearestInteractable = interactable;
                _interactionUI.SetActive(true);
                return;
            }
        }

        _nearestInteractable = null;
        _interactionUI.SetActive(false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _interactionRadius);
    }
}