package com.company;

public class stack{
    private int maxsize;
    private long[] stackarray;
    private int top;

    public stack(int s)
    {
        maxsize = s;
        stackarray = new long[maxsize];
        top = -1; //set as empty
    }
    public void push(long j)
    {
        top++;
        stackarray[top] = j;
    }
    public long pop()
    {
        return stackarray[top--];
    }
    public long peek()
    {
        return stackarray[top];
    }
    public boolean isEmpty()
    {
        return (top == -1);
    }
    public boolean isFull()
    {
        return (top == maxsize - 1);
    }
    public void makeEmpty()
    {
        top = -1 ;
    }

}