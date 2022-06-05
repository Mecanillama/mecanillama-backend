using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mecanillama.API.Customers.Domain.Services;


namespace Mecanillama.API.Customers.Controllers;


[Route("/api/v1/[controller]")] 
public class CustomersController : ControllerBase {
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomersController(ICustomerService customerService, IMapper mapper) {
        _customerService = customerService;
        _mapper = mapper;
    }

    
    

}