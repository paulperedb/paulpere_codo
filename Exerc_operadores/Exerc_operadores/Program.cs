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

//CALCULO DO < NÚMERO
int num1 = int.Parse(Console.ReadLine());
int num2 = int.Parse(Console.ReadLine());
int num3 = int.Parse(Console.ReadLine());
int num4 = int.Parse(Console.ReadLine());
int num5 = int.Parse(Console.ReadLine());
int num_menor = num1;
if (num1 < num2)
{ num_menor = num1; }
if (num2 < num1)
{ num_menor=num2; }
if (num3 < num2)
{ num_menor=num3; }
if (num4 < num3)
{ num_menor=num4; }
if (num5 < num4)
{ num_menor = num5; }
Console.WriteLine("O menor número é "+num_menor);
Console.ReadKey();


