using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Monster
    {
        Random random = new Random();
        const string _warCry = "к атаке!";
        const string _dieCry = "я умираю...";

        private string _name = "no name";
        private string[] _monsterType = { "дракон", "фея", "орк", "нежить", "тварь", "мутант", "демон" };
        private int _HP = 0;
        private int _maxHP = 500;
        private int _minAttack = 1;
        private int _maxAttack = 100;
        private

        public string Name
        { 
            get => _name;
            set 
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Название монстра не должно быть пустым!");
                else _name = value;
            }
        }


        public int HP
        {
            get => _HP;
            set => _HP = (value >= _maxHP ? _maxHP : (value < 0 ? _maxHP : value));
        }

        public int MaxHP
        {
            get => _maxHP;
            set => _maxHP = value >= 0 && value <= 500 ? value : 
                throw new ArgumentException("Неверное значение максимального полного здоровья!");
        }

        public int MinAttack
        {
            get => _minAttack;
            set => _minAttack = value >= 1 && value <= 10 ? value :
                throw new ArgumentException("Неверное значение минимальной силы атаки!");
        }

        public int MaxAttack
        {
            get => _maxAttack;
            set => _maxAttack = value >= 20 && value <= 100 ? value :
                throw new ArgumentException("Неверное значение максимальной силы атаки!");
        }

        public bool IsDie => _HP == 0 ? true : false; 

        public string GetInfo => $"Имя: {Name}, тип: {_monsterType}, текущее здоровье: {HP}";

        public int GetAttack (int bonus) => random.Next(MinAttack, MaxAttack + 1) + bonus;
        public void Wounds(int damage) => HP -= damage;

        public void Heal() => HP = MaxHP;
    }
}
