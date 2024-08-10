using UnityEngine;

public class UIPopup : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnValidate()
    {
        _animator ??= GetComponentInChildren<Animator>();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}