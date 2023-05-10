//Exercício de mesa com vetor
int[] V = new int[5];
int[] W = new int[5];

int a = 2;
int b = 5;

Console.WriteLine("VetorV -->>VetorW");
for (int d = 1; d < b; d++)
{
    V[d] = a;
    a = a * 2;
    W[d] = a;
    Console.Write("[" + d + "] = " + V[d] + "-->> " + "[" + (d - 1) + "] = " + W[d]);
    Console.WriteLine();
}

