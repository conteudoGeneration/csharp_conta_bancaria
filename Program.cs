using conta_bancaria.controller;
using conta_bancaria.model;

namespace conta_bancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;

        static void Main(string[] args)
        {
            // Variáveis de entrada de dados
            int opcao, numero, agencia, tipo, aniversario;
            string? titular;
            float saldo, limite;

            //Instância da Classe ContaController
            ContaController contas = new ContaController();

            Console.WriteLine("\nCriar Contas\n");

            ContaCorrente cc1 = new ContaCorrente(contas.gerarNumero(), 123, 1, "João da Silva", 1000f, 100.0f);
            contas.cadastrar(cc1);

            ContaCorrente cc2 = new ContaCorrente(contas.gerarNumero(), 124, 1, "Maria da Silva", 2000f, 100.0f);
            contas.cadastrar(cc2);

            ContaPoupanca cp1 = new ContaPoupanca(contas.gerarNumero(), 125, 2, "Mariana dos Santos", 4000f, 12);
            contas.cadastrar(cp1);

            ContaPoupanca cp2 = new ContaPoupanca(contas.gerarNumero(), 125, 2, "Juliana Ramos", 8000f, 15);
            contas.cadastrar(cp2);

            contas.listarTodas();


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
                    sobre();
                    Console.ResetColor();
                    System.Environment.Exit(0);
                }

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Criar Conta\n\n");

                        Console.WriteLine("Digite o Numero da Agência: ");
                        agencia = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Digite o Nome do Titular: ");
                        titular = Console.ReadLine();

                        do
                        {
                            Console.WriteLine("Digite o Tipo da Conta (1-CC ou 2-CP): ");
                            tipo = Convert.ToInt32(Console.ReadLine());
                        } while (tipo != 1 && tipo != 2);

                        Console.WriteLine("Digite o Saldo da Conta (R$): ");
                        saldo = Convert.ToSingle(Console.ReadLine());

                        switch (tipo)
                        {
                            case 1:
                                Console.WriteLine("Digite o Limite de Crédito (R$): ");
                                limite = Convert.ToSingle(Console.ReadLine());
                                contas.cadastrar(new ContaCorrente(contas.gerarNumero(), agencia, tipo, titular, saldo, limite));
                                break;
                            case 2:
                                Console.WriteLine("Digite o dia do Aniversario da Conta: ");
                                aniversario = Convert.ToInt32(Console.ReadLine());
                                contas.cadastrar(new ContaPoupanca(contas.gerarNumero(), agencia, tipo, titular, saldo, aniversario));
                                break;
                        }

                        keyPress();
                        break;
                    case 2:
                        Console.WriteLine("Listar todas as Contas\n\n");

                        contas.listarTodas();

                        keyPress();
                        break;
                    case 3:
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");

                        Console.WriteLine("Digite o número da conta: ");
                        numero = Convert.ToInt32(Console.ReadLine());

                        contas.procurarPorNumero(numero);

                        keyPress();
                        break;
                    case 4:
                        Console.WriteLine("Atualizar dados da Conta\n\n");

                        keyPress();
                        break;
                    case 5:
                        Console.WriteLine("Apagar a Conta\n\n");

                        keyPress();
                        break;
                    case 6:
                        Console.WriteLine("Saque\n\n");

                        keyPress();
                        break;
                    case 7:
                        Console.WriteLine("Depósito\n\n");

                        keyPress();
                        break;
                    case 8:
                        Console.WriteLine("Transferência entre Contas\n\n");

                        keyPress();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nOpção Inválida!\n");
                        Console.ResetColor();
                        keyPress();
                        break;
                }
            }
        }

        private static void sobre()
        {
            Console.WriteLine("\n*********************************************************");
            Console.WriteLine("Projeto Desenvolvido por: ");
            Console.WriteLine("Rafael Queiróz - rafaelproinfo@gmail.com");
            Console.WriteLine("github.com/rafaelq80");
            Console.WriteLine("*********************************************************");
        }

        private static void keyPress()
        {
            do
            {
                Console.Write("\nPress Enter to continue!");
                consoleKeyInfo = Console.ReadKey();
            } while (consoleKeyInfo.Key != ConsoleKey.Enter);
        }
    }
}