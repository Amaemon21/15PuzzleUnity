using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using YG;

public class LevelView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private Image _lockImage;

    private Level _level;
    private SceneLoadingService _sceneLoadingService;

    private int _currentLevel;
    private bool _locked;   

    private void OnValidate()
    {
        _image ??= GetComponentInChildren<Image>();
        _nameText ??= GetComponentInChildren<TMP_Text>();
    }

    public void Setup(SceneLoadingService sceneLoadingService, Level level, int index)
    {
        _sceneLoadingService = sceneLoadingService;
        _level = level;
        _image.sprite = _level.Sprite;
        _nameText.text = _level.Name;
        _currentLevel = index;
        Load(_currentLevel);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartLevel();
    }

    private void StartLevel()
    {
        if (!_locked) 
            return;

        Save(_currentLevel);
        _sceneLoadingService.LoadScene(_level.Scene, null);
    }

    private void Load(int index)
    {
        _locked = YandexGame.savesData.openLevels[index];

        if (_locked)
            _lockImage.gameObject.SetActive(false);
        else 
            _lockImage.gameObject.SetActive(true);
    }

    private void Save(int index)
    {
        YandexGame.savesData.Currentlevel = index;
        YandexGame.SaveProgress();
    }
}