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
                IsAdopted = false
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
    }
}
