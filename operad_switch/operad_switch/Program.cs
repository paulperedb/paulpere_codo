/*
"APLICAÇÃO DE SWITCHES"

DDD 11 – São Paulo – SP
DDD 12 – São José dos Campos – SP
DDD 13 – Santos – SP
DDD 14 – Bauru – SP
DDD 15 – Sorocaba – SP
DDD 16 – Ribeirão Preto – SP
DDD 17 – São José do Rio Preto – SP
DDD 18 – Presidente Prudente – SP
DDD 19 – Campinas – SP
DDD 21 – Rio de Janeiro – RJ
DDD 22 – Campos dos Goytacazes – RJ
DDD 24 – Volta Redonda – RJ
DDD 27 – Vitória / Vila Velha – ES
DDD 28 – Cachoeiro de Itapemirim – ES
DDD 31 – Belo Horizonte – MG
DDD 32 – Juiz de Fora – MG
DDD 33 – Governador Valadares – MG
DDD 34 – Uberlândia – MG
DDD 35 – Poços de Caldas – MG
DDD 37 – Divinópolis – MG
DDD 38 – Montes Claros – MG
DDD 41 – Curitiba – PR
*/

Console.WriteLine("Digite o código da cidade ");
int DDD = int.Parse(Console.ReadLine());

string cidade_nome = "";


switch (DDD)
{
    case 11:
        cidade_nome = "DDD 11 – São Paulo – SP";
        break;
    case 12:
        cidade_nome = "DDD 12 – São José dos Campos – SP";
        break;
    case 13:
        cidade_nome = "DDD 13 – Santos – SP";
        break;
    case 14:
        cidade_nome = "DDD 14 – Bauru – SP";
        break;
    case 15:
        cidade_nome = "DDD 15 – Sorocaba – SP";
        break;
    case 16:
        cidade_nome = "DDD 16 – Ribeirão Preto – SP";
        break;
    case 17:
        cidade_nome = "DDD 17 – São José do Rio Preto – SP";
        break;
    default:
        cidade_nome = "@@@ Não idenfificado @@@";
        break;
}

Console.WriteLine("Dado o número digitado a cidade é " + cidade_nome);
Console.ReadKey();
