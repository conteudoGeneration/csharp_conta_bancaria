﻿

using conta_bancaria.model;
using conta_bancaria.repository;
using System.Collections;
using System.Collections.Generic;

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

        public void Depositar(int numero, decimal valor)
        {
            throw new NotImplementedException();
        }

        public void Sacar(int numero, decimal valor)
        {
            throw new NotImplementedException();
        }

        public void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
        {
            throw new NotImplementedException();
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
    }
}