using System;
using System.Collections.Generic;
using System.Text;

namespace GADE_Task
{
    public class Shop
    {
        private Weapon[,] weapons;
        private Random rnd;
        private Character buyer;

        public Shop(Character inBuyer)
        {
            weapons = new Weapon[3, 3];
            rnd = new Random();

            RandomWeapon();
        }

        private Weapon RandomWeapon()
        {
            int rndWeapon = rnd.Next(1, 5);
            Weapon returnWeapon = null;

            switch (rndWeapon)
            {
                case 1:
                    returnWeapon = new MeleeWeapon(MeleeWeapon.Types.Dagger, -1, -1);
                    break;

                case 2:
                    returnWeapon = new MeleeWeapon(MeleeWeapon.Types.Longsword, -1, -1);
                    break;

                case 3:
                    returnWeapon = new RangedWeapon(RangedWeapon.Types.Rifle, -1, -1);
                    break;

                case 4:
                    returnWeapon = new RangedWeapon(RangedWeapon.Types.Longbow, -1, -1);
                    break;

                default:
                    break;
            }

            return returnWeapon;
        }
    }
}
