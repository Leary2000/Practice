using System;

class Factory
{

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
            public List<object> canvas;

            public void SetCanvas(List<object> canvas)
            {
                this.canvas = new List<object>(canvas);
            }

            public List<object> GetCanvas()
            {
                return canvas;
            }

            public void setMemento(Memento memento)
            {
                canvas = memento.getCanvas();
            }

             public Memento CreateMemento()
            {
            return new Memento(canvas);
            }
        }



      
        class Caretaker
        {
            private List<Memento> Mementos = new List<Memento>();
            private List<Memento> MementosHistory = new List<Memento>();

            public void add(Memento CurrentMemento)
            {
            Mementos.Add(CurrentMemento);
            }
            public void ClearRedo()
            {
                MementosHistory.Clear();
            }

            public void undo()
            {
                int n = Mementos.Count - 1;
               
                MementosHistory.Add(Mementos[n]);
                Mementos.RemoveAt(n);
               
            }

            public void redo()
            {
                int n = MementosHistory.Count - 1;
                Mementos.Add(MementosHistory[n]);
                MementosHistory.RemoveAt(n);
                
            }

            public Memento getMemento()
            {
                return Mementos[Mementos.Count - 1];
            }
        }

            
    // Factory Method Design Pattern
     abstract class ShapeFactory
    {
    public abstract Shape CreateShape();
    }

    // Concrete Factory classes
     class CircleFactory : ShapeFactory
    {
        public override Shape CreateShape()
        {
            return new Circle();
        }
    }

    class SquareFactory : ShapeFactory
    {
        public override Shape CreateShape()
        {
            return new Square();
        }
    }

     class EllipseFactory : ShapeFactory
    {
        public override Shape CreateShape()
        {
            return new Ellipse();
        }
    }


    // Abstract Product class
    abstract class Shape
    {
        Random r = new Random();
        public abstract void Draw();
    }

    // Concrete Product classes
    class Circle : Shape
    {
                    Random r = new Random();
        public override void Draw()
        {
            Console.WriteLine( "<circle cx =" + "\"" + r.Next(10,100) + "\"" + " cy=" + "\"" + r.Next(10,100) + "\"" + " r=" + "\"" + r.Next(10,100)+ "\"" + "/>");

        }
    }

    class Ellipse : Shape
    {
        public override void Draw()
        {
            Random r = new Random();
            Console.WriteLine( "<ellipse cx =" + "\"" + r.Next(10,100) + "\"" + " cy=" + "\"" + r.Next(10,100) + "\"" + " rx=" + "\"" + r.Next(10,100) +   "\"" + " ry=" +  "\"" + r.Next(10,100)+  "\"" + "/>");
        }
    }

    class Square : Shape
    {
        public override void Draw()
        {
            Random r = new Random();
            Console.WriteLine("Drawing Square with style: " );
                                string svg = "<rect x =" +  "\"" +r.Next(10,100)+ "\"" + " y=" + "\"" + r.Next(10,100) + "\"" + " width=" + "\"" + r.Next(10,100) + "\"" +" height=" + "\"" + r.Next(10,100) +"\"" + " />";

        }
    }

  
static void addShape(string shape,List<object> canvas)
        {
            CircleFactory circleFactory = new CircleFactory();
            switch(shape.ToLower())
            {
                case "circle":
                var circle = CircleFactory.CreateShape();
                break;


                case "square":
                Square mySquare = new Square();
                break;

                case "ellipse":
                Ellipse myEllipse = new Ellipse();
                break;

            }

            Console.WriteLine(shape.ToLower() + " added to canvas");
        }


    class Program
    {
        static void Main()
        {
            Console.Clear();

            //will exit loop and quit program when set to true
            bool exit = false;

            List<object> canvas = new List<object>();
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();

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
            Console.WriteLine("       -D    Display canvas");
            Console.WriteLine("       -C    Clear canvas");
            Console.WriteLine("       -Q    Quit ");

            break;

            case "A":
            addShape(choice[1],canvas);
            //save current canvas

            originator.SetCanvas(canvas);
            //add memento of current canvas to the caretaker
            caretaker.add(originator.CreateMemento());

            //clear redo list when a new shape has been added
            caretaker.ClearRedo();
            break;

            case "U":
            try
            {
            caretaker.undo();
            canvas = caretaker.getMemento().getCanvas();
            }
            catch(Exception err)
            {
                //if Undo list is empty
                Console.WriteLine("Cannot Undo");
            }
            break;

            case "R":
            try{

            caretaker.redo();
            canvas = caretaker.getMemento().getCanvas();
            }
             catch(Exception err)
            {
               //if Redo list is empty
                Console.WriteLine("Cannot Redo");
            }
            break;

            case "C":
            canvas.Clear();
            //add svg line to cleared canvas
            canvas.Add("<svg viewBox= \"0 0 300 100\" xmlns= \"http://www.w3.org/2000/svg\" >");
            //save current canvas
            originator.SetCanvas(canvas);
            caretaker.add(originator.CreateMemento());
            break;

            case "D":
            canvas.ForEach(Console.WriteLine);
            Console.WriteLine("</svg>");
            break;

            case "Q":
            Console.WriteLine("Goodbye!");
            canvas = caretaker.getMemento().getCanvas();
            canvas.Add("</svg>");
            canvas.ForEach(Console.WriteLine);
            exit = true;
            break;

            }
           
        }

            //end
            //creates a file containing the final state of canvas
           createFile(canvas);

           
        }
    }
    }