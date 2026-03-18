using pet.Application.DTOs;
using pet.Domain.Entity;
using pet.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pet.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task CadastrarUsuario(UsuarioCreateDTO tutor);
        Task<List<Usuario>> ListarUsuarios();
        Task <Usuario> BuscarPorId(long id);
        Task<List<PetResponseDTO>> BuscarPets(long id);
        
        Task AtualizarUsuario(long id, UsuarioUpdateDTO usuario);
        Task<List<Usuario>> ListarPorTipo(TipoUsuario tipoUsuario);


    }
}
