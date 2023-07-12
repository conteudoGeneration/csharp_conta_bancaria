namespace conta_bancaria
{
    public class Program
    {
        static void Main()
        {
            int opcao;

            while (true)
            {

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

                opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao == 9)
                {
                    Console.WriteLine("\nBanco do Brazil com Z - O seu Futuro começa aqui!");
                    Sobre();
                    System.Environment.Exit(0);
                }

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Criar Conta\n\n");

                        break;
                    case 2:
                        Console.WriteLine("Listar todas as Contas\n\n");

                        break;
                    case 3:
                        Console.WriteLine("Consultar dados da Conta - por número\n\n");

                        break;
                    case 4:
                        Console.WriteLine("Atualizar dados da Conta\n\n");

                        break;
                    case 5:
                        Console.WriteLine("Apagar a Conta\n\n");

                        break;
                    case 6:
                        Console.WriteLine("Saque\n\n");

                        break;
                    case 7:
                        Console.WriteLine("Depósito\n\n");

                        break;
                    case 8:
                        Console.WriteLine("Transferência entre Contas\n\n");

                        break;
                    default:
                        Console.WriteLine("\nOpção Inválida!\n");
                        break;
                }
            }
        }

        static void Sobre()
        {
           Console.WriteLine("\n*********************************************************");
           Console.WriteLine("Projeto Desenvolvido por: ");
           Console.WriteLine("Rafael Queiróz - rafaelproinfo@gmail.com");
           Console.WriteLine("github.com/rafaelq80");
           Console.WriteLine("*********************************************************");
        }

    }
}
