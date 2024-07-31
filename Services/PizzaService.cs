using ContosoPizza.Models;

namespace ContosoPizza.Services;

public static class PizzaService
{
    private static readonly string[] Summaries = new[]
    {
        "Classic Italian", "SeaFood", "Margherita", "Mexician", "Pepperoni", "Hawaiian", "Chicago", "Detroit", "Neapolitan", "Al Taglio"
    };

    public enum PizzaType
    {
        Classic,
        SeaFood, 
        Margherita, 
        Mexician,
        Pepperoni, 
        Hawaiian, 
        Chicago, 
        Detroit, 
        Neapolitan, 
        AlTaglio
    }

    static Array pizzaTypeArray;
    static List<Pizza> Pizzas{ get; }
    static int nextId = 3;
    static PizzaService()
    {
        pizzaTypeArray = Enum.GetValues(typeof(PizzaType));
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }                
        };

    }

    public static List<Pizza> GetAll() => Pizzas;
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if(index == -1)
            return;

        Pizzas[index] = pizza;
    }

    public static void Add(PizzaType pizzaType)
    {

        Pizza? pizza = new Pizza { Id = 1, Name = pizzaType.ToString(), IsGlutenFree = false };

        Add(pizza);
    }

    public static void AddRandom()
    {
        int index = Random.Shared.Next(0,pizzaTypeArray.Length);
        Pizza? pizza = new Pizza { 
            Id = 1, 
            Name = pizzaTypeArray.GetValue(index)?.ToString(), 
            IsGlutenFree = false 
        };
        System.Console.WriteLine("Random pizza: " + pizza.Name);
        Add(pizza);
    }
}
