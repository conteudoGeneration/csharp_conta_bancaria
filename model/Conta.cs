namespace conta_bancaria.model
{
    public class Conta
    {

        private int numero;
        private int agencia;
        private int tipo;
        private string titular;
        private float saldo;

        public Conta(int numero, int agencia, int tipo, string titular, float saldo)
        {
            this.numero = numero;
            this.agencia = agencia;
            this.tipo = tipo;
            this.titular = titular;
            this.saldo = saldo;
        }

        public int getNumero()
        {
            return numero;
        }

        public void setNumero(int numero)
        {
            this.numero = numero;
        }

        public int getAgencia()
        {
            return agencia;
        }

        public void setAgencia(int agencia)
        {
            this.agencia = agencia;
        }

        public int getTipo()
        {
            return tipo;
        }

        public void setTipo(int tipo)
        {
            this.tipo = tipo;
        }

        public string getTitular()
        {
            return titular;
        }

        public void setTitular(string titular)
        {
            this.titular = titular;
        }

        public float getSaldo()
        {
            return saldo;
        }

        public void setSaldo(float saldo)
        {
            this.saldo = saldo;
        }


        public bool sacar(float valor)
        {

            if (this.getSaldo() < valor)
            {
                Console.WriteLine("\n Saldo Insuficiente!");
                return false;
            }

            this.setSaldo(this.saldo - valor);
            return true;
        }

        public void depositar(float valor)
        {
            this.setSaldo(this.saldo + valor);
        }

        public void visualizar()
        {

            string tipo = "";

            switch (this.tipo)
            {
                case 1:
                    tipo = "Conta Corrente";
                    break;
                case 2:
                    tipo = "Conta Poupança";
                    break;
            }

            Console.WriteLine("\n\n*********************************************************************");
            Console.WriteLine("Dados da Conta:");
            Console.WriteLine("*********************************************************************");
            Console.WriteLine("Numero da Conta: " + this.numero);
            Console.WriteLine("Agência: " + this.agencia);
            Console.WriteLine("Tipo da Conta: " + tipo);
            Console.WriteLine("Titular: " + this.titular);
            Console.WriteLine("Saldo: " + this.saldo);

        }

    }
}
