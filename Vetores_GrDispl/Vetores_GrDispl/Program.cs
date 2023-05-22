// Função que verifica se um número é primo
using System;
using System.Runtime.CompilerServices;

bool EhPrimo(int num)
{
    if (num <= 1)
    {
        return false;
    }

    // Verifica se o número é divisível por algum outro número além de 1 e ele próprio
    for (int i = 2; i <= Math.Sqrt(num); i++)
    {
        if (num % i == 0)
        {
            return false;
        }
    }

    return true;
}


Console.WriteLine("Diga quantos números quer processar? ");
int qnumero = int.Parse(Console.ReadLine());

int[] numero = new int[qnumero];
for (int i = 0; i < numero.Length; i++)
{
    Console.WriteLine("Infome o conteúdo numérico do {0}º índice ", i + 1);
    numero[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Números capturados");

Console.WriteLine("Veja a lista dos números negativos ");
for (int i = 0; i < numero.Length; i++)
{
    if (numero[i] < 0)
        Console.WriteLine(numero[i]);
}

Console.WriteLine("Veja a lista dos números positivos ");
for (int i = 0; i < numero.Length; i++)
{
    if (numero[i] > 0)
        Console.WriteLine(numero[i]);
}
Console.WriteLine();

// Exemplo de uso da função para imprimir todos os números primos entre 1 e o valor máximo do array
Console.WriteLine("Veja a lista dos números primos ");
for (int i = 0; i < numero.Length; i++)
{
    if (EhPrimo(numero[i]))
    {
        Console.WriteLine(numero[i]);
    }
}
Console.WriteLine();
Console.WriteLine("Veja a lista dos números pares ");
for (int i = 0; i < numero.Length; i++)
{
    if (numero[i] % 2 == 0)
    {
        Console.WriteLine(numero[i]);
    }
}