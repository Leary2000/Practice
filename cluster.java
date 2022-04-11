public class cluster {
    public static void main(String args[])
    {
        double[][] gps = {{51.62497513,51.94026835,52.178285,52.268,52.33356304, 52.4736608,52.86618127	,52.909722,53.1699938,53.17901778,53.1843656453,53.19490793,53.1953312
                ,53.1953312,53.21575053,53.27663886,53.29179685,53.31827917,53.32421,53.33655618,53.3579,53.36407274,53.36838522,53.37006,53.3717,53.37484,53.3888,53.389153,
                53.3945937,53.3977573,53.50413322,53.3888,53.389153	,53.3945937	,53.3977573,53.50413322, 53.552384,53.64314,53.80115134,54.1795236,54.26405697,54.648672,54.655499,55.09671038},
                {-8.887028344,-10.24088642,-8.911617,-7.0945,-6.463963364,-8.4346524,-6.942840109,-6.839167,-6.914885591,-7.719844209,-6.792525445,-6.670261667,-6.670313902,-6.661529073,-6.48044077,
                        -6.698044529,-6.389738373,-6.33366,-6.462126917,-6.441,-6.498749584,-6.274938564,-6.58208,-6.3905,-6.40909,-6.39608,-6.169552409,-6.5985973,-6.4348173,-6.387552494,-7.346691823,
                        -6.790148,-6.64577,-9.512749602,-7.225463119,-6.956248402,-8.112425,-8.632717,-8.278657422}};

            double closest = 100;
        double lat1 = 0;
        double lat2 = 0;
        double lon1 = 0;
        double lon2 = 0;
            for(int i = 0; i < 29;i++)
            {
                for(int j = i + 1; j < i + 10;j++)
                {
                    double temp = distance(gps[0][i],gps[1][i],gps[0][j],gps[1][j]);


                    if(temp < closest )
                    {
                        closest = temp;
                         lat1 = gps[0][i];
                         lat2 = gps[0][j];
                         lon1 = gps[1][i];
                         lon2 = gps[1][j];

                    }
                }
            }
            System.out.println(closest);
            System.out.println(lat1 + " " + lon1 + " " + lat2 + " " + lon2);

    }
    public static double distance(double lat1, double lon1, double lat2, double lon2)
    {
        //https://www.geeksforgeeks.org/program-distance-two-points-earth/


        // The math module contains a function
        // named toRadians which converts from
        // degrees to radians.

        lon1 = Math.toRadians(lon1);
        lon2 = Math.toRadians(lon2);
        lat1 = Math.toRadians(lat1);
        lat2 = Math.toRadians(lat2);

        // Haversine formula
        double dlon = lon2 - lon1;
        double dlat = lat2 - lat1;
        double a = Math.pow(Math.sin(dlat / 2), 2)
                + Math.cos(lat1) * Math.cos(lat2)
                * Math.pow(Math.sin(dlon / 2),2);

        double c = 2 * Math.asin(Math.sqrt(a));

        // Radius of earth in kilometers. Use 3956
        // for miles
        double r = 6371;

        // calculate the result
        return(c * r);
    }
}
