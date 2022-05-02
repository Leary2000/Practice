import javax.swing.*;
import java.awt.*;
import java.awt.geom.*;
import java.io.*;


public class Schools{


    public static void main(String args[] ) throws Exception {

        int w = 1000;
        int h = 1000;

        JFrame frame = new JFrame();
        Map map = new Map(w,h);

        frame.setSize(w,h);
        frame.add(map);
        frame.setVisible(true);
        String[][] GPS = new String[121][3];
        Dictionary dict = new Dictionary();
        for(int i=0;i<=120;i++){

            GPS[i][0]=dict.getWord(i).split(",")[0];
            GPS[i][1]=dict.getWord(i).split(",")[1];
            GPS[i][2]=dict.getWord(i).split(",")[2];
           // System.out.println(GPS[i][0]);
        }
        Brain mybrain = new Brain(GPS);
        String solution = mybrain.getSolution();
        String[] journey=solution.split(",");
        for(int i=0;i<journey.length;i++){
            String adjusted="";
            for(int j=0;j<journey[i].length();j++){
                if(journey[i].charAt(j)!=' '){
                    adjusted=adjusted+journey[i].charAt(j);
                }
            }
            journey[i]=adjusted;
        }


        //check that every house that has ordered a pizza is in the solution
        for(int i=0;i<GPS.length;i++){
            boolean check=false;
            for(int j=0;j<journey.length;j++){
                if(i==Integer.parseInt(journey[j])){
                    check=true;
                }
            }
            if(check==false){
                System.out.println("Solution string is defective: there is no school #"+i);
                System.exit(0);
            }
        }
        if(journey.length-1!=GPS.length){
            System.out.println("Solution string is defective: some schools are repeated or does not return to Maynooth");
            System.exit(0);
        }
        double distance=0;
        //go through every school in the solution, and add on the appropriate distance
        for(int i=0;i<journey.length-1;i++){
            int school1=Integer.parseInt(journey[i]);
            int school2=Integer.parseInt(journey[i+1]);
            distance+=getDistance(GPS[school1][1],GPS[school1][2],GPS[school2][1],GPS[school2][2]);
        }
      //  System.out.println("The total distance covered is "+(double)((int)distance)/1000+"km");
    }

    public static double getDistance(String lt1, String ln1, String lt2, String ln2){
        final int R = 6371; // Radius of the earth
        Double lat1 = Double.parseDouble(lt1);
        Double lon1 = Double.parseDouble(ln1);
        Double lat2 = Double.parseDouble(lt2);
        Double lon2 = Double.parseDouble(ln2);
        Double latDistance = toRad(lat2-lat1);
        Double lonDistance = toRad(lon2-lon1);
        Double a = Math.sin(latDistance / 2) * Math.sin(latDistance / 2) +
                Math.cos(toRad(lat1)) * Math.cos(toRad(lat2)) *
                        Math.sin(lonDistance / 2) * Math.sin(lonDistance / 2);
        Double c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
        Double distance = R * c;
        return distance*1000; //distance in metres
    }

    public static Double toRad(Double value) {
        return value * Math.PI / 180;
    }

}
class Brain{
    public static String[][] getSol;
    public Brain(String[][] inputs)
    {

        //Two-Opt Solution
        double distance = 0.0;
        double best = 0.0;

        String[][] temp = new String[1][3];
        for(int i=0;i<inputs.length-1;i++)
        {

            distance+=Schools.getDistance(inputs[i][1].toString(),inputs[i][2].toString(),inputs[i+1][1].toString(),inputs[i+1][2].toString());
        }
        distance = (double)((int)distance)/1000;
        best = distance;
        int n = 0;
        while(n < 10000)
        {
            getSol = inputs;
            for(int i = 1; i < inputs.length - 2;i++)
            {
                for(int k = 1; k < inputs.length - 2;k++) {
                    if (inputs[k][0].equals(inputs[i][0]) == false)
                    {
                        temp[0][0] = inputs[k][0];
                    temp[0][1] = inputs[k][1];
                    temp[0][2] = inputs[k][2];

                    inputs[k][0] = inputs[i][0];
                    inputs[k][1] = inputs[i][1];
                    inputs[k][2] = inputs[i][2];

                    inputs[i][0] = temp[0][0];
                    inputs[i][1] = temp[0][1];
                    inputs[i][2] = temp[0][2];


                    //after swap check new distance
                    distance = 0;
                    for (int o = 0; o < inputs.length - 1; o++) {

                            distance += Schools.getDistance(inputs[o][1].toString(), inputs[o][2].toString(), inputs[o + 1][1].toString(), inputs[o + 1][2].toString());
                        }
                        distance = (double) ((int) distance) / 1000;

                    //if new route is better save it
                    if (distance < best) {

                        System.out.println(distance+"km");
                        for(int d=0;d<inputs.length-1;d++)
                        {
                            System.out.print((Integer.parseInt(inputs[d][0]) + 1) + ", ");
                        }
                        System.out.println();
                        best = distance;
                    }
                    n++;

                }
                }

            }

        }

    }

    public String getSolution(){
        //all you have to do is return a String in the csv format below
        //just use all of the numbers from 1 to 120 - there are no other constraints!

        String solution = "0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109,110,111,112,113,114,115,116,117,118,119,120,0";

        return solution;
    }

}

class Dictionary {

    private String input[];

    public Dictionary() {
        input = load("C:\\Users\\User\\IdeaProjects\\schools\\src\\120schools.txt");

    }

    public int getSize() {
        return input.length;
    }

    public String getWord(int n) {
        return input[n].trim();
    }

    private String[] load(String file) {
        File aFile = new File(file);
        StringBuffer contents = new StringBuffer();
        BufferedReader input = null;
        try {
            input = new BufferedReader(new FileReader(aFile));
            String line = null;
            int i = 0;
            while ((line = input.readLine()) != null) {
                contents.append(line);
                i++;
                contents.append(System.getProperty("line.separator"));
            }
        } catch (FileNotFoundException ex) {
            System.out.println("Can't find the file - are you sure the file is in this location: " + file);
            ex.printStackTrace();
        } catch (IOException ex) {
            System.out.println("Input output exception while processing file");
            ex.printStackTrace();
        } finally {
            try {
                if (input != null) {
                    input.close();
                }
            } catch (IOException ex) {
                System.out.println("Input output exception while processing file");
                ex.printStackTrace();
            }
        }
        String[] array = contents.toString().split("\n");
        for (String s : array) {
            s.trim();
        }
        return array;
    }
}
class Map extends JComponent{
    private int width;
    private int height;

    public Map(int w, int h)
    {
        width = w;
        height = h;
    }

    protected void paintComponent(Graphics g) {

            String[][] sol = Brain.getSol;
            Graphics2D g2d = (Graphics2D) g;

               repaint();





            for (int i = 0; i < sol.length - 1; i++)
            {
                int x = Math.round(Float.parseFloat(sol[i][1]) * 100);
                int y = Math.round(Float.parseFloat(sol[i][2]) * 100);
                x = (((5000 - x) * -1) * 2) - 200;
                y = 1100 - (y * -1);


                int x2 = Math.round(Float.parseFloat(sol[i + 1][1]) * 100);
                int y2 = Math.round(Float.parseFloat(sol[i + 1][2]) * 100);
                x2 = (((5000 - x2) * -1) * 2) - 200;
                y2 = 1100 - (y2 * -1);


                Ellipse2D.Double e = new Ellipse2D.Double(x, y, 5, 5);
                g2d.drawLine(x, y, x2, y2);
                g2d.setColor(new Color(10, 10, 10));
                g2d.fill(e);



            }

        }
    }




