import java.lang.Math;
public class que {
    private int size;
    private String[] qarray;
    private int front;
    private int rear;
    private int nItems;

    public que (int s)
    {
        size = s;
        qarray = new String[size];
        front = 0;
        rear = -1;
        nItems = 0;
    }
    public boolean insert(String item)
    {
        if(nItems == size) return false;
        if(rear == size -1)
        {
            rear = -1; // loop back
        }
        rear++;
        qarray[rear] = item;
        nItems++;
        return true;


    }
    public String remove()
    {
        if(nItems == 0) return null; //don’t remove if empty
        String temp = qarray[front];// get value and incr front
        front++;
        if(front == size) // deal with wraparound
            front = 0;
        nItems--; // one less item
        //System.out.println(qarray[]);
        return temp;
    }
    public void peekmid()
    {

        int n = rear / 2;
        if(rear % 2 == 0)
        {
            System.out.println(qarray[n]);
        }
        else
        {
            System.out.println(qarray[n - 1]);
        }


    }

}
