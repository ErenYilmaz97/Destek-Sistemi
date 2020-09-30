using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspCoreSupportSystem.CustomTagHelper
{
    [HtmlTargetElement("profile-link")]  //HTML ETİKET İSMİ
    public class ProfileLinkTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public ProfileLinkTagHelper(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            string html = string.Empty;

            html += $"<a class='dropdown-item' href='/Account/Profile?UserID={user.Id}'><h5>{user.Name} {user.Lastname}</h5></a>";
            output.Content.SetHtmlContent(html);
            base.ProcessAsync(context,output);
        }
    }
}
