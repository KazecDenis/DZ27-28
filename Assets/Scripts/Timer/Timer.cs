using System;

public class Timer
{
    public event Action<float> TimeChanged;
    public event Action Completed;
    private float _duration;
    private float _remainingTime;
    private TimerState _state;

    public float Duration => _duration;
    public float RemainingTime => _remainingTime;
    public TimerState State => _state;

    public void Start(float duration)
    {
        if (duration <= 0)
            return;

            _duration = duration;
            _remainingTime = _duration;
            _state = TimerState.Running;

            TimeChanged?.Invoke(_remainingTime);
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

        _remainingTime = _duration;
        _state = TimerState.Stopped;

        TimeChanged?.Invoke(_remainingTime);
    }

    public void Tick(float deltaTime)
    {
        if (_state != TimerState.Running)
            return;

        if (deltaTime <= 0)
            return;

        _remainingTime -= deltaTime;

        if (_remainingTime <= 0)
        {
            _remainingTime = 0;
            _state = TimerState.Completed;
        }

        TimeChanged?.Invoke(_remainingTime);

        if (_state == TimerState.Completed)
            Completed?.Invoke();

    }
    public float Progress
    {
        get
        {
            if (_duration > 0)
                return _remainingTime / _duration;

            return 0;
        }
    }
}
