
namespace EnemyService
{
    public class Elf : Enemy
    {
        public void Initialize(ElfSettings settings)
        {
            Health = settings.Health;
            Mana = settings.Mana;
            Agility = settings.Agility;
        }
    }
    
}
