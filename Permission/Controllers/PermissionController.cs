using Microsoft.AspNetCore.Mvc;
namespace Permission.Controllers;

[ApiController]
[Route("[controller]")]
public class PermissionController : ControllerBase
{
    //private readonly ILogger<PermissionController> _logger ;

    

    [HttpPost("addpermission")]
    public bool AddPermission()
    {
        try
        {

            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }
}
