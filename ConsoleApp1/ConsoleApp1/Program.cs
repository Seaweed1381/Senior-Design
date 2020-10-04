using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text.Encodings.Web;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Sequential a = new Sequential(new List<double> { 1, 2, 3, 4, 5 });
            a.Add(5,2);
            a.Add(6,1);
            a.Add(4,0);
            a.Add(10909, 2);

            a.PrintBias();
            a.PrintWeights();

            a.SaveModel("Test2");
        }

    }
}
