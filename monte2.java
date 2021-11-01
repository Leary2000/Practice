
/*
Online Java - IDE, Code Editor, Compiler

Online Java is a quick and easy tool that helps you to build, compile, test your programs online.
*/

import java.util.Scanner;
import java.lang.Math;
public class Main {
    public static void main(String args[]) {
    Scanner sc = new Scanner(System.in);
    int size = sc.nextInt();
    int matches = sc.nextInt();
    double trials = 10000;
    double successes = 0;
    for(int i = 0; i < trials; i++)
    {
        int days[] = new int[365];
        for(int j = 0; j < size; j ++)
        {
            int birthday = (int)(Math.random() * 365);
            days[birthday]++;
            if(days[birthday] >= matches)
            {
                successes++;
                break;
            }
        }
    }

      System.out.println(successes*100/trials);
    }
}