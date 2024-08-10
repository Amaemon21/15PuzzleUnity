using DG.Tweening;
using UnityEngine;

public class TilesMovement : MonoBehaviour
{
    [SerializeField] private int _key;
    private Transform _transform;

    public Vector3 TargetPos { get; private set; }
    public int Key => _key;

    private void Awake()
    {
        _transform = transform;
        TargetPos = _transform.position;
    }

    public void SetKey(int value)
    {
        _key = value;
    }

    public void InitTarget(Vector2 target)
    {
        TargetPos = target;
        _transform.DOMove(TargetPos, 0.1f);
    }
}