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
    public class Tiger : Animal, IPurrable
    {
        public Tiger(string name) : base(name, AnimalTypeEnum.Tiger)
        {
        }

        public void Purr(ICommandInterface cli)
        {
            cli.DisplayPurr(Name);
        }
    }
}