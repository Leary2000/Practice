import java.util.Scanner;
public class Collatz
{
    public static void main(String[] args) {
       Scanner sc= new Scanner(System.in);
       int[] arr = new int[5];
       for( int i = 0; i < 5; i++)
       {
       arr[i] = sc.nextInt();
       }
        for(int  i = 0; i < 5; i++)
       {
           int count = 0;
           int n = arr[i];
           while(n > 1)
           {
            n = collatz(n);
            count++;
           }
           
           System.out.println(arr[i] + " takes " + count + " to reach 1");
       }
       
        
    }
    public static int collatz(int n)
    {
        if(n == 1)
        {
            return n;
        }
        else if(n % 2 ==0)
        {
            n = n /2;
        }
        else{
            n = (n * 3) + 1;
        }
        return n;
    }
}