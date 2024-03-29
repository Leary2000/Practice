using System;
    class SVGModels
    {
        static void Main ()
        {
            bool exit = false;
            //string canvas;
            List<object> canvas = new List<object>();
            canvas.Add("<svg viewBox= \"0 0 300 100\" xmlns= \"http://www.w3.org/2000/svg\" >");

            // viewBox="0 0 300 100" xmlns="http://www.w3.org/2000/svg"
            //start of canvas
            Console.Clear();

            while(exit == false)
            {

            Console.WriteLine("1) Create Circle");
            Console.WriteLine("2) Create Square");
            Console.WriteLine("3) Create Ellipse");
            Console.WriteLine("4) Create Line");
            Console.WriteLine("5) Create PolyLine");
            Console.WriteLine("6) Create Polygon");
            Console.WriteLine("7) Create Path");
            Console.WriteLine("8) Update Style");
            Console.WriteLine("9) Update SVG");
            Console.WriteLine("10) Swap Elements");
            Console.WriteLine("11) Delete Element");
            Console.WriteLine("12) Exit");



            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                Console.Write("x: ");
                int x = int.Parse(Console.ReadLine());
                Console.Write("y: ");
                int y = int.Parse(Console.ReadLine());
                 Console.Write("r: ");
                int r = int.Parse(Console.ReadLine());
                Circle myCircle = new Circle(x,y,r);
                canvas.Add(myCircle.printShape());
                break;


                case 2:
                Console.Write("x: ");
                int squareX = int.Parse(Console.ReadLine());
                Console.Write("y: ");
                int squareY = int.Parse(Console.ReadLine());
                Console.Write("width: ");
                int squareWidth = int.Parse(Console.ReadLine());
                Console.Write("height: ");
                int squareHeigth = int.Parse(Console.ReadLine());
                Square mySquare = new Square(squareX,squareY,squareWidth,squareHeigth);
                canvas.Add(mySquare.printShape());
                break;

                case 3:
                Console.Write("x: ");
                int ellipseX = int.Parse(Console.ReadLine());
                Console.Write("y: ");
                int ellipseY = int.Parse(Console.ReadLine());
                Console.Write("rx: ");
                int ellipseRX = int.Parse(Console.ReadLine());
                Console.Write("ry: ");
                int ellipseRY = int.Parse(Console.ReadLine());
                Ellipse myEllipse = new Ellipse(ellipseX,ellipseY,ellipseRX,ellipseRY);
                canvas.Add(myEllipse.printShape());
                break;

                case 4:
                Console.Write("x1: ");
                int LineX1 = int.Parse(Console.ReadLine());
                Console.Write("y1: ");
                int LineY1 = int.Parse(Console.ReadLine());
                Console.Write("x2: ");
                int LineX2 = int.Parse(Console.ReadLine());
                Console.Write("y2: ");
                int LineY2 = int.Parse(Console.ReadLine());
                Line myLine = new Line(LineX1,LineY1,LineX2,LineY2);
                canvas.Add(myLine.printShape());
                createFile(canvas);
                break;

                case 5:
                Console.Write("x: ");
                int PolyLineX = int.Parse(Console.ReadLine());
                Console.WriteLine("print as \"1 2, 3 4, 5 6, 7 8, 9 10 \"");
                Console.Write("points: ");       
                string PolyLinePoints = (Console.ReadLine());
                Console.WriteLine("y: ");
                int PolyLineY = int.Parse(Console.ReadLine());
                PolyLine myPolyLine = new PolyLine(PolyLineX,PolyLinePoints,PolyLineY);
                canvas.Add(myPolyLine.printShape());
                createFile(canvas);
                break;

                 case 6:
                Console.Write("x: ");
                int PolygonX = int.Parse(Console.ReadLine());
                Console.WriteLine("print as \"1 2, 3 4, 5 6, 7 8, 9 10 \"");
                Console.Write("points: ");       
                string Polygonpoints = (Console.ReadLine());
                Console.WriteLine("y: ");
                int PolygonY = int.Parse(Console.ReadLine());
                Polygon myPolygon = new Polygon(PolygonX,Polygonpoints,PolygonY);
                canvas.Add(myPolygon.printShape());
                createFile(canvas);
                break;

                case 7:
                
                string PathPoints = (Console.ReadLine());
                Path myPath = new Path(PathPoints);
                canvas.Add(myPath.printShape());
                createFile(canvas);
                break;
                

                case 8:
                Console.WriteLine("Choose element to update.");
                for(int i = 1; i < canvas.Count; i ++)
                Console.WriteLine(i + " - " + canvas[i]);

                int update2 = int.Parse(Console.ReadLine());
                updateStyle(canvas,update2);
                break;

                case 9:
                Console.WriteLine("Choose element to update.");
                for(int i = 1; i < canvas.Count; i ++)
                Console.WriteLine(i + " - " + canvas[i]);
                int update = int.Parse(Console.ReadLine());
                updateSVG(canvas,update);
                break;

                case 10:
                for(int i = 1; i < canvas.Count; i ++)
                Console.WriteLine(i + " - " + canvas[i]);
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                swapElement(canvas,a,b);
                Console.WriteLine();
                break;

                case 11:
                Console.WriteLine("Select element to Delete:");
                for(int i = 1; i < canvas.Count; i ++)
                Console.WriteLine(i + " - " + canvas[i]);

                int delete = int.Parse(Console.ReadLine());
                if(delete != 0 | delete != canvas.Count)
                DeleteElement(canvas,delete);
                else
                Console.WriteLine("error, please try again");

                break;

                case 12:
                 exit = true;
                canvas.Add("</svg>");
                Console.WriteLine("Exited");
                break;
            }
            }
            //end
            canvas.ForEach(Console.WriteLine);
            createFile(canvas);
        }

        public static void swapElement(List<object> list,int a,int b)
        {
            object temp = list[a];
            list[a] = list[b];
            list[b] = temp;
            

        }

