
import java.util.Scanner;
public class interest
{
    public static void interest(String[] args) {
        Scanner sc = new Scanner(System.in);
        int y = sc.nextInt();
        double i = sc.nextDouble();
        double x = sc.nextDouble();
        i = i/100;
        System.out.print(function(x,i,y));
    }
    public static double function(double x,double i, int y)
    {
        if(y == 0)
        {
            return x;
        }
        x = x +(x * i);
        y--;
        return(function(x,i,y));
    }
}
