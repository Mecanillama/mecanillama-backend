using AutoMapper;
using Mecanillama.API.Customers.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Mecanillama.API.Customers.Domain.Services;
using Mecanillama.API.Customers.Resources;
using Mecanillama.API.Shared.Extensions;
using Swashbuckle.AspNetCore.Annotations;

namespace Mecanillama.API.Customers.Controllers;

[Route("/api/v1/[controller]")] 
[SwaggerTag("Create, read, update and delete Customers")]
public class CustomersController : ControllerBase {
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomersController(ICustomerService customerService, IMapper mapper) {
        _customerService = customerService;
        _mapper = mapper;
    }
    
    [SwaggerOperation(
        Summary = "Get all Customers",
        Description = "Get Method for all Customers",
        OperationId = "GetAllCustomers")]
    [SwaggerResponse(200, "All Customers returned", typeof(IEnumerable<CustomerResource>))]
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CustomerResource>), 200)]
    public async Task<IEnumerable<CustomerResource>> GetAllSync() {
        var customers = await _customerService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
        
        return resources;
    }
    
    [SwaggerOperation(
        Summary = "Save Customers",
        Description = "Save Customers",
        OperationId = "SaveCustomer")]
    [SwaggerResponse(201, "Customer saved", typeof(CustomerResource))]
    
    [HttpPost]
    [ProducesResponseType(typeof(CustomerResource), 201)]
    [ProducesResponseType(typeof(List<string>), 400)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> PostAsync([FromBody] SaveCustomerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);

        var result = await _customerService.SaveAsync(customer);

        if (!result.Success)
            return BadRequest(result.Message);

        var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);

        return Ok(customerResource);
    }
    
    [SwaggerOperation(
        Summary = "Update Customer",
        Description = "Update Customer",
        OperationId = "UpdateCustomer")]
    [SwaggerResponse(200, "Customer updated", typeof(CustomerResource))]
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CustomerResource), 200)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCustomerResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var customer = _mapper.Map<SaveCustomerResource, Customer>(resource);

        var result = await _customerService.UpdateAsync(id, customer);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);

        return Ok(customerResource);
    }
    
    [SwaggerOperation(
        Summary = "Delete Customer",
        Description = "Delete Customer",
        OperationId = "DeleteCustomer")]
    [SwaggerResponse(200, "Customer deleted", typeof(CustomerResource))]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _customerService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var customerResource = _mapper.Map<Customer, CustomerResource>(result.Resource);

        return Ok(customerResource);
    }
}