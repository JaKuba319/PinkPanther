using PinkPanther.Models;
using System.ComponentModel;

namespace PinkPanther
{
    public static class TestDatabaseTODELETE
    {
        public static List<TypeViewModel> TYPES = new()
        {
            new TypeViewModel()
            {
                Index = 0,
                Type = "Dog"
            },
            new TypeViewModel()
            {
                Index = 1,
                Type = "Cat"
            }
        };
        public static List<RaceViewModel> RACES = new()
        {
            new RaceViewModel()
            {
                Index = 0,
                Race = "Mongrel"
            },
            new RaceViewModel()
            {
                Index = 1,
                Race = "Akita"
            },
            new RaceViewModel()
            {
                Index = 2,
                Race = "Bengal cat"
            }
        };

        public static List<AnimalViewModel> ANIMALS = new()
        {
            new AnimalViewModel()
            {
                Index = 0,
                Name = "Pola",
                Type = TYPES[0].Type,
                Race = RACES[0].Race,
                Sex = false,
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-3)),
                IsAdopted = true
            },
            new AnimalViewModel()
            {
                Index = 1,
                Name = "Burek",
                Type = "Dog",
                Race = RACES[1].Race,
                Sex = true,
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-8)),
                IsAdopted = false
            },
            new AnimalViewModel()
            {
                Index = 2,
                Name = "Jazz",
                Type = TYPES[0].Type,
                Race = RACES[0].Race,
                Sex = true,
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-3)),
                IsAdopted = false
            },
            new AnimalViewModel()
            {
                Index = 3,
                Name = "Funny",
                Type = TYPES[1].Type,
                Race = RACES[2].Race,
                Sex = false,
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-6)),
                IsAdopted = false
            }
        };

        public static List<ClientViewModel> CLIENTS = new()
        {
            new ClientViewModel()
            {
                Index = 0,
                Name = "Jan",
                LastName = "Kowalski",
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-20)),
                PhoneNumber = "123 456 787",
                Sex = true,
                Animals = ANIMALS.Where(animal => animal.IsAdopted).ToList()
            },
            new ClientViewModel()
            {
                Index = 1,
                Name = "Kuba",
                LastName = "Piotrkowski",
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-19)),
                PhoneNumber = "122 456 787",
                Sex = true,
                Animals = null
            }
        };
    }
}
