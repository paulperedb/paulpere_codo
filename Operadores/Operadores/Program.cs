
//FORMULÁRIO DE AUMENTO DE SALÁRIO COM BÔNUS E 13º

/*double salario;
double aumento = 1.10;
double bonusJantarRomantico = 500;
double antecipacaoFerias = 1.3;
Console.WriteLine("Qual seu salário?");
salario = double.Parse(Console.ReadLine());
Console.WriteLine();
salario = salario * aumento;
Console.WriteLine("Seu salario com aumento é " + (salario));
salario = salario + bonusJantarRomantico;
Console.WriteLine("Seu salario com aumento e bonus é " + (salario));
salario =salario * antecipacaoFerias;
Console.WriteLine("Seu salario com aumento, bonus e antecipacao_férias é " + (salario));
Console.ReadKey();*/


//AUMENTO DE SALÁRIO POR SEXO, IDADE E NIVEL DE SALÁRIO

/*
Console.WriteLine("Idade/sexo/salário");
int idade = int.Parse(Console.ReadLine());
string sexo = Console.ReadLine().ToUpper();
double salario = double.Parse(Console.ReadLine());
Console.WriteLine("Suas \"info\" são "+idade+" "+sexo+" "+ salario);


//Se for maior que 20 anos e for mulher OU salario menor que 100, salario deverá ter um aumento de 50%
//Se for maior que 30 anos e for homem OU salario menor que 50, salário deverá ter um aumento de 10%

if ((sexo == "M") && idade > 30 || salario < 50)
{
    salario = salario * 1.1;
}
if ((sexo == "F") && idade > 20 || salario < 100)
{
    salario = salario * 1.5;
}
Console.WriteLine(salario);
Console.ReadKey();
*/

//INVERSÃO DA IDENTIFICAÇÃO DO SEXO

Console.WriteLine("Digite o seu sexo");
String sexo = Console.ReadLine().ToUpper();
if (!(sexo =="M"))
{ Console.WriteLine("Você é homem"); }




