using UnityEngine;
using Zenject;

public class LevelsCreate : MonoBehaviour
{
    [SerializeField] private LevelsData _levelsData;
    [SerializeField] private LevelView _levelViewPrefab;
    [SerializeField] private Transform _transformParent;

    [Inject] private readonly SceneLoadingService _sceneLoadingService;

    private void Awake() => Create();

    private void Create()
    {
        for (int i = 0; i < _levelsData.LevelData.Count; i++)
        {
            LevelView levelView = Instantiate(_levelViewPrefab, _transformParent);
            levelView.Setup(_sceneLoadingService, _levelsData.LevelData[i], i);
        }
    }
}