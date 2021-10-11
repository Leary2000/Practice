public class MaxArray{

    public static void main (String args[])
    {
        int [] myTestArray = {1,5,67,34,61,3,9};
        System.out.println("The max number in my array is " + maxArray(myTestArray,0));
    }



    public static int maxArray(int [] array, int start)
    {

        if(start==array.length-1)
        { //base case - single element array
            return array[start];
        }
        else
        {
            //compare current element and remainder of array
            return (Math.max(array[start], maxArray(array, start+1)));
        }
    }
}