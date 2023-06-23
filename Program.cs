using conta_bancaria.controller;
using conta_bancaria.model;

namespace conta_bancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;

        static void Main()
        {
            // Variáveis de entrada de dados
            int opcao, numero, agencia, tipo, aniversario, numeroDestino;
            string? titular;
            decimal saldo, limite, valor;

            //Instância da Classe ContaController
            ContaController contas = new();

            Console.WriteLine("\nCriar Contas\n");

            ContaCorrente cc1 = new(contas.GerarNumero(), 123, 1, "João da Silva", 1000M, 100.0M);
            contas.Cadastrar(cc1);

            ContaCorrente cc2 = new(contas.GerarNumero(), 124, 1, "Maria da Silva", 2000M, 100.0M);
            contas.Cadastrar(cc2);

            ContaPoupanca cp1 = new(contas.GerarNumero(), 125, 2, "Mariana dos Santos", 4000M, 12);
            contas.Cadastrar(cp1);

            ContaPoupanca cp2 = new(contas.GerarNumero(), 125, 2, "Juliana Ramos", 8000M, 15);
            contas.Cadastrar(cp2);

            contas.ListarTodas();


            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("*****************************************************");
                Console.WriteLine("                                                     ");
                Console.WriteLine("                BANCO DO BRAZIL COM Z                ");
                Console.WriteLine("                                                     ");
                Console.WriteLine("*****************************************************");
                Console.WriteLine("                                                     ");
                Console.WriteLine("            1 - Criar Conta                          ");
                Console.WriteLine("            2 - Listar todas as Contas               ");
                Console.WriteLine("            3 - Buscar Conta por Numero              ");
                Console.WriteLine("            4 - Atualizar Dados da Conta             ");
                Console.WriteLine("            5 - Apagar Conta                         ");
                Console.WriteLine("            6 - Sacar                                ");
                Console.WriteLine("            7 - Depositar                            ");
                Console.WriteLine("            8 - Transferir valores entre Contas      ");
                Console.WriteLine("            9 - Sair                                 ");
                Console.WriteLine("                                                     ");
                Console.WriteLine("*****************************************************");
                Console.WriteLine("Entre com a opção desejada:                          ");
                Console.WriteLine("                                                     ");
                Console.ResetColor();

                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nDigite valores inteiros!");
                    opcao = 0;
                    Console.ResetColor();
                }

                if (opcao == 9)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nBanco do Brazil com Z - O seu Futuro começa aqui!");
                    Sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }

                switch (opcao)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Criar Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o Numero da Agência: ");
                        agencia = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o Nome do Titular: ");
                        titular = Console.ReadLine();

                        titular ??= string.Empty;

                        do
                        {
                            Console.WriteLine("Digite o Tipo da Conta (1-CC ou 2-CP): ");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } while (tipo != 1 && tipo != 2);

                        Console.WriteLine("Digite o Saldo da Conta (R$): ");
                        saldo = Convert.ToDecimal(Console.ReadLine());

                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("Digite o Limite de Crédito (R$): ");
                                limite = Convert.ToDecimal(Console.ReadLine());
                                contas.Cadastrar(new ContaCorrente(contas.GerarNumero(), agencia, tipo, titular, saldo, limite));
                                break;
                            case 2:
                                Console.WriteLine("Digite o dia do Aniversario da Conta: ");
                                aniversario = Convert.ToInt32(Console.ReadLine());
                                contas.Cadastrar(new ContaPoupanca(contas.GerarNumero(), agencia, tipo, titular, saldo, aniversario));
                                break;
                        }

                        KeyPress();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Listar todas as Contas\n\n");
                        Console.ResetColor();

                        contas.ListarTodas();

                        KeyPress();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.ProcurarPorNumero(numero);

                        KeyPress();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Atualizar dados da Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        if (contas.BuscarNaCollection(numero) != null)
                        {
                            Console.WriteLine("Digite o Numero da Agência: ");
                            agencia = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite o Nome do Titular: ");
                            titular = Console.ReadLine();

                            titular ??= string.Empty;

                            Console.WriteLine("Digite o Saldo da Conta (R$): ");
                            saldo = Convert.ToDecimal(Console.ReadLine());

                            tipo = contas.RetornarTipo(numero);

                            switch (tipo)
                            {
                                case 1:
                                    Console.WriteLine("Digite o Limite de Crédito (R$): ");
                                    limite = Convert.ToDecimal(Console.ReadLine());
                                    contas.Atualizar(new ContaCorrente(numero, agencia, tipo, titular, saldo, limite));
                                    break;
                                case 2:
                                    Console.WriteLine("Digite o dia do Aniversario da Conta: ");
                                    aniversario = Convert.ToInt32(Console.ReadLine());
                                    contas.Atualizar(new ContaPoupanca(numero, agencia, tipo, titular, saldo, aniversario));
                                    break;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nConta não encontrada!");
                            Console.ResetColor();
                        }

                        KeyPress();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Apagar a Conta\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.Deletar(numero);

                        KeyPress();
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Saque\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o valor do Saque (R$): ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Sacar(numero, valor);

                        KeyPress();
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Depósito\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o valor do Depósito (R$): ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Depositar(numero, valor);

                        KeyPress();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Transferência entre Contas\n\n");
                        Console.ResetColor();

                        Console.WriteLine("Digite o número da conta (Origem): ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o número da conta (Destino): ");
                        numeroDestino = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Digite o valor da Transferência (R$): ");
                        valor = Convert.ToDecimal(Console.ReadLine());

                        contas.Transferir(numero, numeroDestino, valor);

                        KeyPress();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção Inválida!\n");
                        Console.ResetColor();
                        KeyPress();
                        break;
                }
            }
        }

        private static void Sobre()
        {
            Console.WriteLine("\n*********************************************************");
            Console.WriteLine("Projeto Desenvolvido por: ");
            Console.WriteLine("Rafael Queiróz - rafaelproinfo@gmail.com");
            Console.WriteLine("github.com/rafaelq80");
            Console.WriteLine("*********************************************************");
        }

        private static void KeyPress()
        {
            do
            {
                Console.Write("\nPress Enter to continue!");
                consoleKeyInfo = Console.ReadKey();
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }
    }
}