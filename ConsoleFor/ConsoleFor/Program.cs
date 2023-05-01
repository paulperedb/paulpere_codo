int num1= int.Parse(Console.ReadLine());
int num2=int.Parse(Console.ReadLine());
int incremento = int.Parse(Console.ReadLine());
int contador = 0;

Console.WriteLine();

Console.WriteLine("Contando em ordem crescente...");
for (contador = num1; contador <= num2; contador+=incremento)
{ Console.WriteLine(contador); }

Console.WriteLine();

Console.WriteLine("Contando em ordem decrescente...");
for (contador = num2; contador > num1; contador -= incremento)
{ Console.WriteLine(contador); }

Console.ReadKey();

