using UnityEngine;

namespace EnemyService
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Elf _elfPrefab;
        [SerializeField] private Ork _orkPrefab;
        [SerializeField] private Dragon _dragonPrefab;

        [SerializeField] private Transform _elfTransform;
        [SerializeField] private Transform _orkTransform;
        [SerializeField] private Transform _dragonTransform;

        private int _elfSpawnCount;
        private int _orkSpawnCount;
        private int _dragonSpawnCount;

        public Elf CreateElf(ElfSettings settings)
        {
            Vector3 spawnPosition = _elfTransform.position + Vector3.right * _elfSpawnCount;
            Elf elf = Instantiate(_elfPrefab, spawnPosition, Quaternion.Euler(0, 180, 0), _elfTransform);
            _elfSpawnCount++;
            elf.Initialize(settings);
            return elf;
        }

        public Ork CreateOrk(OrkSettings settings)
        {
            Vector3 spawnPosition = _orkTransform.position + Vector3.right * _orkSpawnCount;
            Ork ork = Instantiate(_orkPrefab, spawnPosition, Quaternion.Euler(0, 180, 0), _orkTransform);
            _orkSpawnCount++;
            ork.Initialize(settings);
            return ork;
        }

        public Dragon CreateDragon(DragonSettings settings)
        {
            Vector3 spawnPoint = _dragonTransform.position + Vector3.right * _dragonSpawnCount;
            Dragon dragon = Instantiate(_dragonPrefab, spawnPoint, Quaternion.Euler(0, 180, 0), _dragonTransform);
            _dragonSpawnCount++;
            dragon.Initialize(settings);
            return dragon;
        }
    }
    
}
