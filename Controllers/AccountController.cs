


using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
[AllowAnonymous]
public class AccountController : Controller {
    private UserManager<AppUser> _usermanager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _usermanager = userManager;
        this._signInManager = signInManager;
    }
    public IActionResult Index(){
        return Content("REgister here");
    }
    [HttpGet]
    public IActionResult Register(){
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterUser user){
        var result = await _usermanager.FindByNameAsync(user.UserName);
        if (result == null){
            AppUser appUser = new AppUser{
                Name = user.Name,
                Email = user.Email,
                UserName = user.UserName,
                Img = "1.jpj"
            };
            var res = await _usermanager.CreateAsync(appUser,  user.Password);
            if (res.Succeeded){
                return Content("Accout Register Sucessfully");
            }
            else{
                ViewBag.msg = "Error At Saving this account";
                return View(user);
            }
            
        }
        return Content("Accout Already Exsist");
        
    }


    [HttpGet]
    public IActionResult Login(){
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(RegisterUser user){
        var result = await _usermanager.FindByNameAsync(user.UserName);
        if (result != null){
            var res = await _usermanager.CheckPasswordAsync(result, user.Password);
            if (res){

                await _signInManager.SignInAsync(result, false);
                return RedirectToAction("Index", "Movie");

            }
            return Content("UserName or password does not match");

        }
        return Content("There is no account  thislike");
    }

    public async Task<IActionResult> Logout(){
        //await HttpContext.SignOutAsync("cooki");

        await _signInManager.SignOutAsync();

        return RedirectToAction("Index", "Home");
    }
}