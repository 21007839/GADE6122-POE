using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    [Serializable]
    public class Goblin : Enemy
    {
        /// <summary>
        /// Goblin constructor
        /// </summary>
        /// <param name="inX"></param>
        /// <param name="inY"></param>
        /// <param name="inMaxHP"></param>
        /// <param name="inDamage"></param>
        public Goblin(int inX, int inY, int inMaxHP, int inDamage) : base(inX, inY, inMaxHP, inDamage, GameEngine.GetGoblinSymbol)
        {
            GetEquipment = new MeleeWeapon(MeleeWeapon.Types.Dagger, -1, -1);
            damage = GetEquipment.GetDamage;
            GetPurse = 1;
        }

        /// <summary>
        /// The method by which a goblin attacks the hero.
        /// </summary>
        /// <param name="target"></param>
        public override void Attack(Character target)
        {
            if (CheckRange(target))
            {
                // Calculates the new HP value
                int newHP = target.GetHP - this.damage;
                target.GetHP = newHP;

                // Decrement the weapon's durability
                if (GetEquipment != null)
                {
                    GetEquipment.GetDurability--;

                    // Destroy the weapon if the durability reaches 0
                    if (GetEquipment.GetDurability == 0)
                    {
                        GetEquipment = null;
                    }
                }

                // Checks if the target is defeated
                if (target.IsDead())
                {
                    // The victor loots the defeated character
                    this.Loot(target);

                    // Updates the map display if the hero is defeated
                    Game.ge.GetGameMap.GetMap[target.GetY, target.GetX] = new EmptyTile(target.GetY, target.GetX);
                }
            }
        }

        /// <summary>
        /// Checks if a movement is valid.
        /// </summary>
        /// <param name="move"></param>
        /// <returns></returns>
        public override MovementEnum ReturnMove(MovementEnum move)
        {
            // Generates a random direction for the goblin to move in
            int direction = rnd.Next(1, 5);

            // Checks an inputted movement against the goblin's vision array
            switch (direction)
            {
                case 1:
                    if (vision[0].GetSymbol == ' ' || vision[0].GetSymbol == 'W')
                    {
                        return MovementEnum.Up;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case 2:
                    if (vision[1].GetSymbol == ' ' || vision[1].GetSymbol == 'W')
                    {
                        return MovementEnum.Down;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case 3:
                    if (vision[2].GetSymbol == ' ' || vision[2].GetSymbol == 'W')
                    {
                        return MovementEnum.Left;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                case 4:
                    if (vision[3].GetSymbol == ' ' || vision[3].GetSymbol == 'W')
                    {
                        return MovementEnum.Right;
                    }
                    else
                    {
                        return MovementEnum.None;
                    }

                default:
                    return MovementEnum.None;
            }
        }
    }
}
