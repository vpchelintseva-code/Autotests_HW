using System;
using System.Collections.Generic;
using System.Text;

namespace TestAQA1.DTO.BookStoreDTO
{
    public record DeleteBookResponseDTO(
        string UserId,
        string Isbn,
        string Message
    );
}