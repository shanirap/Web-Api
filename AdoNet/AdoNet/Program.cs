using AdoNet;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;

internal class Program
{

    static public void InsertCatrogy()
    {
        SqlManagement sqlManagement = new SqlManagement("Data Source=SRV2\\PUPILS;Initial Catalog=elishevaDB;Integrated Security=True");
        bool flag = true;
        do
        { 
        Console.WriteLine("insert category name");
        string input = Console.ReadLine();
        Console.WriteLine(sqlManagement.InsertCatrogy(input));
            Console.WriteLine("continue? y/n");
            char answer = char.Parse(Console.ReadLine());
            flag = answer == 'y' ? true : false;
        } while (flag);

    }

    static public void InsertProduct()
    {
        SqlManagement sqlManagement = new SqlManagement("Data Source=SRV2\\PUPILS;Initial Catalog=elishevaDB;Integrated Security=True");
        bool flag = true;
        do
        {
            Console.WriteLine("insert category ID");
            int categoryID = Int32.Parse(Console.ReadLine());
            Console.WriteLine("insert product name");
            string productname = Console.ReadLine();
            Console.WriteLine("insert product description");
            string description = Console.ReadLine();
            Console.WriteLine("insert product price");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("insert image path");
            string imagepath = Console.ReadLine();
            Console.WriteLine("continue? y/n");
            char answer = char.Parse(Console.ReadLine());
            flag = answer == 'y' ? true : false;
            Console.WriteLine(sqlManagement.InsertProduct(categoryID, productname, description, price, imagepath));
        } while (flag);
    }
    static public void readTable()
    {
        SqlManagement sqlManagement = new SqlManagement("Data Source=SRV2\\PUPILS;Initial Catalog=elishevaDB;Integrated Security=True");
        
            Console.WriteLine("insert table name");
            string tableName = Console.ReadLine();
            sqlManagement.readTable(tableName);
           
    }

    static public void Process()
    {
        Console.WriteLine("to print table insert t, to insert data to categories insert c, to insert data to products insert p");
        char answer = char.Parse(Console.ReadLine());
        switch (answer)
        {
            case 't':
                readTable();
                break;
            case 'c':
                InsertCatrogy();
                break;
            case 'p':
                InsertProduct();
                break;
            default:
                break;
        }
    }
    private static void Main(string[] args)
    {
        string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=elishevaDB;Integrated Security=True;Trust Server Certificate=True";
        //InsertProduct();
        Process();
    }      
    }
