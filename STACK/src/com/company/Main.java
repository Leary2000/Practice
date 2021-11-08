package com.company;
import java.util.Scanner;
public class Main
{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int s = Integer.parseInt(sc.nextLine());
        stack thestack = new stack(s);
        for(int i = 0; i < s; i ++)
        {
            String command = sc.nextLine();
           // System.out.println(command);

           if(command.split(" ")[0].equals("PUSH"))
            {
                //System.out.println("I");
                thestack.push(Long.parseLong(command.split(" ")[1]));

            }
            if(command.split(" ")[0].equals("POP"))
            {
                thestack.pop();
            }

        }
        System.out.println(thestack.peek());

    }

}
