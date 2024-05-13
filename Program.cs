using SportShop.Enums;
using SportShop.SportShopModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public class Program
{
    public static void Main()
    {
        var connectionString = @"Data Source=WIN-NK524IJNHU6;Initial Catalog=SportsShop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        while (true)
        {
            Console.WriteLine("1.For to Show\n2.For to Delete\n3.For to Update\n4.For to Insert");
            Console.Write("Enter your choice: ");
            int ChooseNumber = int.Parse(Console.ReadLine());
            switch ((Choice)ChooseNumber)
            {
                case Choice.Show:
                    ShowData();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case Choice.Delete:
                    
                    using(var connection = new SqlConnection(connectionString)) 
                    {  
                        connection.Open();
                        Console.Write("Enter Product's Id: ");
                        int ProdcuctId = int.Parse(Console.ReadLine());
                        var query =@"DELETE
                                    FROM WareHouse
                                    WHERE Id =@ProdcuctId";
                        var command=new SqlCommand(query,connection);
                        command.Parameters.AddWithValue("@ProdcuctId", ProdcuctId);
                        command.ExecuteNonQuery();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case Choice.Update:
                   
                    using (var connection = new SqlCommand(connectionString))
                    {
                        connection.Open();
                        Console.Write("Enter Product's Id: ");
                        int ProductId = int.Parse(Console.ReadLine());
                        var query = @$"UPDATE WareHouse
                                     SET Quantity=Quantity+1
                                     WHERE Id='{ProductId}'";
                        var command = new SqlCommand(query,connection);
                        command.Parameters.Add("@ProdcuctId",(System.Data.SqlDbType)ProductId);
                        command.ExecuteNonQuery();
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case Choice.Insert:
                    Console.Write("Enter Product's name: "); string productName = Console.ReadLine();
                    Console.Write("Enter Product's quantity: "); int quantity = int.Parse(Console.ReadLine());
                    Console.Write("Enter Product's price: "); SqlMoney price = SqlMoney.Parse(Console.ReadLine());
                    using (var connection = new SqlConnection(connectionString))
                    { using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "INSERT INTO WareHouse(ProductName,Quantity,PRICE)  " +
                                                   "VALUES(@name,@quantity,@price)";

                            command.Parameters.AddWithValue("@name", productName);
                            command.Parameters.AddWithValue("@quantity", quantity);
                            command.Parameters.AddWithValue("@price", price);

                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                        } 
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }


    static void ShowData()
    {
        var connectionString = @"Data Source=WIN-NK524IJNHU6;Initial Catalog=SportsShop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        List<WareHouse> ProductList = new List<WareHouse>();
        using (var connection = new SqlConnection(connectionString)) { 
        connection.Open();
        var query = @"SELECT*
                      FROM WareHouse";
        var cmd = new SqlCommand(query, connection);
        var reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                var warehouse = new WareHouse();
                var id = reader.GetInt32(0);
                var productname = reader.GetString(1);
                var quantity = reader.GetInt32(2);
                var price = reader.GetSqlMoney(3);

                warehouse.Id = id;
                warehouse.ProductName = productname;
                warehouse.Quantity = quantity;
                warehouse.PRICE = price;

                ProductList.Add(warehouse);
            }
        }
        foreach (var warehouse in ProductList)
        {
            Console.WriteLine(warehouse);
        }
        }

    }

   
}
