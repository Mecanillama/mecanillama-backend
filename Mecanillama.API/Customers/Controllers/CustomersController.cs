using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace Mecanillama.API.Customers.Controllers;


[Route("/api/v1/[controller]")] 
public class CustomersController : ControllerBase
{
    //private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

}