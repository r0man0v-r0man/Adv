using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adv.BLL.Exceptions
{
    public class RussianIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName) 
        { 
            return new IdentityError 
            { 
                Code = nameof(DuplicateUserName), Description = $"Пользователь с именем '{userName}' уже существует."
            }; 
        }
    }
}
