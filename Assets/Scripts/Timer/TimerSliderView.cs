using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TimerSliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    private Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.TimeChanged += OnTimeChanged;
        UpdateView();
    }

    private void OnTimeChanged(float remainingTime)
    {
        UpdateView();
    }

    private void UpdateView()
    {
        _slider.value = _timer.Progress;
        _text.text = _timer.Progress.ToString("F2");
    }

    private void OnDestroy()
    {
        if (_timer != null)
            _timer.TimeChanged -= OnTimeChanged;
    }
}
