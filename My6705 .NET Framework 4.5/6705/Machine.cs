﻿namespace My6705.NET_Framework_4._5
{
    public static class Machine
    {
        public readonly static Board Board = new Board("1245");

        //private readonly static testConditions testConditions { get; set; } = new testConditions();
        public readonly static TestConditions testConditions = new TestConditions();

        static Machine()
        {
            Board.LoadBoardProperties();
            Board.OpenBoard();
            testConditions.Load();
        }

        public static double AxesCount { get { return Board.AxesCount; } }
        public static double[] SlowVelocity { get { return Board.SlowVelocity; } set { Board.SlowVelocity = value; } }
        public static double[] FastVelocity { get { return Board.FastVelocity; } set { Board.FastVelocity = value; } }
        public static double[] DriverVelocity { get { return Board.DriverVelocity; } set { Board.DriverVelocity = value; } }
        public static double[] Acceleration { get { return Board.Acceleration; } set { Board.Acceleration = value; } }
        public static double[] Jerk { get { return Board.Jerk; } set { Board.Jerk = value; } }
        public static double[] MaxCoordinate { get { return Board.MaxCoordinate; } set { Board.MaxCoordinate = value; } }
    }
}