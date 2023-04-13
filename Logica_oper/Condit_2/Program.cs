Console.WriteLine("Qual o horário?");

double hora = double.Parse(Console.ReadLine());

if (hora >= 0 && hora <= 12)
        Console.WriteLine("dizemos que " + hora + " hora 'bom dia'");
else if (hora > 12 && hora <= 18)
    Console.WriteLine("dizemos que " + hora + " hora 'boa tarde'");
else if (hora > 18 && hora <= 24)
        Console.WriteLine("dizemos que " + hora + " hora 'boa noite'");
else
    Console.WriteLine("dizemos que você digitou um número inválido");

Console.ReadKey();