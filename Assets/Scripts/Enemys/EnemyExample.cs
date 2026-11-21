using UnityEngine;

namespace EnemyService
{
    public class EnemyExample : MonoBehaviour
    {
        [SerializeField] private ElfSettings[] _elfSettings;
        [SerializeField] private OrkSettings[] _orkSettings;
        [SerializeField] private DragonSettings[] _dragonSettings;
        [SerializeField] private EnemySpawner _spawner;
        private int _countEnemy = 3;

        private void Start()
        {
            for (int i = 0; i < _countEnemy; i++)
            {
                CreateRandomElf();
                CreateRandomOrk();
                CreateRandomDragon();
            }
        }
                
        private void CreateRandomElf()
        {
            ElfSettings elfRandomSettings = GetRandomSettings(_elfSettings);
            Elf elf = _spawner.CreateElf(elfRandomSettings);
            ShowInfoElf(elf);
        }

        private void CreateRandomOrk()
        {
            OrkSettings orkRandomSettings = GetRandomSettings(_orkSettings);
            Ork ork = _spawner.CreateOrk(orkRandomSettings);
            ShowInfoOrk(ork);
        }

        private void CreateRandomDragon()
        {
            DragonSettings dragonRandomSettings = GetRandomSettings(_dragonSettings);
            Dragon dragon = _spawner.CreateDragon(dragonRandomSettings);
            ShowInfoDragon(dragon);
        }
        
        private T GetRandomSettings<T>(T[] settings)
        {
            int randomIndex = Random.Range(0, settings.Length);
            return settings[randomIndex];
        }
        
        private void ShowInfoElf(Elf elf) => Debug.Log($"у Эльфа {elf.Health} жизней, {elf.Mana} маны, и ловкость {elf.Agility}");
        private void ShowInfoOrk(Ork ork) => Debug.Log($"у Орка {ork.Health} жизней, {ork.Mana} маны, и ловкость {ork.Agility}");
        private void ShowInfoDragon(Dragon dragon) => Debug.Log($"у Дракона {dragon.Health} жизней, {dragon.Mana} маны, и ловкость {dragon.Agility}");
    }
    
}

