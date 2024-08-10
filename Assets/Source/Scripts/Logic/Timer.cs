using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;

    private float _timer;
     
    public string TimeView { get; private set; }

    private void OnValidate()
    {
        _timerText ??= GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        UpdateTimerText(_timer);  
    }

    private void UpdateTimerText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);

        TimeView = string.Format("{0:00}:{1:00}", minutes, seconds);

        _timerText.text = TimeView;
    }
}