using System.IO;
using System.Runtime.CompilerServices;

namespace Poke_Adventures.Models
{
    public class PokemonModel
    {
        static Random randStat = new Random();
        public static int HP;
        public static int ATK;
        public static int DEF;
        public static int SPA;
        public static int SPD;
        public static int SPE;
        private static int IV = randStat.Next(0,31);
        private static int EV = randStat.Next(0,255);
        public static int level = 100;

        public static List<Pokemon> pokemonTeam = new List<Pokemon>();

        public static List<int> MakePokemon(Common ID)
        {
            List<int> stats = new List<int>();


            HP = ((2 * PokemonElements.LoadPokemon(ID).Stats[0].Base_Stat + IV + (EV / 4) * level) / 100) + level + 10;
            ATK = ((2 * PokemonElements.LoadPokemon(ID).Stats[1].Base_Stat + IV + (EV / 4) * level) / 100) + 5;
            DEF = ((2 * PokemonElements.LoadPokemon(ID).Stats[2].Base_Stat + IV + (EV / 4) * level) / 100) + 5;
            SPA = ((2 * PokemonElements.LoadPokemon(ID).Stats[3].Base_Stat + IV + (EV / 4) * level) / 100) + 5;
            SPD = ((2 * PokemonElements.LoadPokemon(ID).Stats[4].Base_Stat + IV + (EV / 4) * level) / 100) + 5;
            SPE = ((2 * PokemonElements.LoadPokemon(ID).Stats[5].Base_Stat + IV + (EV / 4) * level) / 100) + 5;

            stats.Add(HP);
            stats.Add(ATK);
            stats.Add(DEF);
            stats.Add(SPA);
            stats.Add(SPD);
            stats.Add(SPE);
            return stats;
        }

        public static int? AttackDamage(int MoveID, Common PKID, Common PKID2)
        {
            Random rand = new Random();
            float randNum = rand.Next(85, 100);
            int? Damage;
            int? Power = MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Power;
            float crit = 1;
            float STAB = 1;
            float? critDamage = crit;

            if ((float)rand.NextDouble() >= 1 / 24)
            {
                crit = 1.5f;
            }
            if (PokemonElements.LoadPokemon(PKID).Types.Count == 2)
            {
                if (PokemonElements.LoadPokemon(PKID).Types[0].Type == MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Type)
                {
                    STAB = 1.5f;
                } else if(PokemonElements.LoadPokemon(PKID).Types[1].Type == MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Type)
                {
                    STAB = 1.5f;
                }
                else
                {
                    STAB = 1;
                }
            } else if(PokemonElements.LoadPokemon(PKID).Types.Count == 1)
            {
                if (PokemonElements.LoadPokemon(PKID).Types[0].Type == MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Type)
                {
                    STAB = 1.5f;
                }
                else
                {
                    STAB = 1;
                }
            }


            if (MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Damage_Class.Name == "physical")
            {
                Damage = Convert.ToInt32(Math.Floor((decimal)(((((2 * level / 5) + 2) * Power * (MakePokemon(PKID)[1] / MakePokemon(PKID2)[2]) / 50) + 2) * critDamage * (randNum / 100) * STAB)));
                
            }
            else if (MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Damage_Class.Name == "special")
            {
                Damage = Convert.ToInt32(Math.Floor((decimal)(((((((2 * level) / 5) + 2) * Power * (MakePokemon(PKID)[3] / MakePokemon(PKID2)[4])) / 50) + 2) * critDamage * (randNum / 100) * STAB)));
            }
            else
            {
                Damage = 0;
            }

            return Damage;
        }

        public static int? EnemyHP = Pokemon.GetEnemyHP();
        public static int? MaxEnemyHP = EnemyHP;
        public static int? PlayerHP = Pokemon.GetPlayerHP();
        public static int? MaxPlayerHP = PlayerHP;

        public static bool CatchPokemon()
        {
            int capRate = SpeciesProp.LoadSpecies(PlayerModel.Team()[0]).Capture_Rate;
            int? catchRate;

            System.Diagnostics.Debug.WriteLine(MaxEnemyHP + " Enemy HP");
            System.Diagnostics.Debug.WriteLine(MaxPlayerHP + " Player HP");

            catchRate = ((3 * MaxEnemyHP - 2 * EnemyHP) * capRate * 1) / (3 * MaxEnemyHP);

            if(catchRate >= 255)
            {
                System.Diagnostics.Debug.WriteLine("Pokemon Caught");
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(catchRate);
                return false;
            }

        }
    
    
    }
}
