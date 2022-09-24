using Feed.Business.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Feed.Api.Controllers
{
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(INotifier notifier,
                              SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager
                              ) : base(notifier)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
    }
}
