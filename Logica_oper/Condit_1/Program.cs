﻿Console.WriteLine("Qual a hora");
double hora=double.Parse(Console.ReadLine());

if (hora > 18 && hora<=24 )
{
    Console.WriteLine("Nesse horário " + hora.ToString()+ " horas dizemos 'Boa noite'");
}

else
{
    if (hora > 12 && hora <= 18)
    {
        Console.WriteLine("Nesse horário " + hora.ToString() + " horas dizemos 'Boa tarde'");
    }
    else
    {
        if (hora >= 0 && hora <= 12)
        {
            Console.WriteLine("Nesse horário " + hora.ToString() + " horas dizemos 'Bom dia'");
        }
        else
        {
            Console.WriteLine("Nesse horário " + hora.ToString() + " horas dizemos que você digitou um horário inválido");
        }
    }

}
Console.ReadKey();