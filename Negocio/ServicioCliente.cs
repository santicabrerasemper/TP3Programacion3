
using ConexionesBD;
using Dominio_;

namespace Negocio
{
    public class ClienteService
    {
        private readonly ClienteRepository _repo;
        public ClienteService(ClienteRepository repo) => _repo = repo;

        public Cliente? BuscarPorDocumento(string doc) => _repo.GetByDocumento(doc);
        public int RegistrarNuevo(Cliente c) => _repo.Insert(c);
    }
}

