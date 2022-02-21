import java.io.*;
import java.util.*;
public class WordleGuess
{
    public static void main(String args[])
    {
        Dictionary dict = new Dictionary();
        ArrayList<String> Words = new ArrayList<String>();
        ArrayList<String> Possible = new ArrayList<String>();

        String[] guesses = new String[6];
        for(int i = 0; i < dict.getSize(); i++) {
            if(Words.contains(dict.getWord(i)) == false) {
                Words.add(dict.getWord(i));
                Possible.add(dict.getWord(i));
            }
        }
        String Guess = "crane";
        System.out.println("First guess is " + Guess);
        for(int i = 0; i < 6; i++)
        {
             Guess = guessWord(Words,Possible,Guess);
        }


    }
    public static String guessWord(ArrayList<String> Words, ArrayList<String> Possible,String Guess)
    {
        char[] Letters = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
        int[] LetterScore = new int[26];
        Scanner sc = new Scanner(System.in);
        String guess = Guess;
        System.out.println("Try " + guess + "!");
        System.out.println("What result did you get?");
        String result = sc.nextLine();
        if(result.equals("22222"))
        {
            System.out.println("Congrats!");
            System.exit(1);
        }
        Possible.remove(guess);

        //saves each result char in an array for easier use
        char[] positions = result.toCharArray();

            for (int j = 0; j < 5; j++) {
                if (positions[j] == '2') {

                    for (int k = 0; k < Possible.size(); k++) {
                        if (Possible.get(k).charAt(j) != guess.charAt(j)) {
                            Possible.remove(k);
                            k--;
                        }

                    }
                } else if (positions[j] == '1') {
                    for (int k = 0; k < Possible.size(); k++) {
                        if (Possible.get(k).indexOf(guess.charAt(j)) == -1 || Possible.get(k).charAt(j) == guess.charAt(j)) {
                            Possible.remove(k);
                            k--;
                        }

                    }
                } else if (positions[j] == '0') {
                    for (int k = 0; k < Possible.size(); k++) {
                        if (Possible.get(k).indexOf(guess.charAt(j)) != -1) {
                            Possible.remove(k);
                            k--;
                        }
                    }
                }
            }
            System.out.println(Possible);

            int best = 0;
            int secbest = 0;
            int  thirdbest = 0;
            char bestChar = ' ';
            char secBestChar = ' ';
            char thirdBestChar = ' ';
                for(int g = 0; g < 5; g++ )
                {
                    if(positions[g] != '2')
                    {
                        for(int l = 0; l <26 ; l++)
                        {

                            for (int k = 0; k < Possible.size(); k++)
                            {
                              if(Possible.get(k).charAt(g) == Letters[l])
                              {
                                  LetterScore[l]++;
                                  if(LetterScore[l]  > best)
                                  {
                                      best = LetterScore[l];
                                      bestChar = Letters[l];
                                  }
                                  else if(LetterScore[l] > secbest)
                                  {
                                      secbest = LetterScore[l];
                                      secBestChar = Letters[l];
                                  }
                                  else if(LetterScore[l] > thirdbest)
                                  {
                                      thirdbest = LetterScore[l];
                                      thirdBestChar = Letters[l];
                                  }
                              }
                            }
                        }
                    }
                }
;
        for(int i = 0; i < Possible.size(); i++)
        {
            if(Possible.get(i).indexOf(bestChar) != -1 && Possible.get(i).indexOf(secBestChar) != -1 &&Possible.get(i).indexOf(thirdBestChar) != -1)
            {
                guess=Possible.get(i);
            }
            else if(Possible.get(i).indexOf(bestChar) != -1 && Possible.get(i).indexOf(secBestChar) != -1)
            {
                guess=Possible.get(i);
            }
            else
            {
                guess = Possible.get(0);
            }
        }
       return guess;
        }

}