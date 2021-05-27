using Microsoft.EntityFrameworkCore;
using Repositorio.Data;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Implementação.Advogado
{
    public class AdvogadoRepositorio : IAdvogadoRepositorio
    {
        private readonly Contexto _contexto;

        public AdvogadoRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }
        public void AtulizarAdvogado(Dominio.Advogado.Advogado advogado)
        {
            _contexto.Entry(advogado).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public Dominio.Advogado.Advogado BuscarPorId(int id)
        {
            var retorno = _contexto.Advogados.FirstOrDefault(x => x.Id == id);
            return retorno;
        }

        public void ExcluirAdvogado(int id)
        {
            _contexto.Advogados.Remove(_contexto.Advogados.FirstOrDefault(x => x.Id == id));
            _contexto.SaveChanges();
        }

        public void IncluirAdvogado(Dominio.Advogado.Advogado advogado)
        {
             
            _contexto.Advogados.Add(advogado);
            _contexto.SaveChanges();
        }

        public IEnumerable<Dominio.Advogado.Advogado> ListarAdvogados()
        {
            var retorno = _contexto.Advogados.ToList();
            return retorno;
        }
    }
}
