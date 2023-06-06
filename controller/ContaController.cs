

using conta_bancaria.model;
using conta_bancaria.repository;
using System.Collections;
using System.Collections.Generic;

namespace conta_bancaria.controller
{
    public class ContaController : ContaRepository
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
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA Conta número: " + numero + " não foi encontrada!");
                Console.ResetColor();
            }
        }

        public void atualizar(Conta conta)
        {
            var buscaConta = buscarNaCollection(conta.getNumero());

            if (buscaConta != null)
            {
                var indexOf = listaContas.IndexOf(buscaConta);

                listaContas[indexOf] = conta;

                Console.WriteLine("\nA Conta numero: " + conta.getNumero() + " foi atualizada com sucesso!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nA Conta numero: " + conta.getNumero() + " não foi encontrada!");
                Console.ResetColor();

            }

        }

        public void deletar(int numero)
        {
            var conta = buscarNaCollection(numero);

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
