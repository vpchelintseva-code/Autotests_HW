using TestAQA1.DTO.BookStoreDTO;
using Pets;
using Refit;
using System;
using BookStore.DTO;
using Tests1.DTO.BookStoreDTO;

namespace TestAQA1.DTO.BookStoreDTO
{
    public interface IBookAPI
    {
        [Post("/Account/v1/User")]
        Task<UserCreateResponseDTO> CreateUserAsync([Body] UserCreateRequestDTO credentials);

        [Post("/Account/v1/GenerateToken")]
        Task<TokenUserResponseDTO> GenerateTokenAsync([Body] UserCreateRequestDTO credentials);

        [Post("/Account/v1/Login")]
        Task<LoginUserResponseDTO> GetUserIdAsync([Body] UserCreateRequestDTO credentials);

        [Get("/BookStore/v1/Books")]
        Task<BookListDTO> GetBookListAsync();

        [Get("/BookStore/v1/Book")]
        Task<UserCreateResponseDTO> GetBookByIsbnAsync([Query] string ISBN);

        [Post("/BookStore/v1/Books")]
        Task<UserCreateResponseDTO> AddBookToUserAsync([Body] AddCollectionOfBooksToUserDTO request,
            [Header("Authorization")] string token);

        [Delete("/BookStore/v1/Book")]
        Task<DeleteBookResponseDTO> DeleteBookFromUserAsync([Body] DeleteBookRequestDTO request, [Header("Authorization")] string token); 
        
        
    }
}