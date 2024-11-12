


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
[Authorize(Roles ="Admin") ]
public class RoleController : Controller {
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly AppContext _context;
    private readonly UserManager<AppUser> userManager;

    public RoleController(RoleManager<IdentityRole> roleManager, AppContext appContext, UserManager<AppUser> userManager)
    {
        this.roleManager = roleManager;
        this._context = appContext;
        this.userManager = userManager;
    }

    public IActionResult Index(){
        return View();
    }

    public IActionResult AddRole(){
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddRole(string name){
        await roleManager.CreateAsync(new IdentityRole{Name = name});
        return Content(name);
    }


    public IActionResult AssignRole(){
        var roles = _context.Roles.ToList();
        var users = _context.Users.ToList();
        var model = new UserRolesVM(roles, users);
        return View(model);
    }
    [HttpPost]
    public async Task<IActionResult> AssignRole(UserRolesVM vm){
        var user = await userManager.FindByNameAsync(vm.UserName);
        if (user != null){
            var flag = await userManager.AddToRoleAsync(user, vm.Role);
            if (flag == null){
                return Content("Error while adding to role");
            }
            return Content("Role Added Sucessfulld to user ");
        }
        return Content("Coud not found username");
    }


}