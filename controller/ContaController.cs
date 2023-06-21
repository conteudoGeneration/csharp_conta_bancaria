

using conta_bancaria.model;
using conta_bancaria.repository;

namespace conta_bancaria.controller
{
    public class ContaController : IContaRepository
    {
        private readonly List<Conta> listaContas = new();
        int numero = 0;

        public void ListarTodas()
        {
            foreach (var conta in listaContas)
            {
                conta.Visualizar();
            }
        }

        public void Cadastrar(Conta conta)
        {
            listaContas.Add(conta);
            Console.WriteLine("\nA Conta número: " + conta.GetNumero() + " foi criada com sucesso!");
        }

        public void ProcurarPorNumero(int numero)
        {
            var conta = BuscarNaCollection(numero);

            if (conta != null)
                conta.Visualizar();
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA Conta número: " + numero + " não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void Atualizar(Conta conta)
        {
            var buscaConta = BuscarNaCollection(conta.GetNumero());

            if (buscaConta != null)
            {
                var indexOf = listaContas.IndexOf(buscaConta);

                listaContas[indexOf] = conta;

                Console.WriteLine("\nA Conta numero: " + conta.GetNumero() + " foi atualizada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA Conta numero: " + conta.GetNumero() + " não foi encontrada!");
                Console.ResetColor();

            }

        }

        public void Deletar(int numero)
        {
            var conta = BuscarNaCollection(numero);

            if (conta != null)
            {
                if (listaContas.Remove(conta) == true)
                    Console.WriteLine("\nA Conta numero: " + numero + " foi deletada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA Conta numero: " + numero + " não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void Sacar(int numero, decimal valor)
        {
            var conta = BuscarNaCollection(numero);

            if (conta != null)
            {
                if (conta.Sacar(valor) == true)
                    Console.WriteLine("\nO Saque na Conta numero: " + numero + " foi efetuado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA Conta numero: " + numero + " não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void Depositar(int numero, decimal valor)
        {
            var conta = BuscarNaCollection(numero);

            if (conta != null)
            {
                conta.Depositar(valor);
                Console.WriteLine("\nO Depósito na Conta numero: " + numero + " foi efetuado com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA Conta numero: " + numero + " não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            var contaOrigem = BuscarNaCollection(numeroOrigem);
            var contaDestino = BuscarNaCollection(numeroDestino);

            if (contaOrigem != null && contaDestino != null)
            {
                if (contaOrigem.Sacar(valor) == true)
                {
                    contaDestino.Depositar(valor);
                    Console.WriteLine("\nA Transferência foi efetuada com sucesso!");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA Conta numero: " + numero + " não foi encontrada!");
                Console.ResetColor();
            }
        }

        /* Métodos Auxiliares */

        /* Método para gerar automaticamente o Número da Conta */
        public int GerarNumero()
        {
            return ++numero;
        }

        /* Método para buscar a Conta na Collection */
        public Conta? BuscarNaCollection(int numero)
        {
            foreach (var conta in listaContas)
            {
                if (conta.GetNumero() == numero)
                {
                    return conta;
                }
            }

            return null;
        }

        /* Método para retornar o Tipo da Conta */
        public int RetornaTipo(int numero)
        {
            foreach (var conta in listaContas)
            {
                if (conta.GetNumero() == numero)
                {
                    return conta.GetTipo();
                }
            }

            return 0;
        }
    }
}
