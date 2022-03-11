using CrudFutebol.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudFutebol.Repository
{
    public interface IJogadorRepository
    {
        int Add(Jogador jogador);
        List<Jogador> GetJogadores();
        Jogador Get(int id);
        int Edit(Jogador jogador);
        int Delete(int id);
    }
}
