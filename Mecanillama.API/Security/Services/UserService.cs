using AutoMapper;
using Mecanillama.API.Security.Authorization.Handlers.Interfaces;
using Mecanillama.API.Security.Domain.Models;
using Mecanillama.API.Security.Domain.Repositories;
using Mecanillama.API.Security.Domain.Services;
using Mecanillama.API.Security.Domain.Services.Communication;
using Mecanillama.API.Security.Exceptions;
using Mecanillama.API.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Mecanillama.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IJwtHandler _jwtHandler;


    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, IJwtHandler jwtHandler)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _userRepository.FindByEmailAsync(request.Email);
        Console.WriteLine($"Request: {request.Email}, {request.Password}");
        Console.WriteLine($"User: {user.Id}, {user.Email}, {user.PasswordHash}");
        
        // Perform validation
        if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Email or password is incorrect");
        }
        
        Console.WriteLine("Authentication successful. About to generate token");
        
        // Authentication is successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        
        // Token is generated
        Console.WriteLine($"Response: {response.Id}, {response.Email}");
        response.Token = _jwtHandler.GenerateToken(user);
        
        Console.WriteLine($"Generated token is {response.Token}");
        return response;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(long id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        // Validate

        if (_userRepository.ExistsByEmail(request.Email))
            throw new AppException($"Email '{request.Email}' is already taken");
        
        // Map request to user entity
        var user = _mapper.Map<User>(request);
        
        // Hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        // Save User
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while saving the user: {e.Message}");
        }
    }

    public async Task UpdateAsync(long id, UpdateRequest request)
    {
        var user = GetById(id);
        
        // Validate
        var userWithEmail = await _userRepository.FindByEmailAsync(request.Email);

        if (userWithEmail != null && userWithEmail.Id != user.Id)
            throw new AppException($"Email '{request.Email}' is already taken");
        
        // Hash Password if it was entered
        if (!string.IsNullOrEmpty(request.Password))
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
        
        // Map request to entity
        _mapper.Map(request, user);
        
        // Save User
        try
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while updating the user: {e.Message}");
        }
    }

    public async Task DeleteAsync(long id)
    {
        var user = GetById(id);

        try
        {
            _userRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error occurred while deleting the user: {e.Message}");
        }
    }
    
    // Helper Functions

    private User GetById(long id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}