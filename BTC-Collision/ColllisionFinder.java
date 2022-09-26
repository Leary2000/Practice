import java.io.*;
import java.security.MessageDigest;

public class ColllisionFinder {
    public static void main(String[] args) {
        Dictionary words = new Dictionary();
        //int to store the highest number of same chars
        int highest = 0;
        int wordsize = words.getSize();
        String[] arr = new String[wordsize];
        System.out.println("Comparing " + wordsize + " sentences");
        System.out.println();
        //array stores the sha256 conversion of each sentence
        for (int i = 0; i < wordsize; i++)
        {
            arr[i] = sha256(words.getWord(i));
        }

        //nested for loop to go through the words file
            for (int i = 0; i < wordsize; i++) {
                for (int j = wordsize - 1; j > i; j--) {

                        //converts two strings into sha256 and counts the number of same chars with the compare method
                        String first = arr[i];
                       String second = arr[j];
                        int count = compare2(first, second);
                        if (count > highest) {
                            highest = count;
                            System.out.println("Count: " + count);
                            System.out.println(words.getWord(i));
                            System.out.println(words.getWord(j));
                            System.out.println(first);
                            System.out.println(second);
                            System.out.println();
                        }
                }
            }


            }


    //simple method to find the number of same characters

    public static int compare2 (String first, String second)
    {
        int count = 0;
        for (int i = 0; i < 64; i++)
        {
            if (first.charAt(i) == second.charAt(i))
                count++;
        }
            return count;
    }

    public static String sha256(String input) {
        try {
            MessageDigest mDigest = MessageDigest.getInstance("SHA-256");
            byte[] salt = "CS210+".getBytes("UTF-8");
            mDigest.update(salt);
            byte[] data = mDigest.digest(input.getBytes("UTF-8"));
            StringBuffer sb = new StringBuffer();
            for (int i = 0; i < data.length; i++) {
                sb.append(Integer.toString((data[i] & 0xff) + 0x100, 16).substring(1));
            }
            return sb.toString();
        } catch (Exception e) {
            return (e.toString());
        }
    }



    }

    class Dictionary{

        private String input[];

        public Dictionary(){
            input = load("C://words.txt");
        }

        public int getSize(){
            return input.length;
        }

        public String getWord(int n){
            return input[n];
        }

        private String[] load(String file) {
            File aFile = new File(file);
            StringBuffer contents = new StringBuffer();
            BufferedReader input = null;
            try {
                input = new BufferedReader( new FileReader(aFile) );
                String line = null;
                int i = 0;
                while (( line = input.readLine()) != null){
                    contents.append(line);
                    i++;
                    contents.append(System.getProperty("line.separator"));
                }
            }catch (FileNotFoundException ex){
                System.out.println("Can't find the file - are you sure the file is in this location: "+file);
                ex.printStackTrace();
            }catch (IOException ex){
                System.out.println("Input output exception while processing file");
                ex.printStackTrace();
            }finally{
                try {
                    if (input!= null) {
                        input.close();
                    }
                }catch (IOException ex){
                    System.out.println("Input output exception while processing file");
                    ex.printStackTrace();
                }
            }
            String[] array = contents.toString().split("\n");
            for(String s: array){
                s.trim();
            }
            return array;
        }
    }
