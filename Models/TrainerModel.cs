

namespace Poke_Adventures.Models
{
    public class TrainerModel
    {          
        // Trainer Team
        public static List<string> TrainerTeam = new List<string> { };


        // randomize team based on difficulty
        public void RandomizeTeam(string difficulty)
        {
            switch(difficulty)
            {
                case "Easy":
                    // min = plvlavg - 3
                    // max = plvlavg + 2
                    // pool = player pool
                    break;

                case "Medium":
                    // min = plvlavg
                    // max = plvlavg + 5
                    // pool = player pool
                    break;

                case "Hard":
                    // min = plvlavg + 1
                    // max = plvlavg + 8
                    // pool = player pool + 1
                    break;
            }
        }


        // 
    }
}
