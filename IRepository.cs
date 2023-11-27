using System;
using System.Collections.Generic;



namespace Pim_8
{
    public interface IRepository<T>
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        T ObterPorId(int id);
        List<T> ObterTodos();
    }
}