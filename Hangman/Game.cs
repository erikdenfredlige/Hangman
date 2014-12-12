using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class Game
    {

        public int lives;
        public string word;
        public int whichWord;
        
        public void setWord()
        {
            Random wordDeterminer = new Random();
            whichWord = wordDeterminer.Next(1, 5);

            SqlConnection connectionToDB = new SqlConnection
                ("Data Source=MONARKEN;Initial Catalog=HangmanDB;Integrated Security=True");
            
            SqlCommand query = new SqlCommand("SELECT word FROM words where ID = " + whichWord, connectionToDB);

            connectionToDB.Open();

            word = (string)query.ExecuteScalar();
        }

        public void setLives()
        {
            lives = 3;
        }

        public string getWord()
        {
            return word;
        }

    }
}
