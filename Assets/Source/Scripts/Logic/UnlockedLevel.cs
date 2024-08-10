using UnityEngine;
using YG;
using Zenject;

public class UnlockedLevel : MonoBehaviour
{
    [Inject] readonly private TilesController _tilesController;

    private void OnEnable() => _tilesController.WinChanged += Unlocked;

    private void OnDisable() => _tilesController.WinChanged -= Unlocked;

    private void Unlocked()
    {
        int index = YandexGame.savesData.Currentlevel;
        index++;
        YandexGame.savesData.openLevels[index] = true;
        YandexGame.SaveProgress();
    }
}