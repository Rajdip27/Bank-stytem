using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Core.Entities.Auth;
[Table("UserRoles")]
public class UserRole :IdentityUserRole<string>
{
}
