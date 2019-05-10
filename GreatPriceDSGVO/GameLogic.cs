using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GreatPriceDSGVO
{
    /// <summary>
    /// Thic class provides all logic and processes for the game
    /// </summary>
    public class GameLogic
    {
        //Two groups are playing, they each have their own instance
        public Group group1 = new Group("Gruppe 1");
        public Group group2 = new Group("Gruppe 2");
        /// <summary>
        /// Enum which contains to values for the two groups
        /// </summary>
        enum Groups { g1,g2 };
        Groups nextGroup;
        int currentQuestion;

        public void StartGame()
        {
            //Select randomly, which group is going to start
            Random rnd = new Random();
            int groupSelect = rnd.Next(2);

            //Check wich group starts
            if(groupSelect == 0)
            {
                //Group 1 starts
                nextGroup = Groups.g1;
            }
            else
            {
                //Group 2 starts
                nextGroup = Groups.g2;
            }
        }

        private void ChangeTurn()
        {
            switch (nextGroup)
            {
                case Groups.g1:
                    nextGroup = Groups.g2;
                    break;
                case Groups.g2:
                    nextGroup = Groups.g1;
                    break;
            }
        }

        //If you have a correct answer, own team will get the points
        public void Correct()
        {
            switch (nextGroup)
            {
                case Groups.g1:
                    group1.AddPoints(100);
                    break;
                case Groups.g2:
                    group2.AddPoints(100);
                    break;
            }
            ChangeTurn();
        }

        //If you have a wrong answer, opponent team will get the points
        public void Wrong()
        {
            switch (nextGroup)
            {
                case Groups.g1:
                    group2.AddPoints(100);
                    break;
                case Groups.g2:
                    group1.AddPoints(100);
                    break;
            }
            ChangeTurn();
        }

        public void LoadQuestion(int questionNumber)
        {
            currentQuestion = questionNumber;
        }
    }
}
