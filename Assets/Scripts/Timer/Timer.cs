using System;

public class Timer
{
    public event Action Completed;
    private float _duration;
    private ReactiveProperty<float> _remainingTime;
    private TimerState _state;
    public float Duration => _duration;
    public ReactiveProperty<float> RemainingTime => _remainingTime;
    public TimerState State => _state;

    public Timer()
    {
        _remainingTime = new ReactiveProperty<float>(default);
    }

    public void Start(float duration)
    {
        if (duration <= 0)
            return;

            _duration = duration;
            _remainingTime.Value = _duration;
            _state = TimerState.Running;
    }

    public void Pause()
    {
        if (_state != TimerState.Running)
            return;

        _state = TimerState.Paused;
    }

    public void Resume()
    {
        if (_state != TimerState.Paused)
            return;

        _state = TimerState.Running;
    }

    public void Reset()
    {
        if (_duration <= 0)
            return;

        _remainingTime.Value = _duration;
        _state = TimerState.Stopped;
    }

    public void Tick(float deltaTime)
    {
        if (_state != TimerState.Running)
            return;

        if (deltaTime <= 0)
            return;

        _remainingTime.Value -= deltaTime;

        if (_remainingTime.Value <= 0)
        {
            _remainingTime.Value = 0;
            _state = TimerState.Completed;
        }

        if (_state == TimerState.Completed)
            Completed?.Invoke();

    }
    public float Progress
    {
        get
        {
            if (_duration > 0)
                return _remainingTime.Value / _duration;

            return 0;
        }
    }
}
