//WHILE
double numLido = -1;
double soma = 0;

while (numLido != 0)
{
    Console.Write("Digite um número ");
    numLido = Double.Parse(Console.ReadLine());
    soma += numLido;
}
Console.WriteLine("Total do números é " + soma);
Console.ReadKey();
