using Microsoft.AspNetCore.Mvc;
using Public.DTO;

namespace WebApp.Helpers;

public static class ResponseHelpers
{
    public static BadRequestObjectResult Error(string message)
    {
        return new BadRequestObjectResult(new ErrorDTO()
        {
            ErrorMessage = message
        });
    }

    public static OkObjectResult Success(string message)
    {
        return new OkObjectResult(new SuccessDTO()
        {
            SuccessMessage = message
        });
    }

    public static OkObjectResult Created(Guid id)
    {
        return new OkObjectResult(new CreatedDTO()
        {
            Id = id
        });
    }
}
