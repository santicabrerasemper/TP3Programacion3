using ConexionesBD;
using Dominio;

namespace Negocio
{
    public class ServicioCliente
    {
        private readonly ClienteRepository _repo;
        public ServicioCliente(ClienteRepository repo) => _repo = repo;

        public Cliente BuscarPorDocumento(string doc) => _repo.GetByDocumento(doc);
        public int RegistrarNuevo(Cliente c) => _repo.Insert(c);
    }
}

