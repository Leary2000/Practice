import java.util.Scanner;
public class queue {
    public static void main(String args[])
    {
        Scanner sc = new Scanner(System.in);
        int s = sc.nextInt();
        que theQ = new que(s);
        for(int i = 0; i <= s; i ++)
        {
            String command = sc.nextLine();
            if(command.equals("REMOVE"))
            {
                theQ.remove();
            }
            else if(command.split(" ")[0].equals("INSERT"))
            {
                theQ.insert(command.split(" ")[1]);
            }
        }
        theQ.peekmid();


    }
}