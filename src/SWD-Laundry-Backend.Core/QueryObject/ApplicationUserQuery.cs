using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SWD_Laundry_Backend.Core.QueryObject;
public record ApplicationUserQuery : BaseQuery
{
    [BindProperty(Name = "email", SupportsGet = true)]
    public string? Email { get; init; }
}
