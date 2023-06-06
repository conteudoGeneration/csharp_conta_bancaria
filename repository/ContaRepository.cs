using conta_bancaria.model;

namespace conta_bancaria.repository
{
    public interface ContaRepository
    {
        // CRUD da Conta
        public void procurarPorNumero(int numero);
        public void listarTodas();
        public void cadastrar(Conta conta);
        public void atualizar(Conta conta);
        public void deletar(int numero);

        // Métodos Bancários
        public void sacar(int numero, float valor);
        public void depositar(int numero, float valor);
        public void transferir(int numeroOrigem, int numeroDestino, float valor);
    }
}
