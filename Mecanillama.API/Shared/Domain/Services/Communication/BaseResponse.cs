namespace Mecanillama.API.Shared.Domain.Services.Communication;

public abstract class BaseResponse<T> {
    protected BaseResponse(T resource) {
        Success = true;
        Resource = resource;
        Message = string.Empty;
    }

    protected BaseResponse(string message) {
        Success = false;
        Resource = default;
        Message = message;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public T Resource { get; set; }
}