using ProvaPOO.Models;
using System.Collections.Generic;

namespace ProvaPOO.Controllers
{
    //Importar a camada Models
    //using NomeProjeto.Models;
    public class BrinquedoController
    {
        //Criar a lista de objeto brinquedo
        //A lista deve ser private pois não sera acessada de fora da classe BrinquedoController
        //uso do underscore para identificar que a variavel global é privada
        private List<Brinquedo> _listaBrinquedo = new List<Brinquedo>();

        //Criar método Adicionar/Remover/Listar

        //Adicionar e Remover recebem o proprio objeto via parametros
        public void Adicionar(Brinquedo objeto)
        {
            _listaBrinquedo.Add(objeto);
        }

        public void Remover(Brinquedo objeto)
        {
            _listaBrinquedo.Remove(objeto);
        }

        //Função lista ira retornar toda a lista de brinquedo
        public List<Brinquedo> ListarBrinquedos()
        {
            return _listaBrinquedo;
        }
    }
}
