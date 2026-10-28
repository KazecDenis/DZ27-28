using System.Collections.Generic;
using UnityEngine;

public class TimerHearthView : MonoBehaviour
{
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private Transform _container;
    private readonly List<GameObject> _hearts = new();
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
        int requiredCount = Mathf.CeilToInt(_timer.Duration);

        if (_hearts.Count != requiredCount)
            RebuildHearts(requiredCount);

        int visibleCount = Mathf.CeilToInt(_timer.RemainingTime);

        for (int i = 0; i < _hearts.Count; i++)
        {
            bool IsVisibleMore = i < visibleCount;
            _hearts[i].SetActive(IsVisibleMore);
        }
    }

    private void RebuildHearts(int count)
    {
        foreach (GameObject heart in _hearts)
        {
            Destroy(heart);
        }

        _hearts.Clear();

        for (int i = 0; i < count; i++)
        {
            GameObject hearts = Instantiate(_heartPrefab, _container);
            _hearts.Add(hearts);
        }
    }

    private void OnDestroy()
    {
        if (_timer == null)
            return;

        _timer.TimeChanged -= OnTimeChanged;
    }
}
