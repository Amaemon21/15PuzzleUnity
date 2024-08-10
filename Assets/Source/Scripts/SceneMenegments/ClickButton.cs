using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Zenject;

public class ClickButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private AssetReference _levelScene;

    [Inject] private readonly SceneLoadingService _sceneLoadingService;

    private void OnValidate()
    {
        _button ??= GetComponent<Button>();
    }

    private void OnEnable() => _button.onClick.AddListener(OnClickPlayButton);

    private void OnDisable() => _button.onClick.RemoveListener(OnClickPlayButton);

    private void OnClickPlayButton() => _sceneLoadingService.LoadScene(_levelScene, null);
}