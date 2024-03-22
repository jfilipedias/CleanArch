# Arquitetura Limpa na Prática

Esse projeto é um exemplo de como implementar Arquitetura Limpa com .Net.

## Casos de uso

- Um cliente pode realizar uma transação. Ao salvar a transação deve ser exibido o saldo atual e limite disponível do cliente.
- Um cliente pode consultar o seu extrato. Deve ser exibido o seu saldo atual, contendo o total, limite disponível e data da consulta, e uma lista das últimas 10 transações realizadas.

## Regras de negócio

- [x] A transação deve conter uma descrição contendo de 1 a 10 caracteres.
- [x] A transação deve ser do tipo crédito ou débito ('c' ou 'd').
- [x] Uma transação de débito **nunca** pode deixar o saldo do cliente menor que o seu limite disponível.
- [x] A transação deve possuir um valor inteiro que representa centavos.
- [x] O saldo do cliente deve ser um valor inteiro que representa centavos.
- [x] O limite do cliente deve ser um valor inteiro que representa centavos.
