using AtmoreChamber.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AtmoreChamber.Startup))]
namespace AtmoreChamber
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }


            if (UserManager.Find("SuperUser@email.com", "!QAZxsw2#EDC") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "SuperUser@email.com";
                user.Email = "SuperUser@email.com";
                string userPWD = "!QAZxsw2#EDC";

                var chkUser = UserManager.Create(user, userPWD);

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }


            if (!roleManager.RoleExists("ChamberMember"))
            {
                var role = new IdentityRole();
                role.Name = "ChamberMember";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Visitor"))
            {
                var role = new IdentityRole();
                role.Name = "Visitor";
                roleManager.Create(role);
            }

        }
    }
}
