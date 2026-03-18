using pet.Domain.Entity;
using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Cadastrar(Usuario usuario);
        Task<List<Usuario>> Listar();
        Task <Usuario> BuscarPorId(long id);
        
        Task<List<Pet>> BuscarPets(long id);
        Task <Usuario> BuscarPorEmail(string email);
        
        Task Atualizar(Usuario usuario);
        Task<List<Usuario>> ListarPorUsuario(TipoUsuario tipousuario);
    }
}
