import java.util.Scanner;
import java.lang.Math;
public class BaseConvert {

    public static void main(String[] args)
    {
        Scanner sc = new Scanner(System.in);
        int Base = sc.nextInt();
        int toBase = sc.nextInt();
        String number = sc.next();

        number = (convert(Base, toBase, number));
        System.out.println(number);

    }
    public static String convert(int Base, int toBase, String num)
    {
        double n = 0;
        double decimal = 0;
        char digit;


        //convert to base 10 first
        for(int i = 0 ;i < num.length();i++)
        {
            //get rightmost digit first
            digit = Character.toUpperCase(num.charAt(num.length() - 1 - i));
            //convert to base 10
            if(Character.isLetter(digit))
            {
                decimal = digit - 'A' + 10;
            }
            else
            {
                decimal = digit - '0';
            }
            //multiply decimal by Base^i and add it to n
            n += decimal * Math.pow(Base,i);
        }

        //get num of digits in toBase
        int toBaseL = 1;
        for(int i = 1;Math.pow(toBase,toBaseL)<=n;i++)
        {
            toBaseL++;
        }

        //store num in char array
        char[] convertedNum = new char[toBaseL];

        //start from highest
        //reverse of other loop
        //base 10 to new Base
        for(int i = toBaseL - 1; i >= 0; i--)
        {
            double power = Math.pow(toBase, i);

            //round down to the nearest int
            decimal = Math.floor( n / power);
            n -= decimal*power;
            if(decimal < 10)
            {
                convertedNum[toBaseL - 1 - i] = (char) ('0' + (int)decimal);
            }
            else
            {
                convertedNum[toBaseL - 1 - i] = (char)('A' + (int)(decimal - 10));
            }
        }
        return new String(convertedNum);
    }
}