using UnityEngine;

namespace EnemyService
{
    public class Enemy : MonoBehaviour
    {
        private int _health;
        private int _mana;
        private int _agility;

        public int Health
        {
            get => _health;
            set
            {
                if(value < 0)
                    return;

                _health = value;

            }
        }

        public int Mana
        {
            get => _mana;
            set
            {
                if(value < 0)
                return;

                _mana = value;

            }

        }

        public int Agility
        {
            get => _agility;
            set
            {
                if(value < 0)
                    return;

                _agility = value;

            }
        }
    }
    
}
