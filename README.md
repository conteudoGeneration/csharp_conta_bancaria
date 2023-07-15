# Projeto Conta Bancária - POO - C#

<br />

<div align="center">
   <img src="https://i.imgur.com/DNV9Rxu.png" title="source: imgur.com" width="25%"/>
</div>

<br /><br />

## Diagrama de Classes

```mermaid
classDiagram
class Conta {
<<Abstract>>
  - numero : int
  - agencia : int
  - tipo : int
  - titular : string
  - saldo : decimal
  + int GetNumero()
  + int GetAgencia()
  + int GetTipo()
  + string GetTitular()
  + decimal GetSaldo()
  + void SetNumero(int numero)
  + void SetAgencia(int agencia)
  + void SetTipo(int tipo)
  + void SetTitular(string titular)
  + void SetSaldo(decimal saldo)
  + bool Sacar(decimal valor)
  + void Depositar(decimal valor)
  + void Visualizar()
}
class ContaCorrente {
  - limite : decimal
  + decimal GetLimite()
  + void SetLimite(decimal limite)
  + bool Sacar(decimal valor)
  + void Visualizar()
}
class ContaPoupanca {
  - aniversario : int
  + int GetAniversario()
  + void SetAniversario(int aniversario)
  + void Visualizar()
}
class IContaRepository{
<< Interface >>
+ void ProcurarPorNumero(int numero)
+ void ListarTodas()
+ void Cadastrar(Conta conta)
+ void Atualizar(Conta conta)
+ void Deletar(int numero)
+ void Sacar(int numero, decimal valor)
+ void Depositar(int numero, decimal valor)
+ void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
}
class ContaController{
+ void ProcurarPorNumero(int numero)
+ void ListarTodas()
+ void Cadastrar(Conta conta)
+ void Atualizar(Conta conta)
+ void Deletar(int numero)
+ void Sacar(int numero, decimal valor)
+ void Depositar(int numero, decimal valor)
+ void Transferir(int numeroOrigem, int numeroDestino, decimal valor)
+ int GerarNumero()
+ Conta BuscarNaCollection(int numero)
+ int RetornaTipo(int numero)
}
Conta <|-- ContaCorrente
Conta <|-- ContaPoupanca
Conta <.. IContaRepository
IContaRepository <|.. ContaController
```

<br /><br />

## Print da Tela

<div align="center">
   <img src="https://i.imgur.com/MFK9yXB.png" title="source: imgur.com" width="90%"/>
</div>
