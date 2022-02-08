import java.lang.*;
import java.util.Random;
import java.util.Scanner;
public class WordleText
{
    public static void main(String args[])
    {
        Scanner sc = new Scanner(System.in);
        Boolean run = true;
        while(run == true)
        {
            wordle();
            System.out.println("play again?");
            System.out.println("Y/N");
            if(sc.next().equals("Y") == false)
            {
                System.out.println("Bye Bye xxx");
                run = false;
            }
        }
    }

    private static void wordle()
    {
        System.out.println("Enter a guess");
        Scanner sc = new Scanner(System.in);
        Dictionary dict = new Dictionary();
        Random random = new Random();
        int n = dict.getSize();
        String[] words = new String[2315];
        for(int i =0; i<2315; i++)
        {
            words[i] = dict.getWord(i);
        }
        String[] validwords = new String[n];
        for(int i =0; i<n; i++)
        {
            validwords[i] = dict.getWord(i);
        }
        String word = words[random.nextInt(2315)].toUpperCase();
        //System.out.println(word);
        String[] guesses = new String[6];


        for(int i = 0; i<6;i++)
        {
            boolean valid = false;
            guesses[i] = sc.next().toUpperCase();
            String[] check = new String[5];
            for(int k = 0; k <5;k++)
            {
                check[k] = String.valueOf(guesses[i].charAt(k));
            }
            if(guesses[i].equals(word))
            {
                System.out.println("You win!!!");
                System.out.println("With " + i + " guesses");
            }
            for(int k =0; k<n; k++)
            {
                if(guesses[i].equals(validwords[k].toUpperCase()))
                {
                    valid =  true;
                }
            }
            if(guesses[i].length() != 5 | valid == false)
            {
                System.out.println("Please enter a valid word");
            }
            else
            {
            for(int j = 0; j < 5; j++)
            {

                    char c = guesses[i].charAt(j);
                    char c2 = word.charAt(j);

                if(c==c2)
                {
                    check[j] = String.valueOf(c);

                }
                else if(word.contains("" + c))
                {
                    check[j] = String.valueOf(c).toLowerCase();

                }
                else {
                    check[j] = "*";
                }

            }
                for(int k = 0; k <5;k++)
                {
                    System.out.print(check[k]);
                }
                System.out.println();
            }

        }
        System.out.println("You lose!!!, the word was " + word);
    }

}
