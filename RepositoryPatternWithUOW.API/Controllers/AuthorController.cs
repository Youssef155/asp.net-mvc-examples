using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Models;
using RepositoryPatternWithUOW.Core.Repositories;

namespace RepositoryPatternWithUOW.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IUnitOfWork UOW;

    public AuthorController(IUnitOfWork UOW)
    {
        this.UOW = UOW;
    }

    [HttpGet]
    public IActionResult GetById()
    {
        return Ok(UOW.Authors.GetById(1));
    }

    [HttpGet("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync()
    {
        return Ok(await UOW.Authors.GetByIdAsync(1));
    }
}
