using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CitasMedicas.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CitasMedicas.Controllers
{
    [ApiController]
    [Route("cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public CuentasController(UserManager<IdentityUser> userManager, IConfiguration configuration,
           SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;

        }

        [HttpPost("registrarse")]
        public async Task<ActionResult<ResAutenticacion>> Registrar(Credenciales credenciales)
        {
            var user = new IdentityUser { UserName = credenciales.Email, Email = credenciales.Email };
            var result = await userManager.CreateAsync(user, credenciales.Password);

            if (result.Succeeded)
            {
                
                return await ConstruirToken(credenciales);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
        [HttpPost("iniciar sesion")]
        public async Task<ActionResult<ResAutenticacion>> Login(Credenciales credenciales)
        {
            var result = await signInManager.PasswordSignInAsync(credenciales.Email,
                credenciales.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await ConstruirToken(credenciales);
            }
            else
            {
                return BadRequest("inicio de sesion fallido");
            }

        }


        private async Task<ResAutenticacion> ConstruirToken(Credenciales credenciales)
        {
          
            var claims = new List<Claim>
            {
                new Claim("email", credenciales.Email),
       
            };

            var usuario = await userManager.FindByEmailAsync(credenciales.Email);
            var claimsDB = await userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDB);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiration, signingCredentials: creds);

            return new ResAutenticacion()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiration
            };
        }


        [HttpGet("RenovarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ResAutenticacion>> Renovar()
        {
            var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == "email").FirstOrDefault();
            var email = emailClaim.Value;

            var credenciales = new Credenciales()
            {
                Email = email
            };

            return await ConstruirToken(credenciales);

        }

        [HttpPost("Doctor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult> HacerDoctor(AdminDTO adminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(adminDTO.Email);

            await userManager.AddClaimAsync(usuario, new Claim("Doctor", "2"));

            return NoContent();
        }
        [HttpPost("RemoverDoctor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult> RemoverDoctor(AdminDTO adminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(adminDTO.Email);

            await userManager.RemoveClaimAsync(usuario, new Claim("Doctor", "2"));

            return NoContent();
        }

        [HttpPost("Admin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult> HacerAdmin(AdminDTO adminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(adminDTO.Email);

            await userManager.AddClaimAsync(usuario, new Claim("Admin", "1"));

            return NoContent();
        }

        [HttpPost("RemoverAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
        public async Task<ActionResult> RemoverAdmin(AdminDTO adminDTO)
        {
            var usuario = await userManager.FindByEmailAsync(adminDTO.Email);

            await userManager.RemoveClaimAsync(usuario, new Claim("Admin", "1"));

            return NoContent();
        }


    }
}
