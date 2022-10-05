using System;
using System.IO;
using HtmlAgilityPack;
using System.Text;
using System.Linq;

public class table
{
    public int numRows { get; }
    public int numCols { get; }
    public string[,] myTable;

    

    public table(int numRows, int numCols,string[,] data)
    {
        this.numRows = numRows;
        this.numCols = numCols;
        myTable = new string[numRows,numCols];

        

        for(int i = 0; i < numRows; i++)
        {
            for(int j = 0; j< numCols; j++)
            {

            myTable[i,j] = data[i,j];
           // Console.WriteLine(myTable[i,j]);
            }
        }
    }
        public void printTable()
        {
            for(int i = 0; i < numRows; i++)
        {
            for(int j = 0; j< numCols; j++)
            {
                Console.Write(myTable[i,j] + " ");
            }
                            Console.WriteLine();

        }
        }





 class tabconv
    {
        static void Main()
        {
            //path to temp folder
        string path = @"/home/raikchu9/264/tabconv/temp/test.csv";
        string json = @"/home/raikchu9/264/tabconv/temp/test.json";
        string html = @"/home/raikchu9/264/tabconv/temp/test.html";
        string md = @"/home/raikchu9/264/tabconv/temp/test.md";


        if (File.Exists(json))
        {
           File.Delete(json);
        }
         if (File.Exists(html))
        {
           File.Delete(html);
        }
        if (File.Exists(md))
        {
           File.Delete(md);
        }
           MakeCSVTable(path);
        }



        public static void MakeCSVTable(string path)
        {
            String[,] Data = new String[200, 200];
            String[] headers;
            int cols = 0;
            int count = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                //l gets line and is used to check when it has reached end of file
                 String l;

                //get first line for repeated use
                while((l = sr.ReadLine()) != null)
                {
                    //l is split into an array of each word
                    String[] line = l.Split(',');
                    cols = line.Length;
                    for(int i = 0; i < line.Length; i++)
                    {
                    Data[count, i] = line[i];
                    }

                count++;
                }

            }

            table CSVTable = new table(count,cols,Data);
            CSVTable.printTable();

        }


         public static void MakeJSONTable(string path)
        {
            String[,] Data = new String[200, 200];
            String[] headers;
            int cols = 0;
            int count = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                //l gets line and is used to check when it has reached end of file
                 String l;

                while((l = sr.ReadLine()) != null)
                {

                    
                }

            }

            table JSONTable = new table(count,cols,Data);
            JSONTable.printTable();

        }
    }



}

