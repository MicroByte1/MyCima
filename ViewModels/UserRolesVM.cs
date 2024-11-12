


using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

public class UserRolesVM {

    public string UserName { get; set; }

    public string Role { get; set; }

    public List<SelectListItem> Roles { get; set; }

    public List<SelectListItem> Users { get; set; }

    public UserRolesVM()
    {
        
    }
    public UserRolesVM(List<IdentityRole> roles, List<AppUser> appUsers)
    {
        if (roles != null){
            Roles = new List<SelectListItem>(roles.Count);
            foreach(var item in roles){
                Roles.Add(new SelectListItem(item.Name, item.Name));
            }
        }

        if (appUsers != null){
            Users = new List<SelectListItem>(appUsers.Count);
            foreach (var item in appUsers){
                Users.Add(new SelectListItem(item.Name, item.UserName));
            }
        }
    }
}