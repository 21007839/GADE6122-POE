using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace GADE_Task
{
    public class Shop
    {
        private Weapon[] weapons;
        public Weapon[] GetWeapons { get { return weapons; } set { weapons = value; } }

        private Random rnd;
        private Character buyer;

        public Shop(Character inBuyer)
        {
            buyer = inBuyer;

            weapons = new Weapon[3];
            rnd = new Random();

            for (int i = 0; i < 3; i++)
            {
                weapons[i] = RandomWeapon();
            }
        }

        public Weapon RandomWeapon()
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

        public bool CanBuy(int num)
        {
            if (num <= buyer.GetPurse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Buy(Weapon inWeapon, int num)
        {
            buyer.GetPurse -= num;

            for (int i = 0; i < 3; i++)
            {
                if (weapons[i] == inWeapon)
                {
                    buyer.Pickup(weapons[i]);

                    weapons[i] = RandomWeapon();
                }
            }
        }

        public string DisplayWeapon(Weapon inWeapon, int num)
        {
            return "Buy " + inWeapon.GetType + " (" + num + " gold)";
        }
    }
}