public static void updateSVG(List<object> list,int a)
        {
            String[] l = list[a].ToString().Split("\"");
            for(int i = 0; i < l.Length - 4; i++)
            {
                Console.WriteLine(l[i]);
            }
          
            /*switch(l)
            {
                Case (l.Contains("circle")):
                Console.WriteLine("circ");
                break;

                Case (l.Contains("square")):
                Console.WriteLine("sqr");
                break;
            }*/

            

        }

        public static void updateStyle(List<object> list,int a)
        {
            string[] l = list[a].ToString().Split("stroke");

            Console.WriteLine();
            Console.Write("New stroke: ");
            string stroke = Console.ReadLine();

            Console.WriteLine();
            Console.Write("New fill: ");
            string fill = Console.ReadLine();

            //append new stroke and fill onto end of first part of the svg string

           list[a] = l[0] + " stroke=\"" + stroke + "\" " + "stroke-width = \"4\"" + " fill= \"" + fill + "\"" + "/>" ;

        }

        public static void DeleteElement(List<object> list,int a)
        {
            for(int i = a; i < list.Count; i++)
            {
                if((i+1) != list.Count)
                list[i] = list[i+1];

                else
                list.RemoveAt(i);
            }

        }

        static void createFile(List<object> canvas)
        {
            String path = @"C:\Users\User\js\264\svgmodels\test.svg";

            if(File.Exists(path))
            File.Delete(path);

             using (StreamWriter fs = File.CreateText(path))    
                {  

                canvas.ForEach(fs.WriteLine);
                }
        }

     
         class Circle
        {
             public int x{get; set;}
             public int y{get; set;}
             public int radius{get; set;}

             public string stroke  {get; set;}
             public string fill{get; set;}
                public Circle(int x, int y, int r)
                {
                    this.x = x;
                    this.y = y;
                    this.radius = r;
                    this.stroke = "yellow";
                    this.fill = "yellow";
                }

                public string printShape()
                {

                    string svg = "<circle cx =" + "\"" + this.x + "\"" + " cy=" + "\"" + this.y + "\"" + " r=" + "\"" + this.radius + "\"" +" stroke=\"" + this.stroke + "\"" + " stroke-width=\"4\"" +  " fill=\"" + this.stroke + "\"" + "/>";

                    return svg;
                }

        }

         class Square
        {
            private int x{get; set;}
            private int y{get; set;}

            private int height{get; set;}
            private int width{get; set;}


                public Square(int x, int y, int h,int w)
                {
                    this.x = x;
                    this.y = y;
                    this.height = h;
                    this.width = w;
                }

                public string printShape()
                {
                    string svg = "<rect x =" +  "\"" + this.x + "\"" + " y=" + "\"" + this.y + "\"" + " width=" + "\"" + this.width + "\"" +" height=" + "\"" +this.height +"\""  +" stroke=\"grey\"" + " stroke-width=\"1\"" +  " fill=\"grey\""+" />";
                    return svg;
                }

        }

         class Ellipse
        {
            private int x {get; set;}
            private int y {get; set;}
            private int rx {get; set;}
            private int ry {get; set;}
           

            public Ellipse(int x, int y ,int rx ,int ry)
            {
                this.x = x;
                this.y = y;
                this.rx = rx;
                this.ry = ry;
    
            }

            public string printShape()
                {
                    string svg = "<ellipse cx =" +  "\"" + this.x +  "\"" + " cy=" + "\"" +  this.y + "\"" + " rx=" +  "\"" + this.rx +  "\"" + " ry=" +  "\"" + this.ry +  "\"" +" stroke=\"blue\"" + " stroke-width=\"1\"" +  " fill=\"blue\""+" />";
                    return svg;
                }

            
        }

         class Line
        {
            private int x1{get; set;}
            private int y1{get; set;}
            private int x2{get; set;}
            private int y2{get; set;}
       


                public Line(int x1, int y1, int x2,int y2)
                {
                    this.x1 = x1;
                    this.y1 = y1;
                    this.x2 = x2;
                    this.y2 = y2;
                }

                public string printShape()
                {
                    string svg = "<line x1 =" +  "\""+ this.x1 +  "\"" +" y1=" +  "\"" + this.y1 +  "\"" + " x2=" +  "\""+ this.x2 +  "\"" + " y2=" +  "\"" + this.y2  +  "\"" +" stroke=\"black\"" + " stroke-width=\"1\"" +  " fill=\"black\""+" />";
                    return svg;
                }

        }

        class PolyLine
        {
            private int x {get; set;}
            private string points {get; set;}
            private int y { get; set;}


            public PolyLine(int x, string points, int y)
            {
                this.x = x;
                this.points = points;
                this.y = y;
            }

             public string printShape()
                {
                    string svg = "<polyline points=\"" + this.x + "," + this.points + "," + this.y +"\" stroke=\"cyan\"" + " stroke-width=\"1\"" +  " fill=\"cyan\""+" />";
                    return svg;
                }
        }

        class Polygon
        {
            private int x {get; set;}
            private string points {get; set;}
            private int y { get; set;}


            public Polygon(int x, string points, int y)
            {
                this.x = x;
                this.points = points;
                this.y = y;
            }

             public string printShape()
                {
                    string svg = "<polygon points=\"" + this.x + "," + this.points + "," + this.y +"\" stroke=\"red\"" + " stroke-width=\"1\"" +  " fill=\"pink\""+" />";
                    return svg;
                }
        }

        class Path
        {
            private string points {get; set;}


            public Path(string points)
            {
                this.points = points;
            }

             public string printShape()
                {
                    string svg = "<path d=\"" + this.points +"\" stroke=\"red\"" + " stroke-width=\"1\"" +  " fill=\"pink\""+" />";
                    return svg;
                }
        }
    }
        
   
