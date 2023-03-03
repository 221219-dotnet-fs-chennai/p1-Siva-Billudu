// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
//.......1.Remove vowels..
/*class Solution
{
public static void Main(string[] args)
{
string s = "helloworld";
string r = " ";
char[] ch = { 'a', 'e', 'i', 'o', 'u' };
foreach (char c in ch)
{

s= s.Replace(c, ' ');



}
Console.WriteLine(s);

}
}*/
//......2.IP..
/*class Solution
{
    

    public static void Main(string[] args)
    {
        string s=Console.ReadLine();
        
        string l = " ";
        l = s.Replace(".", "[.]");
        Console.WriteLine(l);

    }
}*/
//...3.Balanced string
/*class Solution
{
    public static void Main(string[] args)
    {
        string s = "LRLLRRLRRLLR";
        int lcount = 0;
        int rcount = 0;
        for(int i=0; i<s.Length; i++)
        {
            if (s[i] == 'L')
            {
                lcount++;
            }
            if (s[i] == 'R')
            {
                rcount++;
            }
        }
        if(lcount %2 ==1)
        {
            Console.WriteLine(lcount-1);
        }
        else
        {
            Console.WriteLine(lcount);
        }
    }
}*/
//......4.Lower..
/*class Solution
{
    public static void Main(string[] args)
    {
        string s=Console.ReadLine();
        for(int i=0;i<s.Length;i++)
        {
            s=s.ToLower();
        }
        Console.WriteLine(s);

    }
}*/
//....5.Nonrepeating...
/*class Solution
{
    public static void Main(string[] args)
    {
        string s=Console.ReadLine();
        int count = 0;
        for (int j = 0; j < s.Length; j++)
        {
            if (!s.Contains((char)j))
            {
                s.Add(j);
            }
          



            if (count == 0)
                Console.WriteLine(j);
        }
    }
}*/
//.....6.anagram...
/*class Solution
{
    public static void Main(string[] args)
    {
        string s=Console.ReadLine();
        string t=Console.ReadLine();
        int c = 0;
        List<char> slist = new List<char>();
        List<char> tlist = new List<char>();
        foreach(var l  in slist)
        {
            if (tlist.Contains(l))
            {
                c++;
            }
        }
        if(c==tlist.Count)
        {
            Console.WriteLine("true");

        }
        else
        {
            Console.WriteLine("false");
        }
        
    }
}*/
//...1.Merge..
/*class Solution
{
    public static void Main(string[] args)
    {
        
        int[] a1 = new int[] {2,4,3,9};
        int[] a2 = new int[] {1,5,8,7};
        int[] a3=a1.Concat(a2).ToArray();
        Array.Sort(a3);
        for(int i=0;i<a3.Length; i++)
        {
            Console.WriteLine(a3[i]);
        }
       
        
    }
}*/
//....2.Remove  dupliactes..
/*class Solution
{
    public static void Main(string[] args)
    {
        List<int> list = new List<int>();
        int[] arr = new int[] { 4, 8, 2, 1, 1, 4, 2, 3, 9, 7 };
       Array.Sort(arr);
        //int[] siva=arr.Distinct.ToArray();
        foreach (int i in arr)
        {
            if (!list.Contains(i))
            {
                list.Add(i);
            }
        }
        var nlist = list.ToArray();
        for(int j=0; j<nlist.Length; j++)
        {
            Console.WriteLine(nlist[j]);
        }

       
    }
}*/
//.....3.Frequency
/*public class Frequency
{
    public static void Main(string[] args)
    {
           
        int[] arr = new int[] { 1, 2, 8, 3, 2, 2, 2, 5, 1 };
         
        int[] fr = new int[arr.Length];
        int v = -1;

        for (int i = 0; i < arr.Length; i++)
        {
            int count = 1;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[i] == arr[j])
                {
                    count++;
                     
                    fr[j] = v;
                }
            }
            if (fr[i] != v)
                fr[i] = count;
        }

        Console.WriteLine(" Element | Frequency");
        
        for (int i = 0; i < fr.Length; i++)
        {
            if (fr[i] != v)
                Console.WriteLine("    " + arr[i] + "    |    " + fr[i]);
        }
       
    }
}*/
//...4.Return indices..
/*class Solution
{
    public static void Main(string[] args)
    {
        int sum = 14;
        
           
        int[] arr = new int[] { 1,4,10,-3};
        int i;
        int j;
        for(i=0;i< arr.Length;i++)
        {
            for (j = i+1; j < arr.Length; j++)
            {
                
                
                    if ((arr[i] + arr[j]) == sum)
                    {
                     Console.WriteLine(i+" "+j);
                    Console.Write(j + " " + i);


                }
                
            }
        }
        
        
        
    }
}*/
//....5.MIN AND MAX..
/*class Solution
{
    public static void Main(string[] args)
    {
        
        int[] arr = new int[] { 1, 2, 3,9,7 };
        int MaxValue = arr[0];
        int MinValue = arr[0];
        for (int i=0;i<arr.Length; i++)
        {
            if (arr[i]>MaxValue)
            {
                MaxValue = arr[i];
            }
            if (arr[i] < MinValue)
            {
                MinValue = arr[i];
            }
        }
        Console.WriteLine(MaxValue.ToString());
        Console.WriteLine(MinValue.ToString());
    }
}*/
//....6.Find index..
/*class Solution
{
    public static void Main(string[] args)
    {
        int[] arr = new int[] { 1, 5, 4,2,9 };
        int k = 4;
        for(int i=0; i<arr.Length; i++)
        {
            if (arr[i] == k)
            {
                Console.WriteLine(i);
            }
        }
    }
}*/
//...7.Find 3rd largest..
/*class Solution
{
    public static void Main(string[] args)
    {
        int[] arr = new int[] { 3, 1, 9, 8, 5 };
        int n= arr.Length;
        Array.Sort(arr);
        Console.WriteLine(arr[n-3]);
    }
}*/
//...8.Rotate...
/*class Solution
{
    public static void Main(string[] args)
    {
        int[] arr = { 1, 4, 5, 6, 7, 8, 3, 9 };
        int d = 2;
        for(int i=2; i<arr.Length; i++)
        {
            Console.WriteLine(arr[i]);
        }
        for(int i=0;i<d; i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}*/
//...9.Find max Trilpelt product..
/*class Solution
{
    public static void Main(string[] args)
    {
        int[] arr = new int[] { 1, 4, 7,2,8 };
        int MaxProduct = 0;
        int x = 0, y = 0, z = 0;
        for(int i=0; i<arr.Length-2; i++)
        {
            for(int j=i+1;j<arr.Length-1;j++)
            {
                for(int k=j+1;k<arr.Length;k++)
                {
                   // MaxProduct += (arr[i] * arr[j] * arr[k]);
                    if ( (arr[i] * arr[j] * arr[k]) > MaxProduct)
                    {
                        MaxProduct +=( arr[i] * arr[j] * arr[k]);
                        x = arr[i]; y = arr[j]; z = arr[k];
                    }

                }
            }
        }

        Console.Write(x+" "+y+" "+z);
    }
}*/

