import java.util.Scanner;
import java.lang.Math;
//finds which num in an array is closest to the average of the array
public class Average
{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] arr = new int[5];
        double average = 0;
        double difference = 0;
        double difftemp = 0;
        int num = 0;
        for(int i = 0; i < 5 ; i++)
        {
            arr[i] = sc.nextInt();
            average = average + arr[i];
        }
        average = average / 5;
        for(int i = 0; i < 5; i ++)
        {
            difftemp = Math.abs(arr[i] - average);
            if(i == 0)
            {
                difference = Math.abs(arr[0] - average);
            }
            //if the difference is equal it will prioritze the 1st one
            if(difftemp < difference)
            {
                difference = difftemp;
                num = arr[i];
            }
            
        }
        //round to 2 decimal places
        System.out.println(num + " " + Math.round(difference * 100.0) / 100.0);
            
     
     
}
}
