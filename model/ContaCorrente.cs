namespace conta_bancaria.model
{
    public class ContaCorrente : Conta
    {
        private decimal limite;

        public ContaCorrente(int numero, int agencia, int tipo, string titular, decimal saldo, decimal limite) : base(numero, agencia, tipo, titular, saldo)
        {
            this.limite = limite;
        }

        public decimal GetLimite()
        {
            return limite;
        }

        public void SetLimite(decimal limite)
        {
            this.limite = limite;
        }


        public override bool Sacar(decimal valor)
        {

            if (this.GetSaldo() + this.GetLimite() < valor)
            {
                Console.WriteLine("\n Saldo Insuficiente!");
                return false;
            }

            this.SetSaldo(this.GetSaldo() - valor);
            return true;

        }

        public override void Visualizar()
        {
            base.Visualizar();
            Console.WriteLine("Limite de Crédito: " + this.limite);
        }
    }
}
