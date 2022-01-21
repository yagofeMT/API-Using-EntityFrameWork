using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL.Interfaces;
using ControleFinanceiro_API.Services;
using ControleFinanceiro_API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleFinanceiro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [allo]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetFunctionById(string id)
        {
            var user = await _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("FilterUser/{name}")]
        public async Task<ActionResult<IEnumerable<User>>> FilterUser(string name)
        {
            if (name == null)
            {
                BadRequest();
            }

            return await _userRepository.FilterUser(name).ToListAsync();
        }

        [HttpPost("SavePhoto")]
        public async Task<ActionResult> SavePhoto()
        {
            var photo = Request.Form.Files[0];
            byte[] b;

            using(var openReadStream = photo.OpenReadStream())
            {
                using(var memoryStream = new MemoryStream())
                {
                    await openReadStream.CopyToAsync(memoryStream);
                    b = memoryStream.ToArray();
                }
            }

            return Ok(new
            {
                photo = b
            });
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult> RegisterUser(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                IdentityResult userCreate;
                string FunctionUser;

                User user = new User
                {
                    UserName = model.UserName,
                    CPF = model.CPF,
                    Email = model.Email,
                    Profissao = model.Profissao,
                    PasswordHash = model.Password,
                };

                if(await _userRepository.GetAllUserRegister() > 0)
                {
                    FunctionUser = "Usuario";
                }
                else
                {
                    FunctionUser = "Administrador";
                }

                userCreate = await _userRepository.AddUser(user, model.Password);

                if (userCreate.Succeeded)
                {
                    await _userRepository.IncludeUserInFunction(user, FunctionUser);
                    var token = TokenService.GenerateToken(user, FunctionUser);
                    await _userRepository.Login(user, false);

                    return Ok(new
                    {
                        emailUserLogin = user.Email,
                        UserId = user.Id,
                        TokenUsuarioLogado = token
                    });
                }
                else
                {
                    return BadRequest(model);
                }
                
            }

            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginVM model)
        {
            if(model == null)
            {
                return NotFound("Email or Password invalid");
            }

            User user = await _userRepository.GetUserByEmail(model.Email);

            if(user != null)
            {
               PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
                if(passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) != PasswordVerificationResult.Failed)
                {
                    var userFunction = await _userRepository.GetFunctionsUser(user);
                    var token = TokenService.GenerateToken(user, userFunction.First());
                    await _userRepository.Login(user, false);

                    return Ok(new
                    {
                        message = $"Login Sucess",
                        emailUserSignIn = user.Email,
                        UserId = user.Id,
                        tokenUserSignIn = token
                    });; 
                }

                return NotFound("Email or Password invalid");
            }

            return NotFound("Email or Password invalid");
        }

    }
}
