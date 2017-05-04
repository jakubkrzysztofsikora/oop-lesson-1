using System;
using MadScientistLab.Configuration;
using MadScientistLab.Enums;

namespace MadScientistLab.Cli
{
    public class CommandParser
    {
        public AnimalTypeEnum GetAnimalTypeFromParameter(string type)
        {
            switch (type)
            {
                case CommonConstants.CatTypeName:
                    return AnimalTypeEnum.Cat;
                case CommonConstants.LionTypeName:
                    return AnimalTypeEnum.Lion;
                case CommonConstants.DogTypeName:
                    return AnimalTypeEnum.Dog;
                case CommonConstants.WolfTypeName:
                    return AnimalTypeEnum.Wolf;
                case CommonConstants.MouseTypeName:
                    return AnimalTypeEnum.Mouse;
                case CommonConstants.RatTypeName:
                    return AnimalTypeEnum.Rat;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
