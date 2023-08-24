//VERSÃO COM CONVERSÃO PARA RECONHECIMENTO DO '.' DECIMAL NO CSV

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

public class CsvImporter
{
    // Definindo a classe para representar os dados do CSV
    private class CsvData
    {

        public string Date { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string Symbol { get; set; }
        public string Instrument_Type { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public decimal Quantity { get; set; }
        public decimal Average_Price { get; set; }
        public decimal Comissions { get; set; }
        public decimal Fees { get; set; }
        public string Multiplier { get; set; }
        public string Root_Symbol { get; set; }
        public string Underlying_Symbol { get; set; }
        public string Expiration_Date { get; set; }
        public decimal Strike_Price { get; set; }
        public string Call_or_Put { get; set; }
        public string Order_Number { get; set; }



    }

    // Método para importar o arquivo CSV para o banco de dados SQL
    public void ImportCsvToSql(string filePath, string connectionString)
    {
        List<CsvData> csvDataList = ReadCsv(filePath);
        InsertDataIntoSql(csvDataList, connectionString);
    }

    // Método para ler o arquivo CSV e retornar uma lista de objetos CsvData

    private List<CsvData> ReadCsv(string filePath)
    {
        // Configurando a cultura para usar o ponto como separador decimal
        CultureInfo culture = new CultureInfo("en-US");
        culture.NumberFormat.NumberDecimalSeparator = ".";

        // Salvar a cultura atual para restaurar depois
        CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

        // Usar a cultura configurada somente neste método
        Thread.CurrentThread.CurrentCulture = culture;

        List<CsvData> csvDataList = new List<CsvData>();
        
        using (TextFieldParser parser = new TextFieldParser(filePath))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(","); // Defina o delimitador, pode ser ',' ou ';', etc.

            parser.ReadLine();

            int lineCount = 0;
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();

                CsvData data = new CsvData
                {
                    Date = fields[0],
                    Type = fields[1],
                    Action = fields[2],
                    Symbol = fields[3],
                    Instrument_Type = fields[4],
                    Description = fields[5],
                    Value = ParseDecimal(fields[6]),
                    Quantity = ParseDecimal(fields[7]),
                    Average_Price = ParseDecimal(fields[8]),
                    Comissions = ParseDecimal(fields[9]),
                    Fees = ParseDecimal(fields[10]),
                    Multiplier = fields[11],
                    Root_Symbol = fields[12],
                    Underlying_Symbol = fields[13],
                    Expiration_Date = fields[14],
                    Strike_Price = ParseDecimal(fields[15]),
                    Call_or_Put = fields[16],
                    Order_Number = fields[17]
                };

               //foreach (string field in fields)
                //{ Console.WriteLine(data.Date); }
                
                
                csvDataList.Add(data);
                
                /*lineCount++;

                if (lineCount % 20 == 0)
                {
                    Console.WriteLine("Pressione Enter para continuar...");
                    Console.ReadLine();
                }*/

            }
        
        }


        // Restaurar a cultura original
        Thread.CurrentThread.CurrentCulture = originalCulture;
        //Console.ReadKey();
        
        return csvDataList;
    }

    private decimal ParseDecimal(string field)
    {
        field = CleanNumericField(field);
        if (string.IsNullOrEmpty(field))
        {
            return 0.0m;
        }
        return decimal.Parse(field);
    }

    private string CleanNumericField(string field)
    {
        return field.Trim().Replace("\"", "").Replace(",", "").Replace("--", "").Replace(" ", "");
    }

