using UnityEngine;

public class TilesMovement : MonoCache
{
    [field: SerializeField] public int Key { get; private set; }

    private Transform _transform;

    public Vector3 TargetPos { get; private set; }


    private void Awake()
    {
        _transform = transform;
        TargetPos = _transform.position;
    }

    public void InitTarget(Vector2 target)
    {
        TargetPos = target;
    }

    public override void OnTick()
    {
        _transform.position = Vector3.Lerp(_transform.position, TargetPos, 0.1f);
    }
}