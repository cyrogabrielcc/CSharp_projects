using System.Collections.Generic;

namespace Serie.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();

    }
}

/*Método de implementação da lista, retornando, inserindo, excluindo e atualizando de acordo com o id e a posição na lista*/