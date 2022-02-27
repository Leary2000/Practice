import java.util.Scanner;
public class CollatzSort {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int[] arr = new int[5];
        int[] count = new int[5];
        for (int i = 0; i < 5; i++) {
            arr[i] = sc.nextInt();
        }
        for (int i = 0; i < 5; i++) {

            int n = arr[i];
            while (n > 1) {
                n = collatz(n);
                count[i]++;
            }
        }
        sort(arr, count);
        for (int i = 0; i < 5; i++)
        {
            System.out.println(arr[i] + " " + count[i]);
        }

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
    //sorting method
    public static void sort(int[] arr, int[] count) {
        for (int i = 0; i < count.length; i++) {
            for (int j = i + 1; j < count.length; j++) {
                int tmp = 0;
                int tmp2 = 0;
                if (count[i] > count[j]) {
                    tmp = arr[i];
                    tmp2 = count[i];
                    arr[i] = arr[j];
                    count[i] = count[j];
                    count[j] = tmp2;
                    arr[j] = tmp;
                }
                //if count is same size, will sort by smaller initial number
                else if((count[i] == count[j]))
                {
                    if(arr[i] < arr[j])
                    {
                        tmp = arr[i];
                        tmp2 = count[i];
                        arr[i] = arr[j];
                        count[i] = count[j];
                        count[j] = tmp2;
                        arr[j] = tmp;
                    }
                    else
                    {
                        tmp = arr[i];
                        tmp2 = count[i];
                        arr[i] = arr[j];
                        count[i] = count[j];
                        count[j] = tmp2;
                        arr[j] = tmp;
                    }
                }
            }
        }
    }
}