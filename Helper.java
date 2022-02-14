import java.util.*;
public class Helper {
    public static void main(String args[])
    {
        Scanner sc = new Scanner(System.in);
        Random rand = new Random();
        Dictionary dict = new Dictionary();
        LinkedList<String> words = new LinkedList<String>();

        for(int i =0; i<2315; i++)
        {
            words.add(dict.getWord(i));
        }
        String[] guesses = new String[5];
        guesses[0]="crane";
        String[] results = new String[5];
        int size = words.size();
        for(int k =0; k<words.size(); k++)
        {
            String word = words.get(k);

        }

        for(int i = 0; i < 6; i++)
        {
            if(i != 0)
            {
                System.out.println(size);
                guesses[i] = words.get(rand.nextInt(size));
            }
            System.out.println("Try " + guesses[i]);
            System.out.println("What did you get for " + guesses[i] + "?");
            results[i] = sc.next();
            if(results[i].equals("22222"))
            {
                System.out.println("Congrats!");
                System.exit(1);
            }

            for(int j = 0; j < 5;j++)
            {

                if(results[i].charAt(j)== '2')
                {

                    for(int k = size - 1; k >= 0; k--)
                    {
                        if(words.get(k).charAt(j) != guesses[i].charAt(j))
                        {
                            words.remove(k);
                        }
                    }
                    size = words.size();
                }
                else if(results[i].charAt(j)== '1')
                {
                    for(int k = size - 1; k >= 0; k--)
                    {
                        System.out.println(size);
                        //System.out.println(words.get(k).indexOf(guesses[i].charAt(j)));
                        if(words.get(k).indexOf(guesses[i].charAt(j)) == -1 | words.get(k).charAt(j) == guesses[i].charAt(j))
                        {
                           // System.out.println(words.get(k));
                            words.remove(k);
                        }

                    }
                    size = words.size();
                }


            }
            words.remove(guesses[i]);
            size = words.size();
        }
    }


}
