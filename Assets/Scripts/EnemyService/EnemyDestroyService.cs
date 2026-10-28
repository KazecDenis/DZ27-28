using System;
using System.Collections.Generic;

public class EnemyDestroyService
{
    private readonly List<EnemyRegistration> _enemies = new();
    public int Count => _enemies.Count;

    public void Register(Enemy enemy, Func<bool> destroyCondition)
    {
        EnemyRegistration registration = new EnemyRegistration(enemy, destroyCondition);
        _enemies.Add(registration);
    }
    public void Tick()
    {
        for (int i = Count - 1; i >= 0; i--)
        {
            EnemyRegistration registration = _enemies[i];
            bool shouldDestroy = registration.DestroyCondition.Invoke();

            if (shouldDestroy == false)
                continue;

            UnityEngine.Object.Destroy(registration.Enemy.gameObject);
            _enemies.RemoveAt(i);
        }
    }
}
