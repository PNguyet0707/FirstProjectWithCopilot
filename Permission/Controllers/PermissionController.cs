using MemeWorld.Data;
using MemeWorld.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace MemeWorld.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly PermissionContext _permissionContext;
    public PermissionController(PermissionContext context)
    {
        _permissionContext = context;
    }

    [HttpGet("getpermissionbyId/{id}")]
    public async Task<IActionResult>GetPermissionById(Guid id)
    {
        var permission = await _permissionContext.Permissions.FindAsync(id);
        if (permission == null)
        {
            return NotFound();
        }
        return Ok(permission);   
    }

    [HttpGet("getallpermissions")]
    public async Task<IActionResult> GetAllPermissions()
    {
        var permission = await _permissionContext.Permissions.Where(p => p.Category == (p.Category & PermissionCategory.Cat)).ToListAsync();
        if (permission == null)
        {
            return NotFound();
        }
        return Ok(permission);
    }

    [HttpPost("addpermission")]
    public async Task<ActionResult>AddPermission(Permission request)
    {
       _permissionContext.Permissions.Add(request);
        await _permissionContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("deletepermission/{id}")]
    public async Task<ActionResult> DeletePermission(Guid id)
    {
        var permission =  await _permissionContext.Permissions.FindAsync(id);
        if (permission == null)
            return NotFound();
         _permissionContext.Permissions.Remove(permission);
        await _permissionContext.SaveChangesAsync();
        return Ok();
    }
}
