using System;
using System.Collections.Generic;

public interface IRepository<T>
{
    void Adicionar(T entidade);
    void Atualizar(T entidade);
    void Excluir(T entidade);
    T ObterPorId(int id);
    List<T> ObterTodos();
}
