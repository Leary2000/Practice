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
            string path = @"C:\Users\User\js\264\MyApp\test.csv";

           string json = @"C:\Users\User\js\264\MyApp\test.json";
           string html = @"C:\Users\User\js\264\MyApp\test.html";
           string md = @"C:\Users\User\js\264\MyApp\test.md";


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
          

            CSVtoJSON(path);
            CSVtoHTML(path);
            CSVtoMD(path);


            
        
        }

        
         static void CSVtoJSON (string path)
            {

            string JSONFile = Path.ChangeExtension(path, ".json");
            File.WriteAllText(JSONFile, " ");

            String[,] content = new String[20, 20];
            String[] headers = new String[20];
            int count = 0;

    try{
            using (StreamReader sr = new StreamReader(path))
            {
                //l gets line and is used to check when it has reached end of file
                 String l;

                //get first line for repeated use
                headers = sr.ReadLine().Split(',');

                while((l = sr.ReadLine()) != null)
                {
                    //l is split into an array of each word
                    String[] line = l.Split(',');
                    for(int i = 0; i < line.Length; i++)
                    {
                    content[count, i] = line[i];
                    }

                count++;
                }
            }
        }
                catch (NullReferenceException)  
                {  
                    Console.WriteLine("NULL");  
                } 
            

            
            //write data into json file
            using (StreamWriter sw = new StreamWriter(JSONFile))
            {
            sw.WriteLine("[");
            
           
            for(int i = 0; i < count; i++)
            {
            sw.WriteLine("  {");
                
                int innercount = 0;
                while(content[i,innercount] != null)
                {
                    if(content[i,innercount + 1] != null)
                    {
                    sw.WriteLine("      " + headers[innercount] + ": " + content[i,innercount] + ",");
                    innercount++;
                    }
                    //see if its last so dont add a comma
                    else
                    {
                        sw.WriteLine("      " + headers[innercount] + ": " + content[i,innercount]);
                    innercount++;
                    }
                }
            sw.WriteLine("  },");
            }
            sw.WriteLine("]");
            }
            }


            static void CSVtoHTML (string path)
            {

            string HTMLFile = Path.ChangeExtension(path, ".html");
            File.WriteAllText(HTMLFile, " ");
             String[,] content = new String[20, 20];
             String[] headers = new String[20];
             int count = 0;
            try{
            using (StreamReader sr = new StreamReader(path))
            {
                //l gets line and is used to check when it has reached end of file
                 String l;
                 //get first line for repeated use
                 headers = sr.ReadLine().Split(',');
                while((l = sr.ReadLine()) != null)
                {
                    //l is split into an array of each word
                    String[] line = l.Split(',');
                    for(int i = 0; i < line.Length; i++)
                    {
                    content[count, i] = line[i];
                    }

                count++;
                }
            }
            }
                catch (NullReferenceException)  
                {  
                    Console.WriteLine("NULL");  
                } 
            

            
            //write data into html file
            using (StreamWriter sw = new StreamWriter(HTMLFile))
            {
            sw.WriteLine("<table>");
            
            sw.WriteLine("  <tr>");

             for(int k = 0; k < count; k++)
                    {
                    sw.WriteLine("     <th>" + headers[k] + " </th>");
                    }
            sw.WriteLine("  <tr>");


            for(int i = 0; i < count; i++)
            {
            sw.WriteLine("  <tr>");
                int innercount = 0;

                
                while(content[i,innercount] != null)
                {     
                   
                    
                    sw.WriteLine("     <td>" + content[i,innercount] + " </td>");
                    
                    innercount++;

                }
            sw.WriteLine("  <tr>");
            }
            sw.WriteLine("</table>");
            }
            }

            static void CSVtoMD (string path)
            {

            string MDFile = Path.ChangeExtension(path, ".md");
            File.WriteAllText(MDFile, " ");
             String[,] content = new String[20, 20];
             String[] headers = new String[20];
             int count = 0;
            try{
            using (StreamReader sr = new StreamReader(path))
            {
                //l gets line and is used to check when it has reached end of file
                 String l;
                 //get first line for repeated use
                 headers = sr.ReadLine().Split(',');
                while((l = sr.ReadLine()) != null)
                {
                    //l is split into an array of each word
                    String[] line = l.Split(',');
                    for(int i = 0; i < line.Length; i++)
                    {
                    content[count, i] = line[i];
                    }

                count++;
                }
            }
            }
                catch (NullReferenceException)  
                {  
                    Console.WriteLine("NULL");  
                } 
            

            
            //write data into MD file
            using (StreamWriter sw = new StreamWriter(MDFile))
            {
                
                String line = "|";

                for(int k = 0; k < count; k++)
                    {
                  line = line + headers[k] + " | ";
                    }
                sw.WriteLine(line);
                sw.WriteLine("|----------------------------------------|");


            for(int i = 0; i < count; i++)
            {
                int innercount = 0;
                line = "|";
               // Console.WriteLine(line);

                while(content[i,innercount] != null)
                {     
                  line = line + content[i,innercount] + " | ";
                  innercount++;
                    
                }
                sw.WriteLine(line);
               // Console.WriteLine(line);
            }
            }
            }


            static void JSONtoCSV (string path)
            {

            string CSVFile = Path.ChangeExtension(path, ".md");
            File.WriteAllText(CSVFile, " ");
             String[,] content = new String[20, 20];
             String[] headers = new String[20];
             int count = 0;
            try{
            using (StreamReader sr = new StreamReader(path))
            {
               String l;
                 
                while((l = sr.ReadLine()) != null)
                {
                }
            }
            }
                catch (NullReferenceException)  
                {  
                    Console.WriteLine("NULL");  
                } 
            

            
            //write data into MD file
            using (StreamWriter sw = new StreamWriter(CSVFile))
            {
                
                String line = "|";

                for(int k = 0; k < count; k++)
                    {
                  line = line + headers[k] + " | ";
                    }
                sw.WriteLine(line);
                sw.WriteLine("|----------------------------------------|");


            for(int i = 0; i < count; i++)
            {
                int innercount = 0;
                line = "|";
               // Console.WriteLine(line);

                while(content[i,innercount] != null)
                {     
                  line = line + content[i,innercount] + " | ";
                  innercount++;
                    
                }
                sw.WriteLine(line);
               // Console.WriteLine(line);
            }
            }
            }



}




