using Microsoft.Data.SqlClient;
namespace Com.Wipro.Crime.Util
{
public class DBUtil

{
public static SqlConnection GetDBConnection()
{
return new SqlConnection(
&quot;Data Source=.;Initial Catalog=CrimeDB;Integrated Security=True&quot;
);
}
}
}
