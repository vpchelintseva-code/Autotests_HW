using System;
namespace BookStore.DTO
{
    public record UserCreateRequestDTO(
        string UserName,
        string Password
    );
}