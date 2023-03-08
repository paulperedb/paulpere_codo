Console.WriteLine("Qual o carro?");
string carro=Console.ReadLine();
Console.WriteLine("Qual a cidade?");
string cidade = Console.ReadLine();
Console.WriteLine("Qual a distancia?");
double distancia = int.Parse(Console.ReadLine());
Console.WriteLine("Qual a velocidade");
double velocidade=int.Parse(Console.ReadLine());
double tempo = distancia/velocidade;
Console.WriteLine("O tempo de viagem será de " + tempo.ToString() + " horas de viagem");



