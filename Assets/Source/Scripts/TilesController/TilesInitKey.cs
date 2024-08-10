using UnityEngine;

public class TilesInitKey : MonoBehaviour
{
    [SerializeField] private TilesMovement[] _tilesMovement;

    private void OnValidate()
    {
        for (int i = 0; i < _tilesMovement.Length; i++)
        {
            _tilesMovement[i].SetKey(i + 1);
        }
    }
}