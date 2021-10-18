import java.util.Random;
import java.util.Scanner;

public class montecarlo {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        int x = sc.nextInt();
        int tests = 1000000;
        double matches = 0;
        double p = 0;
        for(int i = 0; i < tests; i ++) //will run Match method tests times
        {
                if ((Match(n)) == true)
                {
                    matches++; //each time year[j] returns true matches records it
                }

        }

        p = matches/tests;
        double odds = (p/(x-1)); //calculates the likelihood of p happening x times
        System.out.println((int) (odds * 100)); // casts odds to an integer
    }
    private static boolean Match(int n)
    {
        boolean[] year = new boolean[365];
        for(int i = 0; i < n; i ++)
        {
            int j = (int) (Math.random()*365); //random day of the year
           if(year[j] == true) //if year[j] is already true its a match
           {
               return true;
           }
           year[j] = true; //stores year[j] as true
        }
        return false; //if year[j] is not equal to another j will run again until it finds a match
    }
}

