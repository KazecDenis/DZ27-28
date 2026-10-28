using UnityEngine;

public class TimeExample : MonoBehaviour
{
   [SerializeField] private float _duration = 10f;
    [SerializeField] private TimerSliderView _timerSliderView;
    [SerializeField] private TimerHearthView _timerHearthView;
   private Timer _timer;

    private void Awake()
    {
        _timer = new Timer();
        
        _timer.TimeChanged += OnTimeChanged;
        _timer.Completed += OnCompleted;

        _timerSliderView.Initialize(_timer);
        _timerHearthView.Initialize(_timer);
    }

    private void Update()
    {
        _timer.Tick(Time.deltaTime);
    }
    
    public void StartTimer() => _timer.Start(_duration);
    public void ResetTimer() => _timer.Reset();
    public void ResumeTimer() => _timer.Resume();
    public void PauseTimer() => _timer.Pause();

    private void OnDestroy()
    {
        if (_timer == null)
            return;

        _timer.TimeChanged -= OnTimeChanged;
        _timer.Completed -= OnCompleted;
    } 
    private void OnTimeChanged(float remainingTime)
    {
        Debug.Log($"Времени осталось: {remainingTime}");
    }

    private void OnCompleted()
    {
        Debug.Log("Таймер завершен!");
    }

}


        

