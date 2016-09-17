﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rack
{
    public class Rack : IRack
    {       
        private const int SIZE = 7;
        private const int BALL_MIN = 1;
        private const int BALL_MAX = 49;   
        private int[] balls = new int[0];
        public IEnumerable<int> Balls()
        {
            return balls;
        }

        public void AddBall(int ball)
        {
            if (ball < BALL_MIN || ball > BALL_MAX)
                throw new ArgumentOutOfRangeException(nameof(ball), ball, string.Format($"Balls must be numbered between {BALL_MIN} and {BALL_MAX}."));

            if (balls.Contains(ball))
                throw new ArgumentException(string.Format($"The same ball must not be added more than once. Rack already contains the ball {ball}."));

            if (balls.Length == SIZE)
                throw new Exception($"There must not be more than {SIZE} balls on the rack.");

            AddNewBallAndSortBalls(ball);
        }

        private void AddNewBallAndSortBalls(int ball)
        {
            // resize the array and put the ball in the right position moving the other balls accordingly
            // start from the last position ang go "down"

            int[] newBalls = new int[balls.Length + 1];
            Array.Copy(balls, newBalls, balls.Length);
            int position = newBalls.Length - 1;
            newBalls[position] = ball; // put new ball at the end

            // move new ball in the right position            
            while (position > 0 && newBalls[position - 1] > ball)
            {
                newBalls[position] = newBalls[position - 1]; // move up to make space
                newBalls[position - 1] = ball;
                position--;
            }

            balls = newBalls;
        } 
    }
}
