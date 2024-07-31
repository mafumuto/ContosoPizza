using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{


    public PizzaController()
    {
        
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetALL() => PizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id)
    {
        Pizza? pizza = PizzaService.Get(id);
        if (pizza == null)
        {
            return NotFound();
        }
        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {            
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    
    [HttpPost("random")]
    public IActionResult CreateRandom()
    {            
        // This code will save the pizza and return a result
         PizzaService.AddRandom();

        return Accepted();
       

    }

    [HttpPost("{pizza}")]
    public IActionResult Create(PizzaService.PizzaType pizza)
    {            
        // This code will save the pizza and return a result
        if(!Enum.IsDefined(typeof(PizzaService.PizzaType), pizza))
        {
            return BadRequest();
        }

        PizzaService.Add(pizza);
        System.Console.WriteLine(pizza);
        return Accepted();
       

    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();
            
        var existingPizza = PizzaService.Get(id);
        if(existingPizza is null)
            return NotFound();
    
        PizzaService.Update(pizza);           
    
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);
    
        if (pizza is null)
            return NotFound();
        
        PizzaService.Delete(id);
    
        return NoContent();
    }
}