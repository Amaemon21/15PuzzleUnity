using UnityEngine;
using Zenject;

public class WinPanel : MonoBehaviour
{
    [Inject] readonly private TilesController _tilesController;

    [SerializeField] private GameObject _winPanel;

    private void OnEnable() => _tilesController.WinChanged += OnOpenWinPanel;

    private void OnDisable() => _tilesController.WinChanged -= OnOpenWinPanel;

    private void Start() => _winPanel.SetActive(false);

    private void OnOpenWinPanel() => _winPanel.SetActive(true);
}
