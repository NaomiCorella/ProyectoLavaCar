using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProyectoLavacar.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }



    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Código")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "¿Recordar este explorador?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "¿Recordar cuenta?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }



        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }

        [Required]
        [MaxLength(256)]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }
        [Required]
        [Range(100000000, 999999999, ErrorMessage = "La cédula debe tener exactamente 9 dígitos.")]

        [Display(Name = "Cédula")]
        public int cedula { get; set; }
        [Display(Name = "Rol")]
        public string Role { get; set; }

    }
    public class RegisterEmployeeViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(100000000, 999999999, ErrorMessage = "La cédula debe tener exactamente 9 dígitos.")]
        [Display(Name = "Cédula")]
        public int cedula { get; set; }





        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }

        [Required]
        [MaxLength(256)]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public bool Estado { get; set; }

       
        public string numeroCuenta { get; set; }
        public string turno { get; set; }
        public string puesto { get; set; }
        [Required]
        [Display(Name = "Rol")]
        public string Role { get; set; }
        public DateTime ingreso { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "La contraseña debe contener al menos una letra mayúscula, un número, un carácter especial y tener al menos 8 caracteres.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
        public string token { get; set; }
    }


    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }


    public class changePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nueva contraseña")]
        [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
