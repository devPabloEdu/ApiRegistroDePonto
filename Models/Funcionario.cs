using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDePontosApi.Models
{
    public class Funcionario
    {
        public string Nome { get; set; }

        //Utilizei o tipo string, pensei em usar char para o cpf, só nao pude utilizar long ou int pois : int só suporta valores até 2.147.483.647 (10 dígitos no máximo) e o Long  suporta valores maiores, mas pode descartar zeros à esquerda Ex: CPF 01234567890 seria armazenado como 1234567890
        public string Cpf { get; set; }
        //A propriedade Id funciona como a chave exclusiva em um banco de dados relacional.
        public int Id { get; set; }
    }
}