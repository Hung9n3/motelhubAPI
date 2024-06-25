using System;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotelHubApi.WebApi;

[ApiController]
[ApiVersion("1.0")]
[Route("api/[controller]")]
//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public abstract class ApiControllerBase<T, Logic> : ControllerBase
    where T : IEntity
    where Logic : IBaseLogic<T>
{

    protected Logic _logic;

    public ApiControllerBase(Logic logic)
    {
        this._logic = logic;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await this._logic.GetAllAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var result = await this._logic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    [HttpDelete()]
    public async Task<IActionResult> GetById([FromBody] T entity)
    {
        try
        {
            await this._logic.DeleteAsync(entity);
            return Ok();
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    [HttpPost()]
    public async Task<IActionResult> Save([FromBody] T entity)
    {
        try
        {
            await this._logic.SaveAsync(entity);
            return Ok(entity.Id);
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    protected int GetUserId()
    {
        var userId = User.Claims.First(c => c.Type == "UserId").Value;
        int.TryParse(userId, out var result);
        return result;
    }
}

