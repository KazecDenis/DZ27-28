using System;

public class EnemyRegistration
{
    public Enemy Enemy {get;}
    public Func<bool> DestroyCondition {get;}
    
    public EnemyRegistration (Enemy enemy, Func<bool> destroyCondition)
    {
        Enemy = enemy;
        DestroyCondition = destroyCondition;
    }
}
