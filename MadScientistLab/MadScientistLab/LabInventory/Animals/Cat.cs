using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MadScientistLab.Cli;
using MadScientistLab.Enums;
using MadScientistLab.LabInventory.Animals.Interfaces;

namespace MadScientistLab.LabInventory.Animals
{
    public class Cat : Animal, IPurrable, ISqueakable
    {
        public Cat(string name) : base(name, AnimalTypeEnum.Cat)
        {
        }

        public void Purr(ICommandInterface cli)
        {
            cli.DisplayPurr(Name);
        }

        public void Squeak(ICommandInterface cli)
        {
            cli.DisplaySqueak(Name);
        }
    }
}
