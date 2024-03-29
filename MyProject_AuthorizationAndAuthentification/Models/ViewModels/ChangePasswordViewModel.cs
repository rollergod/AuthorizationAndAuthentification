﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject_AuthorizationAndAuthentification.Models.ViewModels
{
    /// <summary>
    /// Класс содержащий поля для страницы изменения пароля
    /// </summary>
    public class ChangePasswordViewModel
    {
        public int Id { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
}
