using UnityEngine;

public class EnemyExample : MonoBehaviour
{
    [SerializeField] private Enemy _enemyIsDeadPrefab;
    [SerializeField] private Enemy _enemyTimeDeadPrefab;
    [SerializeField] private Enemy _enemyCountDeadPrefab;
    [SerializeField] private Transform _spawnPointIsDead;
    [SerializeField] private Transform _spawnPointTimeDead;
    [SerializeField] private Transform _spawnPointCountDead;
    [SerializeField] private float _lifeTimeEnemy = 5f;
    [SerializeField] private int _maxCountEnemy = 2;
    private EnemyDestroyService _destroyService;
    private Enemy _isDeadEnemy;
    private Enemy _isMixEnemy;

    private void Awake()
    {
        _destroyService = new EnemyDestroyService();
    }

    private void Update()
    {
        _destroyService.Tick();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            CreateEnemyIsDead();
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
            CreateEnemyTimeDead();
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
            CreateEnemyCount();
        
        if (Input.GetKeyDown(KeyCode.Alpha4))
            CreateMixEnemy();
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isDeadEnemy != null)
                _isDeadEnemy.Kill();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_isMixEnemy != null)
                _isMixEnemy.Kill();
        }
    }
    private Enemy CreateEnemy(Enemy enemyPrefab, Transform spawnPoint) => Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    private void CreateEnemyIsDead()
    {
        if (_isDeadEnemy != null)
            return;

        Enemy enemyIsDead = CreateEnemy(_enemyIsDeadPrefab, _spawnPointIsDead);
        _isDeadEnemy = enemyIsDead;
        _destroyService.Register(enemyIsDead, () => enemyIsDead.IsDead);
    }
    private void CreateEnemyCount()
    {
        Enemy enemyCountDestroy = CreateEnemy(_enemyCountDeadPrefab, _spawnPointCountDead);
        _destroyService.Register(enemyCountDestroy, () => _destroyService.Count > _maxCountEnemy);
    }
    private void CreateEnemyTimeDead()
    {
        Enemy enemyTimeDead = CreateEnemy(_enemyTimeDeadPrefab, _spawnPointTimeDead);
        float destroyTime = Time.time + _lifeTimeEnemy;
        _destroyService.Register(enemyTimeDead, () => Time.time >= destroyTime);
    }
    private void CreateMixEnemy()
    {
        Enemy enemyMix = CreateEnemy(_enemyIsDeadPrefab, _spawnPointIsDead);
        _isMixEnemy = enemyMix;
        float destroyTime = Time.time + _lifeTimeEnemy;
        _destroyService.Register(enemyMix, () => enemyMix.IsDead && Time.time >= destroyTime);
    }
}
   
        

        
        

        
        

