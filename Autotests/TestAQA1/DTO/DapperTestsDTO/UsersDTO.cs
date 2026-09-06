using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Autotests.TestAQA1.DTO.DapperTestsDTO
{
    public record UsersDTO
    (
        long Id,

        string FirstName,

        string LastName,

        string Email,

        string Phone,

        string CreatedAt
    );
}
