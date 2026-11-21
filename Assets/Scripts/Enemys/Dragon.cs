

namespace EnemyService
{
    public class Dragon : Enemy
    {
        public void Initialize(DragonSettings settings)
        {
            Health = settings.Health;
            Mana = settings.Mana;
            Agility = settings.Agility;
        }
    }
    
}
