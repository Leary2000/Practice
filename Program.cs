using System;
    class app
    {
        static void Main ()
        {            
            Console.Clear();
            bool exit = false;

            List<object> canvas = new List<object>();
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker(originator);

            canvas.Add("<svg viewBox= \"0 0 300 100\" xmlns= \"http://www.w3.org/2000/svg\" >");
            Console.WriteLine("Canvas created - use commands to add shapes to the canvas	");

            while(exit == false)
            {

            String[] choice = Console.ReadLine().Split(' ');
            switch (choice[0])
            {

            case "H":
            Console.WriteLine("Commands:");
            Console.WriteLine("       -H    Help");
            Console.WriteLine("       -A    Add <shape>");
            Console.WriteLine("       -U    Undo");
            Console.WriteLine("       -R    Redo");
            Console.WriteLine("       -C    Clear canvas");
            Console.WriteLine("       -Q    Quit ");
            break;
            /*possible shapes:*/
            case "A":
            addShape(choice[1],canvas);
            caretaker.Backup();
            

            
            break;

            case "U":
            caretaker.undo();
            break;

            case "R":
            caretaker.redo();
            canvas=caretaker.getMomento();
            break;

            case "C":
            canvas.Clear();
            canvas.Add("<svg viewBox= \"0 0 300 100\" xmlns= \"http://www.w3.org/2000/svg\" >");
            break;

            case "Q":
            Console.WriteLine("Goodbye!");
            List<object> canvas2 = new List<object>();
            canvas2 = caretaker.getMomento();
            canvas2.Add("</svg>");
            canvas2.ForEach(Console.WriteLine);

            exit = true;
            break;

            }
           
            }
            //end
           // createFile(canvas);
        }

   
        static void addShape(string shape,List<object> canvas)
        {
            Random r = new Random();
            string RandomPath = "";

            for(int i = 0; i < r.Next(1,6); i++)
            {
                RandomPath = RandomPath + (r.Next(10,100) + " " + r.Next(10,100) + ",");
            }

            switch(shape)
            {
                case "circle":
                Circle myCircle = new Circle(r.Next(10,100),r.Next(10,100),r.Next(10,100));
                canvas.Add(myCircle.printShape());
                break;


                case "square":
                Square mySquare = new Square(r.Next(10,100),r.Next(10,100),r.Next(10,100),r.Next(10,100));
                canvas.Add(mySquare.printShape());
                break;

                case "ellipse":
                Ellipse myEllipse = new Ellipse(r.Next(10,100),r.Next(10,100),r.Next(10,100),r.Next(10,100));
                canvas.Add(myEllipse.printShape());
                break;

                case "line":
                Line myLine = new Line(r.Next(10,100),r.Next(10,100),r.Next(10,100),r.Next(10,100));
                canvas.Add(myLine.printShape());
                break;

                case "polyline":
                PolyLine myPolyLine = new PolyLine(r.Next(10,100),RandomPath,r.Next(10,100));
                canvas.Add(myPolyLine.printShape());
                break;                

                case "polygon":
                Polygon myPolygon = new Polygon(r.Next(10,100),RandomPath,r.Next(10,100));
                canvas.Add(myPolygon.printShape());
                break;

                case "path":
                Path myPath = new Path(RandomPath);
                canvas.Add(myPath.printShape());
                break;
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
                    string svg = "<polyline points=\"" + this.x + "," + this.points  + this.y +"\" stroke=\"cyan\"" + " stroke-width=\"1\"" +  " fill=\"cyan\""+" />";
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
                    string svg = "<polygon points=\"" + this.x + "," + this.points  + this.y +"\" stroke=\"red\"" + " stroke-width=\"1\"" +  " fill=\"pink\""+" />";
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
                    string svg = "<path d=\"" + this.points + "\" stroke=\"red\"" + " stroke-width=\"1\"" +  " fill=\"pink\""+" />";
                    return svg;
                }
        }


        
       public  class Memento
        {
              private List<object> canvas = new List<object>();

              public Memento(List<object> canvas)
              {
                this.canvas = canvas;
              }

              public List<object> getCanvas()
              {
                return canvas;
              }

        }


    public class Originator
    {
     public List<object> canvas = new List<object>();

     public Memento CreateMemento()
     {
        return new Memento(canvas);
     }

      public void SetMemento(Memento memento)
        {
            canvas = memento.getCanvas();
        }

        public Memento save()
        {
            return new Memento(this.canvas);
        }

    }

        class Caretaker
        {
            private List<Memento> Mementos = new List<Memento>();
            private List<Memento> MementosHistory = new List<Memento>();

            public void add(Memento CurrentMemento)
            {
            Mementos.Add(CurrentMemento);
            CurrentMemento.getCanvas().ForEach(Console.WriteLine);
            }


        private Originator originator = null;
        public Caretaker(Originator originator)
        {
            this.originator = originator;
        }

            public void Backup()
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            this.Mementos.Add(this.originator.save());
        }


            public void undo()
            {
                MementosHistory.Add(Mementos[Mementos.Count - 1]);
                Mementos.RemoveAt(Mementos.Count - 1);
                Mementos.ForEach(Console.WriteLine);
            }

            public void redo()
            {
                MementosHistory.Add(Mementos[Mementos.Count - 1]);
                Mementos.RemoveAt(Mementos.Count - 1);
                Mementos.ForEach(Console.WriteLine);
            }

             public List<object> getMomento()
              {
                Mementos[Mementos.Count - 1].getCanvas().ForEach(Console.WriteLine);
                return Mementos[Mementos.Count - 1].getCanvas();
              }



        }
    }