using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Data;
using Models;

namespace ProductController;

[ApiController]
[Route("[controller]")]//this mean the route will be /Products
public class ProductController : ControllerBase
{
    private readonly AppdbContext _dbContext;

    public ProductController(AppdbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: /Product
    [HttpGet]
    //async: don't block the server waiting for the result
    //Task: a promise to return a result
    //ActionResult: a wrapper for the result
    //IEnumerable: a list of items.interface of enumerable means you can iterate over it
    //Product: the type of item in the list
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        //return a list of products from the database
        return await _dbContext.Products.ToListAsync();
        //await means don't block the server waiting for the result
        //this task will take time so return a promise to return a result
    }

    // GET: /Product/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);

        if (product == null)
        {
            return NotFound();
        }
        return product;
    }

    // POST: /Product
    [HttpPost]
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
        //add the product to the dbcontext"in memory"  
        _dbContext.Products.Add(product);//id will be auto generated
        //save the changes to the database
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id} , product);
        //CreatedAtAction Method: create a 201 Created response with a location header pointing to another action method
        // that can be used to retrieve the newly created resource.
        //new { id = product.Id } Parameter:
        //anonymous object used to pass route values to the GetProduct action method
        //The last parameter is the actual data
        //that will be included in the response body.
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Product>> PutProduct(int id, Product product)
    {
        if(id != product.Id)
            return BadRequest();//error code 400
        
        _dbContext.Entry(product).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch(DbUpdateConcurrencyException)
        {
            if(!_dbContext.Products.Any(e => e.Id == id))
                return NotFound();//error code 404
            else
                throw;
        }

        return NoContent();
    }

}