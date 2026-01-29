using System;
namespace Com.Wipro.Crime.Bean
{
public class CrimeBean
{
private int crimeID;
private string crimeType = &quot;&quot;;
private string location = &quot;&quot;;
private DateTime crimeDate;
public int CrimeID
{
get { return crimeID; }
set { crimeID = value; }
}
public string CrimeType
{
get { return crimeType; }
set { crimeType = value; }
}
public string Location
{
get { return location; }
set { location = value; }
}
public DateTime CrimeDate
{
get { return crimeDate; }
set { crimeDate = value; }
}
}
}
