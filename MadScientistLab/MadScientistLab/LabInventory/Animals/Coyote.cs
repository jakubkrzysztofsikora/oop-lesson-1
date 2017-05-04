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
    public class Coyote : Animal, IBarkable
    {
        public Coyote(string name) : base(name, AnimalTypeEnum.Coyote)
        {
        }

        public void Bark(ICommandInterface cli)
        {
            cli.DisplayBark(Name);
        }
    }
}
