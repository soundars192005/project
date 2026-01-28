using System;
using Com.Wipro.Crime.Bean;
using Com.Wipro.Crime.Dao;
namespace Com.Wipro.Crime.Service
{
public class CrimeMain
{
CrimeDAO dao = new CrimeDAO();
public string viewCrimeDetails(int crimeID)
{
if (dao.validateCrime(crimeID))
return &quot;CRIME DETAILS FOUND&quot;;

return &quot;CRIME NOT FOUND&quot;;
}
public string register(CrimeBean crimeBean)
{
if (crimeBean == null)
return &quot;INVALID&quot;;
if (crimeBean.CrimeType == null || crimeBean.Location == null)
return &quot;INVALID DETAILS&quot;;
return dao.registerCrime(crimeBean) ? &quot;SUCCESS&quot; : &quot;FAILURE&quot;;
}
public static void Main(string[] args)
{
CrimeMain cm = new CrimeMain();
Console.WriteLine(&quot;Test Case 1: View Crime&quot;);
Console.WriteLine(cm.viewCrimeDetails(1001));
Console.WriteLine();
Console.WriteLine(&quot;Test Case 2: Register Crime&quot;);
CrimeBean c1 = new CrimeBean();
c1.CrimeType = &quot;Assault&quot;;
c1.Location = &quot;Madurai&quot;;
Console.WriteLine(cm.register(c1));
Console.WriteLine();
Console.WriteLine(&quot;Test Case 3: Invalid Crime ID&quot;);
Console.WriteLine(cm.viewCrimeDetails(9999));
Console.WriteLine();
Console.WriteLine(&quot;Test Case 4: Invalid Crime Details&quot;);
CrimeBean c2 = new CrimeBean();
c2.CrimeType = null;
c2.Location = &quot;Salem&quot;;
Console.WriteLine(cm.register(c2));
Console.WriteLine();
Console.WriteLine(&quot;Test Case 5: Null Crime Object&quot;);
Console.WriteLine(cm.register(null));
Console.ReadLine();
}
}
}
