using System;
using System.IO;
using HtmlAgilityPack;
using System.Text;
//convert to csv
//convert from csv to other3
 class tabconv
    {
        static void Main()
        {
            //path to temp folder
            string path = @"/home/raikchu9/264/tabconv/temp/test.csv";

           string json = "/home/raikchu9/264/tabconv/temp/test.json";


        if (File.Exists(json))
        {
           File.Delete(json);
          // Console.WriteLine("DEL");
        }

          

            CSVtoJSON(path);
            
        
        }

        
         static void CSVtoJSON (string path)
            {

            string JSONFile = Path.ChangeExtension(path, ".json");
            File.WriteAllText(JSONFile, " ");
            //List<String> LinesList = new List<String>();
             String[,] content = new String[20, 20];
             int count = 0;
            try{
            using (StreamReader sr = new StreamReader(path))
            {
                //l gets line and is used to check when it has reached end of file
                 String l;
                 //get first line for repeated use
                 String[] headers = sr.ReadLine().Split(',');
                while((l = sr.ReadLine()) != null)
                {
                    //l is split into an array of each word
                    String[] line = l.Split(',');
                    for(int i = 0; i < line.Length; i++)
                    {
                    content[count, i] = line[i];
                   // Console.Write(content[count, i] + ", ");
                    }
               // Console.WriteLine();

                count++;
                }
            }
            }
                catch (NullReferenceException)  
                {  
                    Console.WriteLine("NULL");  
                } 
            

            //String[] Lines = LinesList.ToArray();
            

            
            using (StreamWriter sw = new StreamWriter(JSONFile))
            {
            sw.WriteLine("[");
            for(int i = 0; i <= count; i++)
            {
            sw.WriteLine("{");
                
                int innercount = 0;
                while(content[i,innercount] != null)
                {
                    sw.WriteLine(content[i,innercount]);
                    Console.WriteLine(content[i,innercount]);
                    innercount++;
                }
            sw.WriteLine("}");

            }
            sw.WriteLine("]");

            }
            }
}





/* using (FileStream fs = File.OpenRead(path))
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b,0,b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }
        }
        using (FileStream fs = File.OpenRead(newfile))
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);

            while (fs.Read(b,0,b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }
        }
        */