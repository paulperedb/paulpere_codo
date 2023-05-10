//Exercício de vetor usando looping for, while e if
using System;

int[] b = new int[4];
b[0] = 4;
b[1] = 3;
b[2] = 8;
b[3] = 1;

int final = b.Length - 1;
Console.WriteLine("Tamanho " + b.Length);
Console.WriteLine("Índice final " + final);
int inicial = 0;
Console.WriteLine("Índice inicial " + inicial);


for (int i = 0; i <= final; i++)
{
    Console.WriteLine("b[" + i + "] = " + b[i]);
}
Console.WriteLine();

while (true)
{
    Console.WriteLine("Digite o índice que deseja ver o conteúdo ou um número menor que >0< para sair ");
    int a = int.Parse(Console.ReadLine());

    if (a >= inicial && a <= final)
    {
        Console.WriteLine("O índice digitado é " + a + " e o conteúdo é " + b[a]);
        Console.WriteLine();
    }
    else if (a >= inicial)
    {
        Console.WriteLine("Você digitou um número inválido. Tente novamente ou digite um número negativo para sair");
        Console.WriteLine();
    }
    else if (a <= inicial)
    { break; }

}
