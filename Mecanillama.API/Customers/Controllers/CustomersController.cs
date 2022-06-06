using AutoMapper;
using Mecanillama.API.Customers.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Mecanillama.API.Customers.Domain.Services;
using Mecanillama.API.Customers.Resources;


namespace Mecanillama.API.Customers.Controllers;


[Route("/api/v1/[controller]")] 
public class CustomersController : ControllerBase {
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomersController(ICustomerService customerService, IMapper mapper) {
        _customerService = customerService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<CustomerResource>> GetAllSync() {
        var customers = await _customerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
        
        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
    {
        //if (!ModelState.IsValid)
            //return BadRequest(ModelState.GetErrorMessages());

        var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);

        var result = await _customerService.SaveAsync(customer);

        if (!result.Success)
            return BadRequest(result.Message);

        var categoryResource = _mapper.Map<Customer, CustomerResource>(result.Resource);

        return Ok(categoryResource);
    }
    
    
    
}