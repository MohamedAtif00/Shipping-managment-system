namespace Shipping_managment_system.Application.DTO.Authentication.AllowAccess.Response
{
    public record AllowAccessResponse(string userId, string username, string role, string emai, string token);
}
