

using System.Data;
using System.Data.SqlClient;

IDbConnection connection = new SqlConnection(
                @"Data Source=(localdb)\.;Initial Catalog=music2;Integrated Security=True"
            );
connection.Open();

IDbCommand command = connection.CreateCommand();
command.CommandText = "SELECT * FROM songs";

IDataReader reader = command.ExecuteReader();
while (reader.Read())
{
    int id = reader.GetInt32(0);
    string title = reader.GetString(1);
    int? rating = reader.IsDBNull(2) ? null : reader.GetInt32(2);
    int weight = reader.GetInt32(3);
    int duration = reader.GetInt32(4);

    Console.WriteLine($"{id,5} {title,-20} {rating,5} {weight,5} {duration,5} ");
}
