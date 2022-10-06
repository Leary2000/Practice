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

        //data is a 200x200 2d array so we want to use our new mytable array of the correct size
        for(int i = 0; i < numRows; i++)
            for(int j = 0; j< numCols; j++)
            myTable[i,j] = data[i,j];
            
        
    }

    public String[,] getTable()
    {
        return myTable;
    }
        public void printTable()
        {
            Console.WriteLine(numCols);
            for(int i = 0; i < numRows; i++)
        {
            for(int j = 0; j< numCols; j++)
            {
                Console.Write(myTable[i,j] + " ");
            }
            Console.WriteLine();

        }
        }
}



 class tabconv
    {
        public static void Main(String[] args)
        {

            bool verbose = false;
            string path = "";
            string newPath = "";
            
            String command = Console.ReadLine();

            //splits into an array
            string[] l = command.Split(' ');

            //checks if first word is tabconv
            if(l[0] == "tabconv")
            {
                if(command.Contains("-v"))
                verbose = true;

                if(command.Contains("-l"))
                list();

                if(command.Contains("-h"))
                help();

                if(command.Contains("-i"))
                info();


            
            if(command.Contains("-o"))
            {
                //get the paths from before and after -o
                string[] arr = l[l.Length - 3].Split('.');
                string extension = arr[1];

                arr = l[l.Length - 1].Split('.');
                string NewExtension = arr[1];


                //file must be in your MyApp folder
                path = @"C:\Users\User\js\264\MyApp\" + l[l.Length - 3];
                newPath = @"C:\Users\User\js\264\MyApp\" + l[l.Length - 1];

                //string array just used to make the tuple
                string[,] empty = new string[ 1, 0 ];

                //tuple used to store the data returned from the Make___Table methods
                var tuple = (0,0,empty);

            if(verbose == true)
            Console.WriteLine("Extracting data from " + extension + " file");
            
            //creating table oject from our different methods
            switch (extension) 
            {
            case "csv":
            tuple = (MakeCSVTable(path).Item1,MakeCSVTable(path).Item2,MakeCSVTable(path).Item3);
               break;
            case "html": 
            tuple = (MakeHTMLTable(path).Item1,MakeHTMLTable(path).Item2,MakeHTMLTable(path).Item3);
               break;
            case "md" :
            tuple = (MakeMDTable(path).Item1,MakeMDTable(path).Item2,MakeMDTable(path).Item3);
               break;
            case "json" :
            tuple = (MakeJSONTable(path).Item1,MakeJSONTable(path).Item2,MakeJSONTable(path).Item3);
               break;
            }


            if(verbose == true)
            Console.WriteLine("Making table");
            
            //using the tuple we make our table object
            table myTable = new table(tuple.Item1,tuple.Item2,tuple.Item3);

            //myTable.printTable();
            

            if(verbose == true)
            Console.WriteLine("Creating " + NewExtension + " file");
            
            //use our table object to pass data into our methods for creating the new file
             switch (NewExtension) 
            {
            case "csv":
            toCSV(myTable.numRows,myTable.numCols,myTable.getTable(),newPath);
               break;
            case "html": 
            toHTML(myTable.numRows,myTable.numCols,myTable.getTable(),newPath);
               break;
            case "md" :
            toMD(myTable.numRows,myTable.numCols,myTable.getTable(),newPath);
               break;
            case "json" :
            toJSON(myTable.numRows,myTable.numCols,myTable.getTable(),newPath);
               break;
            }

            if(verbose == true)
            Console.WriteLine("Completed");
            }
            
            }
            
            else
            {
                Console.WriteLine("Please check your input and try again");
            }
            
        
            
       

        }

            static void list()
            {
                Console.WriteLine("Formats: CSV, HTML, MD and JSON");
            }
            static void info()
            {
                Console.WriteLine("Tabvonv version 1.3");
            }

            static void help()
            {
            }


        static void toJSON(int rows, int cols, string[,] data, string path)
        {
            string JSONFile = Path.ChangeExtension(path, ".json");
            File.WriteAllText(JSONFile, " ");
           using (StreamWriter sw = new StreamWriter(JSONFile))
            {
            sw.WriteLine("[");

            for(int i = 1; i < rows; i++)
            {
            sw.WriteLine("  {");

                for(int j = 0; j < cols ;j++)
                {
                    if(j != cols -1) 
                    sw.WriteLine("      " + data[0,j] + ": " + data[i,j] + ",");


                    else
                    sw.WriteLine("      " + data[0,j] + ": " + data[i,j]);                    
                }
            if( i != rows - 1)
            sw.WriteLine("  },");

            else
            sw.WriteLine("  }");

            }
            sw.WriteLine("]");
            }
        }

        static void toMD(int rows, int cols, string[,] data, string path)
        {

            string MDFile = Path.ChangeExtension(path, ".md");
            File.WriteAllText(MDFile, " ");
          using (StreamWriter sw = new StreamWriter(MDFile))
            {

            String line = "|";
            for(int i = 0; i < rows; i++)
            {
                line = "|";

                for(int j = 0; j < cols; j++)
                {
                  line = line + data[i,j] + " | ";

                }

                sw.WriteLine(line);

                if(i == 0)
                {
                line = "|";
                for(int j = 0; j < cols; j++)
                {
                  line = line + "----|";

                }
                sw.WriteLine(line);

                }
               
            }
            }
        }

        static void toCSV(int rows, int cols, string[,] data, string path)
        {

            string CSVFile = Path.ChangeExtension(path, ".csv");
            File.WriteAllText(CSVFile, " ");
          using (StreamWriter sw = new StreamWriter(CSVFile))
            {

            //String line = "";
            for(int i = 0; i < rows; i++)
            {
            String line = "";

                for(int j = 0; j < cols; j++)
                {
                    if(j == cols -1)
                  line = line + "" + data[i,j] ;

                    else
                  line = line + "" + data[i,j] + ",";

                }

                sw.WriteLine(line);
  
            }
            }
        }

        static void toHTML(int rows, int cols, string[,] data, string path)
        {
            int test = cols;
            string HTMLFile = Path.ChangeExtension(path, ".html");
            File.WriteAllText(HTMLFile, " ");
            using (StreamWriter sw = new StreamWriter(HTMLFile))
            {
            sw.WriteLine("<table>");

            sw.WriteLine("  <tr>");

             for(int k = 0; k < cols; k++)
                    {
                    sw.WriteLine("     <th>" + data[0,k] + " </th>");
                    }
            sw.WriteLine("  </tr>");


            for(int i = 1; i < rows; i++)
            {
            sw.WriteLine("  <tr>");

                for(int k = 0; k < cols; k++)
                {     
                    sw.WriteLine("     <td>" + data[i,k] + " </td>");
                }
            sw.WriteLine("  </tr>");
            }
            sw.WriteLine("</table>");
            }
            }
    
        

         static Tuple<int,int,string[,]> MakeCSVTable(string path)
        {
            String[,] Data = new String[200, 200];
            int cols = 0;
            int rows = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                //l gets line and is used to check when it has reached end of file
                 String l;

                while((l = sr.ReadLine()) != null)
                {
                    //l is split into an array of each word
                    String[] line = l.Split(',');
                    cols = line.Length;
                    for(int i = 0; i < line.Length; i++)
                    {
                    Data[rows, i] = line[i];
                    }

                rows++;
                }

            }

            return new Tuple <int,int,string[,] > (rows,cols,Data);


        }


          static Tuple<int,int,string[,]> MakeJSONTable(string path)
        {
            String[,] Data = new String[200, 200];
            int cols = 0;
            int rows = 1;



            //this Streamreader gets the number of columns by calculating the number of lines between { and }
             using (StreamReader getCols = new StreamReader(path))
            {
                string l;
                bool run = true;
                 while((l = getCols.ReadLine()) != null & run == true)
                {
                  
                  if( l.Contains("{"))
                   {
                    //start counting from -1 to not include this line
                    cols =-1;
                   }
                     else if( l.Contains("}"))
                   {
                    //stop running and decrease cols by 1 to not include this line
                    cols--;
                    run = false;
                   }

                   //another column is added
                   cols++;
                
                }

            }
        

            using (StreamReader sr = new StreamReader(path))
            {
                int innercount = 0;
                string l;
            while((l = sr.ReadLine()) != null)
            {

                    //skip the non data lines
                   if((l.Contains("[") | l.Contains("]") | l.Contains("{") | l.Contains("}")) == false)
                   {
                   //split into header and data
                    String[] line = l.Split(':');

                    //save header in first row
                    
                    Data[0,innercount] = line[0];

                    //save rest in other rows
                    Data[rows,innercount] = line[1];

                    //next column
                    innercount++;
                   }
                   else
                   {
                    continue;
                   }
                
                //if you have reached end of column reset to column 0 and move to next row
                if(innercount == cols)
                {
                innercount = 0;
                rows++;
                }
            }
            }

                return new Tuple <int,int,string[,] > (rows,cols,Data);
        }


        static Tuple<int,int,string[,]> MakeHTMLTable(string path)
        {
             String[,] Data = new String[200, 200];
            int cols = 0;
            int rows = 0;



            //this Streamreader gets the number of columns by calculating the number of lines between { and }
             using (StreamReader getCols = new StreamReader(path))
            {
                string l;
                bool run = true;
                 while((l = getCols.ReadLine()) != null)
                {
                  
                  if( l.Contains("<tr>"))
                   {
                    //start counting from -1 to not include this line
                    cols = 0;
                   }
                     else if( l.Contains("</tr>"))
                     {
                    //stop running and decrease cols by 1 to not include this line
                    cols--;

                    break;
                   }
                cols++;
                }

                
            }

            using (StreamReader sr = new StreamReader(path))
            {
                int innercount = 0;
                string l;
            while((l = sr.ReadLine()) != null)
            {
                    
                    //skip the non data lines
                   if((l.Contains("<table>") | l.Contains("</table>") | l.Contains("<tr>") | l.Contains("</tr>")) == false)
                   {
                   //get data from the div tags
                    String[] line = l.Split(">");
                    String[] line2 = line[1].Split("<");
                    Data[rows,innercount] = line2[0];
                    //next column
                    innercount++;
                   }
                   else
                   {
                    continue;
                   }
                
                //if you have reached end of column reset to column 0 and move to next row
                if(innercount == cols)
                {
                innercount = 0;
                rows++;
                }
               
            }
        }
        
        return new Tuple <int,int,string[,] > (rows,cols,Data);
   }


        static Tuple<int,int,string[,]> MakeMDTable(string path)
        {
               String[,] Data = new String[200, 200];
            int cols = 0;
            int rows = 0;

            using (StreamReader sr = new StreamReader(path))
            {
                //l gets line and is used to check when it has reached end of file
                 String l;

                while((l = sr.ReadLine()) != null)
                {
                    //skip this line
                    if(l.Contains("-|-"))
                    continue;
                    
                    String[] line = l.Split("|");

                    for(int i = 1 ; i < line.Length; i++)
                    {
                    Data[rows,i] = line[i];
                    
                    }

                    if(rows == 0)
                    cols = line.Length - 1;

                     
                    rows++;
                    
                    }

            }

            return new Tuple <int,int,string[,] > (rows,cols,Data);


   }
 }
ng System;
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

