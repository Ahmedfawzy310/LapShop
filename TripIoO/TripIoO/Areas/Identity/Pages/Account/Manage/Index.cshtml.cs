﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TripIoO.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IFillList _dropDown;
        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IFillList dropDown)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dropDown = dropDown;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [Display(Name = "First Name")]
            [MaxLength(20), MinLength(3)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            [MaxLength(20), MinLength(3)]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Age")]
            public float Age { get; set; }

            [Display(Name = "Country")]
            public int CountryId { get; set; }

            [Display(Name = "Gender")]
            public int GenderId { get; set; }

            public IEnumerable<SelectListItem> Countries { get; set; } = Enumerable.Empty<SelectListItem>();
            public IEnumerable<SelectListItem> Genders { get; set; } = Enumerable.Empty<SelectListItem>();


            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;
           
            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName=user.FirstName,
                LastName=user.LastName,
                Age=user.Age,
                CountryId=user.CountryId,
                GenderId=user.GenderId,
                Countries=_dropDown.Countries(),
                Genders=_dropDown.Genders()
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
           
            if (user == null)
            {
               
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            
            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var firstname=user.FirstName;
            var lastname=user.LastName;
            var age=user.Age;
            var countryId=user.CountryId;
            var genderId=user.GenderId;


            if (Input.FirstName != firstname)
            {
                user.FirstName = Input.FirstName;
                await _userManager.UpdateAsync(user);
            }

            if (Input.LastName != lastname)
            {
                user.LastName = Input.LastName;
                await _userManager.UpdateAsync(user);
            }

            if (Input.Age != age)
            {
                user.Age = Input.Age;
                await _userManager.UpdateAsync(user);
            }
            if (Input.CountryId != countryId)
            {
                user.CountryId = Input.CountryId;
                await _userManager.UpdateAsync(user);
            }
            if(Input.GenderId != genderId)
            {
                user.GenderId = Input.GenderId;
                await _userManager.UpdateAsync(user);
            }

            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
