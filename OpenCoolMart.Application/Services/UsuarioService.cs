using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpenCoolMart.Domain.Entities;
using OpenCoolMart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OpenCoolMart.Application.Services
{
    public class UsuarioService:IUsuarioService
    {
        public IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        public UsuarioService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }
        public async Task AddUsuario(Usuario usuario)
        {
            Expression<Func<Usuario, bool>> expression = item => item.Id == usuario.Id;
            var usuarios = _unitOfWork.UsuarioRepository.FindByCondition(expression);
            if (usuarios.Any(item => item.Id == usuario.Id))
                throw new Exception("Este usuario ya ha sido registrado");
            await _unitOfWork.UsuarioRepository.Add(usuario);
        }

        public async Task DeleteUsuario(int id)
        {
            await _unitOfWork.UsuarioRepository.Delete(id);
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _unitOfWork.UsuarioRepository.GetAll();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await _unitOfWork.UsuarioRepository.GetById(id);
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            await _unitOfWork.UsuarioRepository.Update(usuario);
        }

        public async Task<Usuario> Autenticar(Usuario usuario)
        {
            var users = await _unitOfWork.UsuarioRepository.GetAll();
            var user = users.SingleOrDefault(x => x.Correo == usuario.Correo && x.Contrasenia == usuario.Contrasenia);
            if(user==null)
                throw new Exception("Usuario no Encontrado");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.PerfilId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(7),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            return user;
        }
    }
}
