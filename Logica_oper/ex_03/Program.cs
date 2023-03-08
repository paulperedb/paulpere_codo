Console.WriteLine("Qual o sabor da pizza?");
string sabor=Console.ReadLine();
Console.WriteLine("Quantas pessoas irão comer a pizza?");
int quant=int.Parse(Console.ReadLine());
double total = (double) quant *3/8;
Console.WriteLine("Você precisa comprar "+total.ToString()+" pizzas de "+sabor);


