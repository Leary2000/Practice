using System;
    class SVGModels
    {
        static void Main ()
        {
            bool exit = false;
            int Zindex = 0;
            //string canvas;
            List<object> canvas = new List<object>();
            //start of canvas
            Console.Clear();

            while(exit == false)
            {
            Console.WriteLine("Choose shape to create below");
            Console.WriteLine("1) Create Circle");
            Console.WriteLine("2) Create Square");
            Console.WriteLine("3) Create Ellipse");
            Console.WriteLine("4) Create Line");
            Console.WriteLine("5) Create PolyLine");
            Console.WriteLine("6) Create Polygon");
            Console.WriteLine("7) Exit");

            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                int CircleZ = Zindex;
                Zindex++;
                int x = int.Parse(Console.ReadLine());
                int y = int.Parse(Console.ReadLine());
                int r = int.Parse(Console.ReadLine());
                Circle myCircle = new Circle(x,y,r,CircleZ);
                canvas.Add(myCircle.printShape());
                break;


                case 2:
                int SquareZ = Zindex;
                Zindex++;
                int squareX = int.Parse(Console.ReadLine());
                int squareY = int.Parse(Console.ReadLine());
                int squareWidth = int.Parse(Console.ReadLine());
                int squareHeigth = int.Parse(Console.ReadLine());
                Square mySquare = new Square(squareX,squareY,squareWidth,squareHeigth,SquareZ);
                canvas.Add(mySquare.printShape());
                break;

                case 3:
                int EllipseZ = Zindex;
                Zindex++;
                int ellipseX = int.Parse(Console.ReadLine());
                int ellipseY = int.Parse(Console.ReadLine());
                int ellipseRX = int.Parse(Console.ReadLine());
                int ellipseRY = int.Parse(Console.ReadLine());
                Square myEllipse = new Square(ellipseX,ellipseY,ellipseRX,ellipseRY,EllipseZ);
                canvas.Add(myEllipse);
                break;

                case 7:
                exit = true;
                Console.WriteLine("Exited");
                break;

            }
            }
            //end
            canvas.ForEach(Console.WriteLine);
        }

        public void swapElement(List<string> list,int a,int b)
        {
            string temp = list[a];
            list[a] = list[b];
            list[b] = temp;

        }
        public class Circle
        {
            private int x{get; set;}
            private int y{get; set;}
            private int radius{get; set;}
            private int Zindex{get; set;}

                public Circle(int x, int y, int r, int z)
                {
                    this.x = x;
                    this.y = y;
                    this.radius = r;
                    this.Zindex = z;
                }

                public string printShape()
                {
                    string svg = "<circle cx =" + this.x + " cy=" + this.y + " r=" + this.radius + "/>";
                    return svg;
                }

        }

        public class Square
        {
            private int x{get; set;}
            private int y{get; set;}

            private int height{get; set;}
            private int width{get; set;}
            private int Zindex{get; set;}


                public Square(int x, int y, int h,int w,int z)
                {
                    this.x = x;
                    this.y = y;
                    this.height = h;
                    this.width = w;
                    this.Zindex = z;
                }

                public string printShape()
                {
                    string svg = "<circle cx =" + this.x + " cy=" + this.y + " width=" + this.width + " height=" + this.height +">";
                    return svg;
                }

        }

        public class Ellipse
        {
            private int x {get; set;}
            private int y {get; set;}
            private int rx {get; set;}
            private int ry {get; set;}
            private int Zindex{get; set;}

            public Ellipse(int x, int y ,int rx ,int ry, int Zindex)
            {
                this.x = x;
                this.y = y;
                this.rx = rx;
                this.ry = ry;
                this.Zindex = Zindex;
            }

            public string printShape()
                {
                    string svg = "<ellipse cx =" + this.x + " cy=" + this.y + " rx=" + this.rx + " ry=" + this.ry +">";
                    return svg;
                }

            
        }
    }
