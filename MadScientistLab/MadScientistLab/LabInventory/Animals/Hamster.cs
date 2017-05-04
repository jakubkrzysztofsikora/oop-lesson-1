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
    public class Hamster : Animal, ISqueakable
    {
        public Hamster(string name) : base(name, AnimalTypeEnum.Hamster)
        {
        }

        public void Squeak(ICommandInterface cli)
        {
            cli.DisplaySqueak(Name);
        }
    }
}

