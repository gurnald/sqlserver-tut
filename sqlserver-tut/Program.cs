using Microsoft.Data.SqlClient;


string connectionString = "server=localhost\\sqlexpress;" +
                            "database=SalesDb;" +
                            "trusted_connection=true;" +
                            "trustServerCertificate=true;";

SqlConnection sqlConn = new SqlConnection(connectionString);

sqlConn.Open();

if(sqlConn.State != System.Data.ConnectionState.Open) {
    throw new Exception("I Screwed up my connection string!");
}
Console.WriteLine("Connection Opened Succesfully!");

string sql = "SELECT * from Customers order by sales desc;";

SqlCommand cmd = new SqlCommand(sql, sqlConn);

SqlDataReader reader = cmd.ExecuteReader();

while(reader.Read()) {
    var id = Convert.ToInt32(reader["Id"]);
    var name = Convert.ToString(reader["Name"]); 
    var city = Convert.ToString(reader["City"]); 
    var state = Convert.ToString(reader["State"]); 
    var sales = Convert.ToDecimal(reader["Sales"]); 
    var active = Convert.ToBoolean(reader["Active"]);
    Console.WriteLine($"{id} | {name} | {city}, {state} | {sales} | {(active ? "Yes" : "No")}");
}

reader.Close();

sql = "SELECT * from Orders;";

cmd = new SqlCommand();

reader = cmd.ExecuteReader();

while (reader.Read()) {
    var id = Convert.ToInt32(reader["Id"]);
    var customerid = (reader["CustomerId"].Equals(System.DBNull.Value))
                               ? (int?)null
                               : Convert.ToInt32(reader["CustomerID"]);
    var date = Convert.ToDateTime(reader["Date"]);
    var description = Convert.ToString(reader["Description"]);
}
sqlConn.Close();