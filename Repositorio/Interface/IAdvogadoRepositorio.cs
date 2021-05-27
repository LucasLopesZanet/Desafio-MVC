using Dominio.Advogado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interface
{
    public interface IAdvogadoRepositorio
    {
        void ExcluirAdvogado(int id);

        void IncluirAdvogado(Advogado advogado);

        void AtulizarAdvogado(Advogado advogado);

        IEnumerable<Advogado> ListarAdvogados();

        Advogado BuscarPorId(int id);
    }
}
