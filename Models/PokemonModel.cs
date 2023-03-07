using System.Diagnostics;
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
        public static int level = 5;
        public static MoveElements move1;
        public static MoveElements? move2;
        public static MoveElements? move3;
        public static MoveElements? move4;
        public static int tries = 0;
        public static int? MaxWildHP;
        public static int? WildHP;

        public static List<Pokemon> pokemonTeam = new List<Pokemon>();

        public static List<int> MakePokemon(string Name)
        {
            List<int> stats = new List<int>();

            HP = ((2 * PokemonElements.LoadPokemon(Name).Stats[0].Base_Stat + IV + (EV / 4) * level) / 100) + level + 10;
            ATK = ((2 * PokemonElements.LoadPokemon(Name).Stats[1].Base_Stat + IV + (EV / 4) * level) / 100) + 5;
            DEF = ((2 * PokemonElements.LoadPokemon(Name).Stats[2].Base_Stat + IV + (EV / 4) * level) / 100) + 5;
            SPA = ((2 * PokemonElements.LoadPokemon(Name).Stats[3].Base_Stat + IV + (EV / 4) * level) / 100) + 5;
            SPD = ((2 * PokemonElements.LoadPokemon(Name).Stats[4].Base_Stat + IV + (EV / 4) * level) / 100) + 5;
            SPE = ((2 * PokemonElements.LoadPokemon(Name).Stats[5].Base_Stat + IV + (EV / 4) * level) / 100) + 5;

            stats.Add(HP);
            stats.Add(ATK);
            stats.Add(DEF);
            stats.Add(SPA);
            stats.Add(SPD);
            stats.Add(SPE);
            return stats;
        }

        public static int? AttackDamage(int MoveID, string attacking, string defending)
        {
            Random rand = new Random();
            float randNum = rand.Next(85, 100);
            int? Damage;
            int? Power = MoveElements.LoadMove(PokemonElements.LoadPokemon(attacking).Moves[MoveID].Move).Power;
            float crit = 1;
            float STAB = 1;
            float? critDamage = crit;

            if ((float)rand.NextDouble() >= 1 / 24)
            {
                crit = 1.5f;
            }
            if (PokemonElements.LoadPokemon(attacking).Types.Count == 2)
            {
                if (PokemonElements.LoadPokemon(attacking).Types[0].Type == MoveElements.LoadMove(PokemonElements.LoadPokemon(attacking).Moves[MoveID].Move).Type)
                {
                    STAB = 1.5f;
                } else if(PokemonElements.LoadPokemon(attacking).Types[1].Type == MoveElements.LoadMove(PokemonElements.LoadPokemon(attacking).Moves[MoveID].Move).Type)
                {
                    STAB = 1.5f;
                }
                else
                {
                    STAB = 1;
                }
            } else if(PokemonElements.LoadPokemon(attacking).Types.Count == 1)
            {
                if (PokemonElements.LoadPokemon(attacking).Types[0].Type == MoveElements.LoadMove(PokemonElements.LoadPokemon(attacking).Moves[MoveID].Move).Type)
                {
                    STAB = 1.5f;
                }
                else
                {
                    STAB = 1;
                }
            }

            if (MoveElements.LoadMove(PokemonElements.LoadPokemon(attacking).Moves[MoveID].Move).Damage_Class.Name == "physical")
            {
                Damage = Convert.ToInt32(Math.Floor((decimal)((((((2 * level) / 5) + 2) * Power * (MakePokemon(attacking)[1] / (double)MakePokemon(defending)[2]) / 50) + 2) * critDamage * (randNum / 100) * STAB)));
            }
            else if (MoveElements.LoadMove(PokemonElements.LoadPokemon(attacking).Moves[MoveID].Move).Damage_Class.Name == "special")
            {

                Damage = Convert.ToInt32(Math.Floor((double)((((((2 * level / 5) + 2) * Power * (MakePokemon(attacking)[3] / (double)MakePokemon(defending)[4])) / 50) + 2) * critDamage * (randNum / 100) * STAB)));
            }
            else
            {
                Damage = 0;
            }

            return Damage;
        }

        
        public static int? MaxEnemyHP = Pokemon.GetEnemyHP(PlayerModel.PlayerTeam[0].Name);
        public static int? EnemyHP = MaxEnemyHP;
        public static int? PlayerHP = Pokemon.GetPlayerHP();
        public static int? MaxPlayerHP = PlayerHP;

        public static bool CatchPokemon()
        {
            int capRate = SpeciesProp.LoadSpecies(PokemonElements.LoadPokemon(PlayerModel.PlayerTeam[0].Name).Species).Capture_Rate;
            double? catchRate;
            double? shakeProb;
            int shakeCheck = new Random().Next(0, 65535);
            

            System.Diagnostics.Debug.WriteLine(MaxEnemyHP + " Enemy HP");
            System.Diagnostics.Debug.WriteLine(MaxPlayerHP + " Player HP");

            catchRate = ((3 * MaxWildHP - 2 * WildHP) * capRate * 1) / (double)(3 * MaxWildHP);

            shakeProb = 1048560 / (double)Math.Floor(Math.Sqrt(Math.Sqrt(16711680 / (double)catchRate)));

            if(shakeProb > shakeCheck)
            {
                System.Diagnostics.Debug.WriteLine("Pokemon Caught");
                PlayerModel.AddPokemon(Routes.WildPK.Name, 5);
                ResetPK();
                
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(shakeProb);

                return false;
            }
        }

        public static void ResetPK()
        {
            Routes.location = LocationElements.LoadLocation(Routes.ActiveRoute()[LoadLocation.AreaNum]).Areas[0];
            Routes.WildPK = LocationAreaElements.LoadLocationArea(Routes.location).Pokemon_Encounters[LoadLocation.rand.Next(0, LocationAreaElements.LoadLocationArea(Routes.location).Pokemon_Encounters.Count)].Pokemon;

            MaxWildHP = Pokemon.GetWildHP(Routes.WildPK.Name);
            WildHP = MaxWildHP;
        }

        public static List<MoveElements> ActiveMove(string PKID)
        {
            List<MoveElements> Moves = new List<MoveElements>();

            move1 = MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[0].Move);
            move2 = MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[1].Move);
            move3 = MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[2].Move);
            move4 = MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[3].Move);

            Moves.Add(move1);
            Moves.Add(move2);
            Moves.Add(move3);
            Moves.Add(move4);
            

            return Moves;
        }
        
        public static void MakeEnemy(string difficulty)
        {
            TrainerModel.RandomizeTeam(difficulty);
        }
    }
}
