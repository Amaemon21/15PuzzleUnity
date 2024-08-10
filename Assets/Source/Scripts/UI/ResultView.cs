using TMPro;
using UnityEngine;
using Zenject;

public class ResultView : MonoBehaviour
{
    [Inject] readonly private TilesController _tilesController;
    [Inject] readonly private Timer _timer;
    [Inject] readonly private MoveCountView _moveCountView;

    [SerializeField] private TMP_Text _stepsText;
    [SerializeField] private TMP_Text _timeText;

    private void OnEnable()
    {
        _tilesController.WinChanged += OnValueShow;
    }

    private void OnDisable()
    {
        _tilesController.WinChanged -= OnValueShow;
    }

    private void OnValueShow()
    {
        _stepsText.text = _moveCountView.MoveCount.ToString();
        _timeText.text = _timer.TimeView;
    }
}