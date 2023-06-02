namespace conta_bancaria.model
{
    internal class ContaCorrente : Conta
    {
        private float limite;

        public ContaCorrente(int numero, int agencia, int tipo, string titular, float saldo, float limite) : base(numero, agencia, tipo, titular, saldo)
        {
            this.limite = limite;
        }

        public float getLimite()
        {
            return limite;
        }

        public void setLimite(float limite)
        {
            this.limite = limite;
        }


        public new bool sacar(float valor)
        {

            if (this.getSaldo() + this.getLimite() < valor)
            {
                Console.WriteLine("\n Saldo Insuficiente!");
                return false;
            }

            this.setSaldo(this.getSaldo() - valor);
            return true;

        }

        public new void visualizar()
        {
            base.visualizar();
            Console.WriteLine("Limite de Crédito: " + this.limite);
        }
    }
}
