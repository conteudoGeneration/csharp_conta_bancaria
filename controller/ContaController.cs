

using conta_bancaria.model;
using conta_bancaria.repository;

namespace conta_bancaria.controller
{
    internal class ContaController : ContaRepository
    {
        private List<Conta> listaContas = new List<Conta>();
        int numero = 0;

        public void listarTodas()
        {
            foreach (var conta in listaContas)
            {
                conta.visualizar();
            }
        }

        public void cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine("\nA Conta número: " + conta.getNumero() + " foi criada com sucesso!");
        }

        public void procurarPorNumero(int numero)
        {
            var conta = buscarNaCollection(numero);

            if (conta != null)
                conta.visualizar();
            else
               Console.WriteLine("\nA Conta número: " + numero + " não foi encontrada!");
        }

        public void atualizar(Conta conta)
        {
            throw new NotImplementedException();
        }

        public void deletar(int numero)
        {
            throw new NotImplementedException();
        }

        public void depositar(int numero, float valor)
        {
            throw new NotImplementedException();
        }

        public void sacar(int numero, float valor)
        {
            throw new NotImplementedException();
        }

        public void transferir(int numeroOrigem, int numeroDestino, float valor)
        {
            throw new NotImplementedException();
        }

        /* Métodos Auxiliares */

        /* Método para gerar automaticamente o Número da Conta */
        public int gerarNumero()
        {
            return ++numero;
        }

        /* Método para buscar a Conta na Collection */
        public Conta? buscarNaCollection(int numero)
        {
            foreach (var conta in listaContas)
            {
                if (conta.getNumero() == numero)
                {
                    return conta;
                }
            }

            return null;
        }

        /* Método para retornar o Tipo da Conta */
        public int retornaTipo(int numero)
        {
            foreach (var conta in listaContas)
            {
                if (conta.getNumero() == numero)
                {
                    return conta.getTipo();
                }
            }

            return 0;
        }
    }
}
