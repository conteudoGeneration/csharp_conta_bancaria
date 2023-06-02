using conta_bancaria.model;

namespace conta_bancaria
{
    internal class Program
    {
        private static ConsoleKeyInfo consoleKeyInfo;

        static void Main(string[] args)
        {
            int opcao;

            // Teste da Classe Conta
            Conta c1 = new Conta(1, 123, 1, "Adriana", 10000.0f);
            c1.visualizar();
            c1.sacar(12000.0f);
            c1.visualizar();
            c1.depositar(5000.0f);
            c1.visualizar();

            // Teste da Classe Conta Corrente
            ContaCorrente cc1 = new ContaCorrente(2, 123, 1, "Mariana", 15000.0f, 1000.0f);
            cc1.visualizar();
            cc1.sacar(12000.0f);
            cc1.visualizar();
            cc1.depositar(5000.0f);
            cc1.visualizar();

            // Teste da Classe Conta Poupança
            ContaPoupanca cp1 = new ContaPoupanca(3, 123, 2, "Victor", 100000.0f, 15);
            cp1.visualizar();
            cp1.sacar(1000.0f);
            cp1.visualizar();
            cp1.depositar(5000.0f);
            cp1.visualizar();

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


                opcao = Convert.ToInt32(Console.ReadLine());

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

                        keyPress();
                        break;
                    case 2:
                        Console.WriteLine("Listar todas as Contas\n\n");

                        keyPress();
                        break;
                    case 3:
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");

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