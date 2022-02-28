import java.util.Scanner;
public class CollatzSort {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int l = sc.nextInt();
        int[] arr = new int[l];
        int[] count = new int[l];
        for (int i = 0; i < l; i++) {
            arr[i] = sc.nextInt();
        }
        for (int i = 0; i < l; i++) {

            int n = arr[i];
            while (n > 1) {
                n = collatz(n);
                count[i]++;
            }
        }
        //create new quicksort object
        Quicksort ob = new Quicksort();
        ob.sort(0, l - 1, count);
        for (int i = 0; i < l; i++)
            System.out.println(count[i]);


    }

    //simple method to get collatz num
    public static int collatz(int n) {
        if (n == 1) {
            return n;
        } else if (n % 2 == 0) {
            n = n / 2;
        } else {
            n = (n * 3) + 1;
        }
        return n;
    }
}
    //Quicksort is a separate class
    class Quicksort
    {
    int partition(int left, int right,int[] arr)
    {
            int p = arr[right];
            int i = (left - 1);
            for(int j = left;j < right;j++)
            {
                if(arr[j] <= p)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
        int temp = arr[i+1];
        arr[i+1] = arr[right];
        arr[right] = temp;

        return i+1;
    }
    void sort(int left, int right, int[] arr)
    {
            if (left < right)
            {
                int p = partition(left, right,arr);

                sort(left, p-1,arr);
                sort( p+1, right,arr);
            }
        }
}
