using System;
using System.Collections;
using System.Collections.Generic;

namespace Napilnik
{

    public class Weapon
    {
        private Stack<Bullet> _bullets = new Stack<Bullet>();

        public Weapon(int bulletsCount)
        {
            for (int i = 0; i < bulletsCount; i++)
            {
                _bullets.Add(new Bullet());
            }
        }

        public void Fire(Player player)
        {
            if (_bullets.Count <= 0)
                return;
            player.GetDamage(_bullets.Pop().Damage);
        }
    }

    public class Bullet
    {
        public uint Damage { get; private set; }
    }

    public class Player
    {
        private uint _health { get; private set; }

        public void GetDamage(int damage)
        {
            _health -= damage;
        }
    }

    public class Bot
    {
        public Weapon Weapon;

        public void OnSeePlayer(Player player)
        {
            Weapon.Fire(player);
        }
    }
}
