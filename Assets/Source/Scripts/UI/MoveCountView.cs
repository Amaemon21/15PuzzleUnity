using TMPro;
using UnityEngine;
using Zenject;

public class MoveCountView : MonoBehaviour
{
    [Inject] readonly private TilesController _tilesController;

    [SerializeField] private TMP_Text _moveCountText;

    private int _moveCount;

    public int MoveCount => _moveCount;

    private void OnEnable() => _tilesController.MoveCountChanged += OnMoveCount;

    private void OnDisable() => _tilesController.MoveCountChanged -= OnMoveCount;

    private void OnMoveCount()
    {
        _moveCount++;
        _moveCountText.text = _moveCount.ToString();
    }
}