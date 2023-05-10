using PinkPanther.Models;

namespace PinkPanther
{
    public static class TestDatabaseTODELETE
    {
        public static List<AnimalViewModel> ANIMALS = new()
        {
            new AnimalViewModel()
            {
                Index = 0,
                Name = "Pola",
                Type = "Dog",
                Race = "Mongrel",
                Sex = false,
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-3)),
                IsAdopted = true
            },
            new AnimalViewModel()
            {
                Index = 1,
                Name = "Burek",
                Type = "Dog",
                Race = "Akita",
                Sex = true,
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-8)),
                IsAdopted = false
            },
            new AnimalViewModel()
            {
                Index = 2,
                Name = "Jazz",
                Type = "Dog",
                Race = "Mongrel",
                Sex = true,
                BirthDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-3)),
                IsAdopted = false
            },
            new AnimalViewModel()
            {
                Index = 3,
                Name = "Funny",
                Type = "Cat",
                Race = "Bengal cat",
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
