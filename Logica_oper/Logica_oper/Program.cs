/*Console.WriteLine("Digite um número inteiro");
int x= int.Parse(Console.ReadLine());
Console.WriteLine("Digite o segundo numero a somar");
int y = int.Parse(Console.ReadLine());
int X = x+y;
Console.WriteLine(X);
Console.ReadKey();*/

Console.WriteLine("qual é o seu nome?");
string nome = Console.ReadLine();
Console.WriteLine("qual o seu ano de nascimento?");
int y = int.Parse(Console.ReadLine());
int idade = 2023-y;
Console.WriteLine(nome+" tem "+idade.ToString()+" anos ");
Console.ReadKey();

