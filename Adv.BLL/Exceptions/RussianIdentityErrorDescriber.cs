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
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code = nameof(PasswordRequiresLower),
                Description = $"Добавьте в пароль символ 'a'-'z'"
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = nameof(PasswordTooShort),
                Description = $"Минимальная длина пароля '{length}'."
            };
        }
    }
}
