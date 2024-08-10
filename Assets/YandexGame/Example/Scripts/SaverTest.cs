using UnityEngine;
using UnityEngine.UI;

namespace YG.Example
{
    public class SaverTest : MonoBehaviour
    {
        [SerializeField] InputField integerText;
        [SerializeField] InputField stringifyText;
        [SerializeField] Toggle[] booleanArrayToggle;

        private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
        private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

        private void Awake()
        {
            if (YandexGame.SDKEnabled)
                GetLoad();
        }

        public void Save()
        {
            for (int i = 0; i < booleanArrayToggle.Length; i++)
                YandexGame.savesData.openLevels[i] = booleanArrayToggle[i].isOn;

            YandexGame.SaveProgress();
        }

        public void Load() => YandexGame.LoadProgress();

        public void GetLoad()
        {
            integerText.text = string.Empty;
            stringifyText.text = string.Empty;

            for (int i = 0; i < booleanArrayToggle.Length; i++)
                booleanArrayToggle[i].isOn = YandexGame.savesData.openLevels[i];
        }
    }
}