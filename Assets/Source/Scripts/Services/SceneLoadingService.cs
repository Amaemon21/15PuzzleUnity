using System;
using UnityEngine.AddressableAssets;

public class SceneLoadingService
{
    private bool _loading = false;

    public async void LoadScene(AssetReference scene, Action callback)
    {
        if (_loading)
            return;

        _loading = true;

        var handler = scene.LoadSceneAsync();

        await handler.Task;

        _loading = false;

        callback?.Invoke();
    }
}