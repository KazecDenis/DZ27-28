
namespace EnemyService
{
    public class Ork : Enemy
    {
        public void Initialize(OrkSettings settings)
        {
            Health = settings.Health;
            Mana = settings.Mana;
            Agility = settings.Agility;
        }
    }
    
}
