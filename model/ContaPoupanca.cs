using static System.Runtime.InteropServices.JavaScript.JSType;

namespace conta_bancaria.model
{
    public class ContaPoupanca : Conta
    {
        private int aniversario;

        public ContaPoupanca(int numero, int agencia, int tipo, string titular, float saldo, int aniversario): base(numero, agencia, tipo, titular, saldo)
        {
            this.aniversario = aniversario;
        }

        public int getAniversario()
        {
            return aniversario;
        }

        public void setAniversario(int aniversario)
        {
            this.aniversario = aniversario;
        }

        public new void visualizar()
        {
           base.visualizar();
           Console.WriteLine("Aniversário da conta: " + this.aniversario);
        }

    }
}
