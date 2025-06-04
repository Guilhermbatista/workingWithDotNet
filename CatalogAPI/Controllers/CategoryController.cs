using CatalogAPI.Context;
using CatalogAPI.Filters;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{

    private readonly AppDbContext _context;
    private readonly ILogger _logger;

    public CategoryController(AppDbContext context, ILogger<CategoryController> logger)
    {
        _context = context;
        _logger = logger;
    }

    //Todas as vezes que acessa um banco de dados, uma operação complexa, algo que demanda mais tempo pode se usar Async
    [HttpGet]
    [ServiceFilter(typeof(ApiLoggingFilters))]
    public async Task<ActionResult<IEnumerable<Category>>> FindAll()
    {
        var  category = _context.Categories.AsNoTracking().ToList();

        if(category is null)
        {
            return NotFound("Categories does not found");
        }
        return await _context.Categories.ToListAsync();
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterCategoria")]
    public async Task<ActionResult<Category>> GetProductId(int id)
    {

        _logger.LogInformation(message: "=================GET /Category/id =====================");

        var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(p => p.CategoryId == id);

        if (category is null)
        {
            _logger.LogInformation(message: "=================GET /Category/id  NOT FOUND =====================");

            return NotFound();
        }
        return category;
    }

    [HttpPost]
    public ActionResult Insert(Category category)
    {
        if (category is null)
            return BadRequest();

        _context.Categories.Add(category);
        _context.SaveChanges();

        return new CreatedAtRouteResult("ObterCategoria", new { id = category.CategoryId }, category);

    }
    [HttpPut("{id:int}")]
    public ActionResult Update(int id, Category category)
    {
        if(id != category.CategoryId)
            return BadRequest();

        _context.Entry(category).State = EntityState.Modified;
        _context.SaveChanges();

        return Ok(category);
    }
    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

        if (category is null)
        {
            return NotFound("Category does not found");
        }
        _context.Categories.Remove(category);
        _context.SaveChanges();

        return NoContent();

    }

}
