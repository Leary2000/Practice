import java.util.Scanner;
import java.lang.Object;
import java.security.MessageDigestSpi;
import java.security.MessageDigest;
public class sha
{
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();
        String[] arr = new String[n];
        for(int i = 0; i <n;i++)
        {
            arr[i] = sc.next();
            //gSystem.out.println(sha256(arr[i]));
        }
        for(int i = 0; i < n;i++)
        {
            System.out.println(sha256(arr[i]));
        }
     
        
        
    }
    public static String sha256(String input)
    {
        try{
        MessageDigest myDigest = MessageDigest.getInstance("SHA-256");
        byte[] salt = "CS210+".getBytes("UTF-8");
        myDigest.update(salt);
        byte[] data = myDigest.digest(input.getBytes("UTF-8"));
        StringBuffer SB = new StringBuffer();
        for(int i =0;i<data.length;i++)
        {
            SB.append(Integer.toString((data[i]&0xff)+0x100,16).substring(1));
        }
        return SB.toString();
        }
        catch(Exception e)
        {
            return(e.toString());
        }
    }
}
