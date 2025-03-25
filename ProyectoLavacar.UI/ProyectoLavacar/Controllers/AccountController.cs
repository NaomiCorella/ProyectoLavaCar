using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProyectoLavacar.Abstraciones.LN.interfaces.General.Fecha;
using ProyectoLavacar.Abstraciones.LN.interfaces.ModuloCorreos;
using ProyectoLavacar.AccesoADatos;
using ProyectoLavacar.LN.General.Fecha;
using ProyectoLavacar.LN.ModuloCorreos;
using ProyectoLavacar.Models;

namespace ProyectoLavacar.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly UserManager<ApplicationUser> _userM;
         private readonly IEmailSender _emailSender;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IEmailSender emailSender)
        {
        
            UserManager = userManager;
            SignInManager = signInManager;
            _emailSender = emailSender;


        }


        // Método para cambiar la contraseña
        [HttpGet]
        public ActionResult changePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> changePassword(changePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Obtener el ID del usuario autenticado
                var claimsIdentity = User.Identity as ClaimsIdentity;
                string userId = claimsIdentity?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userId == null)
                {
                    return View("Error"); // Si no hay un usuario autenticado, retornamos un error
                }

                // Buscar al usuario por su ID
                var user = await _userM.FindByIdAsync(userId);
                if (user == null)
                {
                    return View("Error"); // Si el usuario no se encuentra, retornamos un error
                }

                // Verificar si la contraseña actual es correcta
                var result = await _userM.ChangePasswordAsync(userId, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    return RedirectToAction("changePasswordSuccess"); // Redirigir a la vista de éxito
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error); // Mostrar errores de cambio de contraseña
                    }
                }
            }

            return View(model);
        }

        // Vista de éxito (si se cambia la contraseña correctamente)
        public ActionResult changePasswordSuccess()
        {
            return View();

        }
    


    public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set 
            { 
                _signInManager = value; 
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // No cuenta los errores de inicio de sesión para el bloqueo de la cuenta
            // Para permitir que los errores de contraseña desencadenen el bloqueo de la cuenta, cambie a shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Intento de inicio de sesión no válido.");
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Requerir que el usuario haya iniciado sesión con nombre de usuario y contraseña o inicio de sesión externo
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // El código siguiente protege de los ataques por fuerza bruta a los códigos de dos factores. 
            // Si un usuario introduce códigos incorrectos durante un intervalo especificado de tiempo, la cuenta del usuario 
            // se bloqueará durante un período de tiempo especificado. 
            // Puede configurar el bloqueo de la cuenta en IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent:  model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Código no válido.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    nombre = model.Nombre,
                    primer_apellido = model.PrimerApellido,
                    segundo_apellido = model.SegundoApellido,
                    estado = true,
                    ingreso = _fecha.ObtenerFecha()

                };

                var result = await UserManager.CreateAsync(user, model.Password);
                var Asunto = "¡Tu cuenta está lista! Disfruta nuestros servicios en el Lavacar Hervi";

                if (result.Succeeded)
                {
                    // Asignar el rol al usuario
                    var resultRole = await UserManager.AddToRoleAsync(user.Id, "Usuario");

                    if (resultRole.Succeeded)
                    {
                        string cuerpoDelCorreo = ObtenerPlantillaCorreo();
                        string correoConvertido = string.Format(cuerpoDelCorreo, model.Nombre, model.PrimerApellido);
                        await _emailSender.SendEmailAsync(user.Email, Asunto, correoConvertido).ConfigureAwait(false);
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToAction("Index", "Home");
                    }

                    // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite https://go.microsoft.com/fwlink/?LinkID=320771
                    // Enviar un correo electrónico con este vínculo
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirmar la cuenta", "Para confirmar su cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
        }



        #region metodoPlantilla
        private string ObtenerPlantillaCorreoEmpleado()
        {
            string filePath = Server.MapPath("~/Content/PlantillasDeCorreos/PlantillaDeCorreoBienvenidaEmpleados.html");

            string htmlContent = System.IO.File.ReadAllText(filePath);
            return htmlContent;
        }
        private string ObtenerPlantillaCorreo()
        {
            string filePath = Server.MapPath("~/Content/PlantillasDeCorreos/PlantillaDeCorreoBienvenida.html");

            string htmlContent = System.IO.File.ReadAllText(filePath);
            return htmlContent;
        }

        #endregion



        // POST: /Account/Register
        [AllowAnonymous]
        public ActionResult RegisterEmployee()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterEmployee(RegisterEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    nombre = model.Nombre,
                    primer_apellido = model.PrimerApellido,
                    segundo_apellido = model.SegundoApellido,
                    estado = model.Estado,
                    cedula = model.cedula,
                    numeroCuenta = model.numeroCuenta,
                    turno = model.turno,
                    puesto = model.puesto
                };

                var result = await UserManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    // Asignar el rol al usuario
                    var resultRole = await UserManager.AddToRoleAsync(user.Id, "Empleado");
                    var nombreCompleto = model.Nombre + " " + model.PrimerApellido;
                    var Asunto = "🎉¡Tu cuenta está lista! Disfruta nuestros servicios en el Lavacar Hervi 🎉";
                    if (resultRole.Succeeded)
                    {
                        string cuerpoDelCorreo = ObtenerPlantillaCorreoEmpleado();
                        string correoConvertido = string.Format(cuerpoDelCorreo, nombreCompleto, model.Password, model.Email);
                        await _emailSender.SendEmailAsync(user.Email, Asunto, correoConvertido).ConfigureAwait(false);
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                AddErrors(result);
            }

            return View(model);
        }
        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            // Comprobamos que el modelo no es nulo
            if (model == null)
            {
                ModelState.AddModelError("", "El modelo no puede ser nulo.");
                return View(model);
            }

            // Validamos que el Email está presente
            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "El correo electrónico es obligatorio.");
                return View(model); // Devuelve la vista con los errores
            }

            if (!ModelState.IsValid)
            {
                return View(model); // Si el modelo no es válido
            }

            try
            {
                // Generar un código único
                var resetCode = Guid.NewGuid().ToString();

                // Construir el enlace de restablecimiento
                var callbackUrl = Url.Action("ResetPassword", "Account", new { token = resetCode, email = model.Email }, protocol: Request.Url.Scheme);

                // Configurar asunto y mensaje
                var asunto = "Restablecer tu contraseña";

                var correoConvertido = $"Hola " + model.Email + ".\n" +
                    "Para restablecer tu contraseña, por favor haz clic en el siguiente enlace\n" +
                    $"✔️ <a href=\"{callbackUrl}\">Restablecer contraseña</a>\n" +
                    "Si no solicitaste este cambio, por favor ignora este mensaje.\n" +
                    "Atentamente, El equipo de soporte de Lavacar Hervi";

                await GuardarCodigoEnBaseDeDatos(model.Email, resetCode);

                // Enviar el correo con el método especificado
                await _emailSender.SendEmailAsync(model.Email, asunto, correoConvertido).ConfigureAwait(false);

                // Redirigir a ForgotPasswordConfirmation
                return RedirectToAction("ForgotPasswordConfirmation");
            }
            catch (Exception ex)
            {
                // Registrar el error en los logs para depuración
                System.Diagnostics.Debug.WriteLine($"Error enviando el correo: {ex.Message}");
                ModelState.AddModelError("", "Ocurrió un problema enviando el correo. Por favor, inténtalo más tarde.");
                return View(model); // Regresar a la vista con el error
            }
        }


        private async Task GuardarCodigoEnBaseDeDatos(string email, string token)
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Contexto"].ConnectionString))
            {
                await connection.OpenAsync();

                var query = "UPDATE AspNetUsers SET CodigoRecuperacion = @CodigoRecuperacion, FechaGeneracionCodigo = @FechaGeneracion, FechaExpiracionCodigo = @FechaExpiracion WHERE Email = @Email";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodigoRecuperacion", token);
                    command.Parameters.AddWithValue("@FechaGeneracion", DateTime.Now);
                    command.Parameters.AddWithValue("@FechaExpiracion", DateTime.Now.AddMinutes(5)); // Expira en 5 minutos
                    command.Parameters.AddWithValue("@Email", email);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ResetPassword(string token)
        {
            return View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("", "El correo es obligatorios.");
                return View(model);
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                // Obtener el usuario asociado al correo electrónico
                var user = await _userM.FindByEmailAsync(model.Email);

                if (string.IsNullOrEmpty(user.Id))
                {
                    ModelState.AddModelError("", "Usuario no encontrado.");
                    return View(model);
                }

                ApplicationDbContext context = new ApplicationDbContext();
                UserStore<ApplicationUser> store = new UserStore<ApplicationUser>(context);
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(store);
                String hashedNewPassword = UserManager.PasswordHasher.HashPassword(model.Password);
                ApplicationUser cUser = await store.FindByIdAsync(user.Id);
                await store.SetPasswordHashAsync(cUser, hashedNewPassword);
                await store.UpdateAsync(cUser);


                // Redirigir a la página de confirmación
                return RedirectToAction("ResetPasswordConfirmation");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message}");
                return View(model);
            }
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Solicitar redireccionamiento al proveedor de inicio de sesión externo
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generar el token y enviarlo
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Si el usuario ya tiene un inicio de sesión, iniciar sesión del usuario con este proveedor de inicio de sesión externo
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // Si el usuario no tiene ninguna cuenta, solicitar que cree una
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Obtener datos del usuario del proveedor de inicio de sesión externo
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Aplicaciones auxiliares
        // Se usa para la protección XSRF al agregar inicios de sesión externos
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}