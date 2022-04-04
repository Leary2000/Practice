import java.util.ArrayList;
 class Solution{

    public static void main(String[] args){
        int lives = 200;
        String[] input = new String[20];
        input[ 0]="XXX XXXXXXX XXXXXX X";
        input[ 1]="XXX XXXXXXX XXXXXX X";
        input[ 2]="XXX      XX XXXX   X";
        input[ 3]="XXXXXXX XXXXXXXXXXXX";
        input[ 4]="XXXXXXX XX      XXXX";
        input[ 5]="XXX  XXXXX XXXX XXXX";
        input[ 6]="XX  X XXXX   XX XXXX";
        input[ 7]="XXX XXXXXXXX XX XXXX";
        input[ 8]="XX  X  XXXXX XX XXXX";
        input[ 9]="XXXXXX       XX XXXX";
        input[10]="X XXXX XX  XXXX XXXX";
        input[11]="     XXXX  XXXX XXXX";
        input[12]="XXXXXXXXXXXXXXX XXXX";
        input[13]="XXXXXX  XXXX    XXXX";
        input[14]="XX XX XXXXXX XX XXXX";
        input[15]="X  XX XXXXXX XX XXXX";
        input[16]="XX XX X  X   XX XX  ";
        input[17]="X  XXXXXXX XXXX XX X";
        input[18]="XX XXXXXXX XXXXXXX X";
        input[19]="XX XXXXXXX XXXXXXX X";
        int posX=10;
        int posY=10;

        boolean[][] maze = new boolean[20][20];
        int[][] visited = new int[20][20];

        for(int i=0;i<20;i++){
            for(int j=0;j<20;j++){
                if(input[j].charAt(i)=='X'){
                    maze[i][j]=false;
                    visited[i][j] = 0;
                }else{
                    maze[i][j]=true;
                    visited[i][j] = 1;

                }
            }
        }

        ArrayList<Integer> stack = new ArrayList();
        System.out.println(posX+" "+posY);
        printboard(maze,posX,posY);
        Brain myBrain = new Brain();


        while(lives>0){
            String move =myBrain.getMove(maze[posX][posY-1],maze[posX][posY+1],maze[posX+1][posY],maze[posX-1][posY],visited,posX,posY,stack);
            if(move=="north"&&maze[posX][posY-1]){
                posY--;
            }else if(move=="south"&&maze[posX][posY+1]){
                posY++;
            }else if(move=="east"&&maze[posX+1][posY]){
                posX++;
            }else if(move=="west"&&maze[posX-1][posY]){
                posX--;
            }
            visited[posX][posY] = 2;
            stack.add(posX);
            stack.add(posY);
            System.out.println(posX+" "+posY+" "+lives);
            printboard(maze,posX,posY);
            lives--;
            if(posY%19==0||posX%19==0){
                System.out.println(posX+","+posY);
                System.exit(0);
            }
        }
        System.out.println("You died in the maze!");
    }


    public static void printboard(boolean[][] board, int posX, int posY){
        for(int y=0;y<20;y++){
            for(int x=0;x<20;x++){
                if(x==posX&&y==posY){
                    System.out.print(":)");
                }else{
                    if(board[x][y]==true){
                        System.out.print("  ");
                    }else{
                        System.out.print("■ ");
                    }
                }
            }
            System.out.println();
        }
        try{
            Thread.sleep(100);
        }catch(InterruptedException ex){
            Thread.currentThread().interrupt();
        }
    }
}

class Brain{

    public String getMove(boolean north, boolean south, boolean east, boolean west,int[][] visited,int posX,int posY,ArrayList stack)
    {
        //System.out.println(north + " " + south + " " + west + " " + east);
        //System.out.println( visited[posX][posY - 1] + " " + visited[posX][posY + 1] + " " + visited[posX - 1][posY] + " " + visited[posX + 1][posY]);
      if(north == true && visited[posX][posY - 1] == 1)
      {
          return "north";
      }
      else if( south == true && visited[posX][posY + 1] == 1)
      {
          return "south";
      }
      else if( west == true && visited[posX - 1][posY] == 1)
      {
          return "west";
      }else if( east == true && visited[posX + 1][posY] == 1)
      {
          return "east";
      }
      else
      {


            posY = (int) stack.get(stack.size()-1);
            posX = (int) stack.get(stack.size()-2);

          stack.remove(stack.size()-1);
          stack.remove(stack.size()-1);


            int goY = (int) stack.get(stack.size()-1);
            int goX = (int) stack.get(stack.size()-2);
            if(posY == goY && posX == goX)
            {
                stack.remove(stack.size()-1);
                stack.remove(stack.size()-1);
                 goY = (int) stack.get(stack.size()-1);
                 goX = (int) stack.get(stack.size()-2);
            }

            System.out.println(posX + " " + posY + " " + goX + " " + goY);
          if(posY - 1 == goY && posX == goX )
          {
              return "north";
          }
          else if( posY + 1 == goY && posX == goX)
          {
              return "south";
          }
          else if(posY == goY && posX - 1 == goX)
          {
              return "west";
          }else if( posY == goY && posX + 1 == goX )
          {
              return "east";
          }
      }
        return "";

    }
}