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
        Task<List<UsuarioResponseDTO>> ListarUsuarios();
        Task <UsuarioResponseDTO> BuscarPorId(long id);
        Task<List<PetResponseDTO>> BuscarPets(long id);
        
        Task AtualizarUsuario(long id, UsuarioUpdateDTO usuario);
        Task<List<UsuarioResponseDTO>> ListarPorTipo(TipoUsuario tipoUsuario);


    }
}
