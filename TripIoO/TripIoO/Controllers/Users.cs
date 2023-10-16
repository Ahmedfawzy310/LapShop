namespace TripIoO.Controllers
{
    [Authorize(Roles ="Admin")]
    public class Users : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;

        public Users(UserManager<ApplicationUser> usermanager, RoleManager<IdentityRole> rolemanager)
        {
            _usermanager = usermanager;
            _rolemanager = rolemanager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _usermanager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Age= user.Age,
               
                Roles = _usermanager.GetRolesAsync(user).Result

            }).ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> ManageRole(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            var roles = await _rolemanager.Roles.ToListAsync();

            var model = new UserRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel
                {
                    RoleName = role.Name,
                    IsSelected = _usermanager.IsInRoleAsync(user, role.Name).Result
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRole(UserRolesViewModel model)
        {
            var user = await _usermanager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();

            var UserRoles = await _usermanager.GetRolesAsync(user);

            foreach (var role in model.Roles)
            {
                if (UserRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                    await _usermanager.RemoveFromRoleAsync(user, role.RoleName);

                if (!UserRoles.Any(r => r == role.RoleName) && role.IsSelected)
                    await _usermanager.AddToRoleAsync(user, role.RoleName);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