    // Método para conectar ao banco de dados e inserir os dados do CSV na tabela
    private void InsertDataIntoSql(List<CsvData> csvDataList, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            foreach (var data in csvDataList)
            {
                // Remova o deslocamento de fuso horário da string antes da conversão
                string dateString = data.Date.Substring(0, 19); // Remova os últimos 6 caracteres (-0300)

                DateTime parsedDate = DateTime.ParseExact(dateString, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);

                /*// Depuração do valor do Strike_Price antes de tentar converter para decimal
                Console.WriteLine("Valor do Date antes da conversão: " + parsedDate);
                Console.WriteLine("Valor do Type antes da conversão: " + data.Type);
                Console.WriteLine("Valor do Value antes da conversão: " + data.Value);
                Console.WriteLine("Valor do Type Quantity da conversão: " + data.Quantity);
                Console.WriteLine("Valor do Comissions antes da conversão: " + data.Comissions);
                Console.WriteLine("Valor do Fees antes da conversão: " + data.Fees);
                Console.WriteLine("Valor do Fees Root_Symbol da conversão: " + data.Root_Symbol);
                Console.WriteLine("Valor do Expiration_date antes da conversão: " + data.Expiration_Date);
                Console.WriteLine("Valor do Strike_Price antes da conversão: " + data.Strike_Price);*/

                string insertQuery = @"
                INSERT INTO trades_t (Date,
                Type, 
                Action,
                Value,
                Quantity,                
                Comissions, 
                Fees,
                Root_Symbol,
                Expiration_date,
                Strike_Price, 
                Call_or_Put, 
                Order_Number)        
                VALUES (@Date,
                @Type,             
                @Action,
                @Value,
                @Quantity,
                @Comissions, 
                @Fees, 
                @Root_Symbol,
                @Expiration_date,
                @Strike_Price, 
                @Call_or_Put, 
                @Order_Number)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@Date", parsedDate); // Use o valor convertido
                        command.Parameters.AddWithValue("@Type", data.Type);
                        command.Parameters.AddWithValue("@Action", data.Action);
                        command.Parameters.AddWithValue("@Value", data.Value);
                        command.Parameters.AddWithValue("@Quantity", data.Quantity);
                        command.Parameters.AddWithValue("@Comissions", (data.Comissions));
                        command.Parameters.AddWithValue("@Fees", (data.Fees));
                        command.Parameters.AddWithValue("@Root_Symbol", data.Root_Symbol);
                        command.Parameters.AddWithValue("@Expiration_date", data.Expiration_Date);
                        command.Parameters.AddWithValue("@Strike_Price", data.Strike_Price);
                        command.Parameters.AddWithValue("@Call_or_Put", data.Call_or_Put);
                        command.Parameters.AddWithValue("@Order_Number", data.Order_Number);

                        command.ExecuteNonQuery();
                    }
                    catch (FormatException ex)
                    {
                        // Exiba a mensagem de erro e o tipo da exceção para diagnóstico
                        Console.WriteLine("Erro ao executar a consulta: " + ex);
                    }
                }
            }
        }

    }




    // Método para verificar se a tabela está vazia
    private bool IsTableEmpty(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string countQuery = "SELECT COUNT(*) FROM trades_t";
            using (SqlCommand command = new SqlCommand(countQuery, connection))
            {
                int count = (int)command.ExecuteScalar();
                return count == 0;
            }
        }
    }

    public int UpdateTradesUsingTradesT(string connectionString)
    {
        int recordsUpdated = 0; // Inicializa o contador

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            
            // Insira a lógica para verificar e inserir registros da tabela trades_t na tabela trades
            string insertQuery = @"
        INSERT INTO trades (Date, Type, Action, Value, Quantity, Comissions, Fees, Root_Symbol, Expiration_date, Strike_Price, Call_or_Put, Order_Number, Created_At)
        SELECT
            CAST(tt.Date AS DATETIME),
            tt.Type,
            tt.Action,
            tt.Value,                
            tt.Quantity,
            tt.Comissions,
            tt.Fees,
            tt.Root_Symbol,
            tt.Expiration_date,
            tt.Strike_Price,
            tt.Call_or_Put,
            tt.Order_Number,
            CONVERT(VARCHAR(19), GETDATE(), 120)
        FROM trades_t tt
        LEFT JOIN trades t ON tt.Date = t.Date
        WHERE t.Date IS NULL;
        ";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {                
                recordsUpdated = command.ExecuteNonQuery(); // Armazena o número de registros atualizados
            }
        }

        return recordsUpdated; // Retorna o número de registros atualizados
    }


    public static void Main(string[] args)
    {

        Console.WriteLine("Informe o nome do arqivo CSV a importar ");
        string arq = Console.ReadLine();

        if (string.IsNullOrEmpty(arq))
        {
            Console.WriteLine("O nome do arquivo não pode ser vazio.");
            return;
        }


        string filePath = "C:\\Users\\paulo\\Downloads\\" + arq + ".csv";
        string connectionString = "Initial Catalog=Ttrade; User ID=Paulo;Password=123pp; MultipleActiveResultSets=True;TrustServerCertificate=True";

        // Criar uma instância do CsvImporter
        CsvImporter csvImporter = new CsvImporter();


        // Verificar se a tabela está vazia antes de importar o CSV
        if (!csvImporter.IsTableEmpty(connectionString))
        {
            Console.WriteLine("A tabela não está vazia. Deseja apagar a tabela? (S/N)");
            string resposta = Console.ReadLine();

            if (resposta.ToUpper() == "S")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string deleteQuery = "DELETE FROM trades_t";
                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Tabela apagada com sucesso.");
                    }
                }
            }
            else
            {
                Console.WriteLine("A importação do arquivo t não foi realizada.");
                return;
            }
        }

        // Chamar o método para importar o CSV para o banco de dados
        csvImporter.ImportCsvToSql(filePath, connectionString);

        // Chamar o método para atualizar os campos da tabela trades usando trades_t
         int recordsUpdated = csvImporter.UpdateTradesUsingTradesT(connectionString);

        //DateTime currentTime = DateTime.Now;

        Console.WriteLine($"Importação e atualização concluídas na tabela trades_t.");
        Console.WriteLine($"{recordsUpdated} registros foram atualizados na tabela trades.");
    }

}

//Query da tabela como resposta da tabela dinâmica
//================================================
/*SELECT
    RIGHT('0000' + CAST(YEAR(trades.Date) AS VARCHAR(4)), 4) + RIGHT('00' + CAST(MONTH(trades.Date) AS VARCHAR(2)), 2) AS year_and_month,
    trades.Date,
    trades.Type,
    trades.Action,
    trades.Value,
    trades.Comissions,
    trades.Fees,
    trades.Quantity,
    trades.Strike_Price,
    trades.Call_or_Put,
    trades.Root_Symbol,
    trades.Order_Number,
    CASE
        WHEN trades.Action LIKE '%OPEN%' and NOT EXISTS (
            SELECT 1
            FROM trades AS t2
            WHERE (t2.Action LIKE '%CLOSE%' or t2.Type like '%Deliver%')
            AND t2.Date > trades.Date and trades.Root_Symbol = t2.Root_Symbol and trades.Call_or_Put = t2.Call_or_Put and trades.Strike_Price = t2.Strike_Price
        ) THEN 'O'
        ELSE ''
    END AS Open_Close
FROM trades*/
