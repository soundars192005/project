using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Com.Wipro.Crime.Bean;
using Com.Wipro.Crime.Util;
namespace Com.Wipro.Crime.Dao
{
public class CrimeDAO
{
public int generateSequenceNumber()
{
return new Random().Next(1000, 9999);
}
public bool registerCrime(CrimeBean crimeBean)
{

SqlConnection con = DBUtil.GetDBConnection();
string query = &quot;INSERT INTO CRIME_TBL VALUES (@id,@type,@loc,@date)&quot;;
SqlCommand cmd = new SqlCommand(query, con);
cmd.Parameters.AddWithValue(&quot;@id&quot;, generateSequenceNumber());
cmd.Parameters.AddWithValue(&quot;@type&quot;, crimeBean.CrimeType);
cmd.Parameters.AddWithValue(&quot;@loc&quot;, crimeBean.Location);
cmd.Parameters.AddWithValue(&quot;@date&quot;, DateTime.Now);
con.Open();
int rows = cmd.ExecuteNonQuery();
con.Close();
return rows &gt; 0;
}
public bool validateCrime(int crimeID)
{
SqlConnection con = DBUtil.GetDBConnection();
SqlCommand cmd = new SqlCommand(
&quot;SELECT COUNT(*) FROM CRIME_TBL WHERE Crime_ID=@id&quot;, con);
cmd.Parameters.AddWithValue(&quot;@id&quot;, crimeID);
con.Open();
int count = (int)cmd.ExecuteScalar();
con.Close();
return count &gt; 0;
}
public CrimeBean viewCrime(int crimeID)
{
SqlConnection con = DBUtil.GetDBConnection();
SqlCommand cmd = new SqlCommand(
&quot;SELECT * FROM CRIME_TBL WHERE Crime_ID=@id&quot;, con);
cmd.Parameters.AddWithValue(&quot;@id&quot;, crimeID);
con.Open();
SqlDataReader dr = cmd.ExecuteReader();
CrimeBean crime = null;
if (dr.Read())
{
crime = new CrimeBean();
crime.CrimeID = (int)dr[&quot;Crime_ID&quot;];
crime.CrimeType = dr[&quot;Crime_Type&quot;].ToString();
crime.Location = dr[&quot;Location&quot;].ToString();
crime.CrimeDate = Convert.ToDateTime(dr[&quot;Crime_Date&quot;]);
}
con.Close();
return crime;
}
}
}
