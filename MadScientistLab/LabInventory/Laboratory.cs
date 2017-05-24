using System;
using System.Collections.Generic;
using System.Linq;
using MadScientistLab.Cli;
using MadScientistLab.Enums;
using MadScientistLab.LabInventory.Animals;
using MadScientistLab.LabInventory.Animals.Interfaces;
using MadScientistLab.LabInventory.Machines;
using MadScientistLab.Configuration;
using System.Reflection;

namespace MadScientistLab.LabInventory
{
    public class Laboratory
    {
        private readonly List<Animal> _animals;
        private readonly ICommandInterface _cli;
        private readonly Barker _barker;
        private readonly Purrer _purrer;
        private readonly Squeaker _squeaker;

        public Laboratory(ICommandInterface cli)
        {
            _cli = cli;
            _animals = new List<Animal>();
            _barker = new Barker(_cli);
            _purrer = new Purrer(_cli);
            _squeaker = new Squeaker(_cli);
        }

        public void Create(AnimalTypeEnum animalType, string name)
        {
            switch (animalType)
            {
                case AnimalTypeEnum.Cat:
                    _animals.Add(new Cat(name));
                    break;
                case AnimalTypeEnum.Lion:
                    _animals.Add(new Lion(name));
                    break;
                case AnimalTypeEnum.Dog:
                    _animals.Add(new Dog(name));
                    break;
                case AnimalTypeEnum.Wolf:
                    _animals.Add(new Wolf(name));
                    break;
                case AnimalTypeEnum.Mouse:
                    _animals.Add(new Mouse(name));
                    break;
                case AnimalTypeEnum.Rat:
                    _animals.Add(new Rat(name));
                    break;
                case AnimalTypeEnum.Tiger:
                    _animals.Add(new Tiger(name));
                    break;
                case AnimalTypeEnum.Coyote:
                    _animals.Add(new Coyote(name));
                    break;
                case AnimalTypeEnum.Hamster:
                    _animals.Add(new Hamster(name));
                    break;
                default:
                    _cli.DisplayError($"No such type.");
                    break;
            }

            _cli.DisplayInfo($"Created {animalType} with name {name}.");
        }

        public bool DoesAnimalExist(string ani)
        {
            if (!ValidateExistenceOfAnimal(ani))
            {
                _cli.DisplayError($"{ani} doesn't exist. Use list to see all existing animals");
                return false;
            }
            else { return true; }
        }

        public void GoToSleep(string name)
        {
            if (!DoesAnimalExist(name))
            { return; }


            var animal = GetAnimalByName(name);
            animal.GoSleep();
            _cli.DisplayInfo($"{animal.Name} is well rested.");
        }

        public void GoEat(string name)
        {
            if (!DoesAnimalExist(name))
            { return; }

            Animal animal = GetAnimalByName(name);
            animal.Eat();
            _cli.DisplayInfo($"{animal.Name} is well fed.");
        }

        public void Barker(string name)
        {
            if (!DoesAnimalExist(name))
            { return; }

            Animal animal = GetAnimalByName(name);

            if (!IsAnimalReadyForMachine(animal))
            {
                _cli.DisplayError($"{name} can't do it right now.");
                return;
            }

            if (animal is IBarkable)
            {
                _barker.Execute(animal as IBarkable);
                animal.Fed = false;
                animal.Rested = false;
            }
            else
            {
                _cli.DisplayError($"{name} can't bark.");
            }
        }

        public void Purrer(string name)
        {
            if (!DoesAnimalExist(name))
            { return; }

            var animal = GetAnimalByName(name);

            if (!IsAnimalReadyForMachine(animal))
            {
                _cli.DisplayError($"{name} can't do it right now.");
                return;
            }

            if (animal is IPurrable)
            {
                _purrer.Execute(animal as IPurrable);
                animal.Fed = false;
                animal.Rested = false;
            }
            else
            {
                _cli.DisplayError($"{name} can't purr.");
            }
        }

        public void Squeaker(string name)
        {
            if (!DoesAnimalExist(name))
            { return; }

            var animal = GetAnimalByName(name);

            if (!IsAnimalReadyForMachine(animal))
            {
                _cli.DisplayError($"{name} can't do it right now.");
                return;
            }

            if (animal is ISqueakable)
            {
                _squeaker.Execute(animal as ISqueakable);
                animal.Fed = false;
                animal.Rested = false;
            }
            else
            {
                _cli.DisplayError($"{name} can't squeak.");
            }
        }

        public void ListAnimals()
        {
            if (_animals.Count() == 0)
            {
                _cli.DisplayInfo("There is no animal here!!!\r\nUse create to add an animal to the lab");
            }
            foreach (var animal in _animals)
            {
                _cli.DisplayInfo($"{animal.Type} - {animal.Name}");
            }
        }

        public void Delete(string animal)
        {
            if (!DoesAnimalExist(animal))
            { return; }

            _animals.RemoveAll(x => x.Name == animal);
            _cli.DisplayInfo($"{animal} removed from animal list");
        }

        private bool ValidateExistenceOfAnimal(string name)
        {
            return _animals.Any(animal => animal.Name.Equals(name));
        }

        private Animal GetAnimalByName(string name)
        {
            return _animals.SingleOrDefault(a => a.Name.Equals(name));
        }

        private bool IsAnimalReadyForMachine(Animal animal)
        {
            return animal.Fed && animal.Rested;
        }
    }
}
