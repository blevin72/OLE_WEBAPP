using System;
using Microsoft.AspNetCore.Identity;
using OLE_WEBAPP.Models;

namespace OLE_WEBAPP.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterAsync(RegisterViewModel model);
        Task<List<Account>> GetAccountsAsync();
    }
}