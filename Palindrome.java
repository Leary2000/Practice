import java.util.Scanner;
public class Palindrome {
    public static void main(String args[]) {
        Scanner scan = new Scanner(System.in);
        String input = new String("");
        System.out.println("Please enter a String");
        input = scan.nextLine();
        if (isPalindrome(input))
        { System.out.println("YES!" + input + " IS A PALINDROME");
        } else
        {
            System.out.println("NO!"+ input + " IS NOT A PALINDROME");
        }
    }
    public static boolean isPalindrome(String s)
    {
        // Base Case for shortest strings 
        if (s.length() <= 1) 
        // must be a palindrome 
        {
         
            return true;
        }
        else
        {
            // Reduction Step - Get first and last characters
            char first = s.charAt(0);
            char last = s.charAt(s.length()- 1);
            System.out.println("First Character is: "+first);
            System.out.println("Last Character is: "+last);
            // Check if these are equal
            if (first != last)
            {
                System.out.println("Current values of String in base case where string is not a palindrone"+s);
                return false;
            }
            else
            { 
                System.out.println("Current value of String in recursive case is: "+s);
                String t=s.substring(1, s.length() - 1);

                System.out.println("New string to be sent to recursive call is: "+t);
                return (isPalindrome(t));
               

            }
        }

    }
}
