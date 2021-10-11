
import java.util.Scanner;
public class primes
{
    public static void main(String[] args)
    {
        Scanner sc = new Scanner(System.in);
        System.out.println("Please input the number you want to check for primes until");
        int size = sc.nextInt();
        size++;
        boolean[] array = new boolean[size];
        for(int i = 2; i < size; i++)
        {
            array[i] = true;
        }
        for(int i = 0; i < size; i++)
        {
            //only need to run inner loop sqrt(n) times
            for(int j = 2; j < Math.sqrt(size); j++)
            {
                if(i > 1) {
                    int mult = i * j;
                    if (mult < size) {
                        array[mult] = false;
                    }
                }
            }
            if(array[i] == true) {
                System.out.println(i);
            }
        }


    }
}
