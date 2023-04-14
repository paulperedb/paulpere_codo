//MÉDIA DE NOTAS
/*
double Nota1 = double.Parse(Console.ReadLine());
double Nota2 = double.Parse(Console.ReadLine());

double resultado  = (Nota1+Nota2)/2;

if (resultado > 70)
{ Console.WriteLine("Nota final \""+resultado+"\" Você foi aprovado");}
else
{ Console.WriteLine("Nota final \"" + resultado + "\" Você foi reprovado"); }
Console.ReadKey();
*/
/*
//CALCULO DO < NÚMERO
int num1 = int.Parse(Console.ReadLine());
int num2 = int.Parse(Console.ReadLine());
int num3 = int.Parse(Console.ReadLine());
int num4 = int.Parse(Console.ReadLine());
int num5 = int.Parse(Console.ReadLine());
int num_menor = num1;
if (num2 < num_menor)
{ num_menor=num2; }
if (num3 < num_menor)
{ num_menor= num3; }
if (num4 < num_menor)
{ num_menor=num4; }
if (num5 < num_menor)
{ num_menor=num5; }
Console.WriteLine("O menor número é "+num_menor);
Console.ReadKey();
*/

//CÁLCULO DO VALOR DA PIZZA
Console.WriteLine("Qual o sabor da pizza? ");
string sabor = Console.ReadLine().ToUpper();
Console.WriteLine("Quantas pizzas vc deseja pedir ? ");
int quant = int.Parse(Console.ReadLine());
Console.WriteLine("Deseja borda recheada? SIM/NAO ");
bool borda = Console.ReadLine().ToUpper()=="SIM"; //VERDADE
double pizzaValor = 10;
double pizzaAcrescimo = 2;
double pedidoTot = 0;
if (borda)
{ pizzaValor = pizzaValor + pizzaAcrescimo; }
pedidoTot= pizzaValor*quant;
Console.WriteLine("O seu pedido foi completado com  "+quant+" pizza(s) de "+sabor +" pelo valor total de R$"+ pedidoTot);
Console.ReadKey();