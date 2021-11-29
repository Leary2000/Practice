import java.util.*;
public class birthday
{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
       System.out.println(probability(n));
    }
    public static double probability(int n)
    {
        if(n == 1)
        {
            return 1;
        }
        double days = 365;
        return  1 - (days - (n-1))/days * probability(n-1); 
    }
}
