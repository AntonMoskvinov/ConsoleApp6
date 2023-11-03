using System;
using System.Data.SqlClient;

class GameInfo
{
    private static string connectionString = "ваша строка подключения к базе данных";

    static void Main()
    {
        DisplaySinglePlayerGames();
        DisplayMultiplayerGames();
        DisplayGameWithMaxSales();
        DisplayGameWithMinSales();
        DisplayTop3PopularGames();
        DisplayTop3UnpopularGames();
    }

    static void DisplaySinglePlayerGames()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Games WHERE GameType = 'SinglePlayer'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Информация о однопользовательских играх:");
                Console.WriteLine($"Название: {reader["Name"]}, Проданных копий: {reader["Sales"]}");
            }
        }
    }

    static void DisplayMultiplayerGames()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Games WHERE GameType = 'Multiplayer'";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Информация о многопользовательских играх:");
                Console.WriteLine($"Название: {reader["Name"]}, Проданных копий: {reader["Sales"]}");
            }
        }
    }

    static void DisplayGameWithMaxSales()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT TOP 1 * FROM Games ORDER BY Sales DESC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Информация о игре с максимальным количеством проданных копий:");
                Console.WriteLine($"Название: {reader["Name"]}, Проданных копий: {reader["Sales"]}");
            }
        }
    }

    static void DisplayGameWithMinSales()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT TOP 1 * FROM Games ORDER BY Sales ASC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Информация о игре с минимальным количеством проданных копий:");
                Console.WriteLine($"Название: {reader["Name"]}, Проданных копий: {reader["Sales"]}");
            }
        }
    }

    static void DisplayTop3PopularGames()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT TOP 3 * FROM Games ORDER BY Sales DESC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("Топ-3 популярнейших игр:");
            while (reader.Read())
            {
                Console.WriteLine($"Название: {reader["Name"]}, Проданных копий: {reader["Sales"]}");
            }
        }
    }

    static void DisplayTop3UnpopularGames()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT TOP 3 * FROM Games ORDER BY Sales ASC";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            Console.WriteLine("Топ-3 самых непопулярных игр:");
            while (reader.Read())
            {
                Console.WriteLine($"Название: {reader["Name"]}, Проданных копий: {reader["Sales"]}");
            }
        }
    }
}