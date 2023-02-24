namespace Poke_Adventures.Models
{
    public class PokemonModel
    {
        public static int bulbHP = Pokemon.GetBulbHP();
        public static int? charHP = Pokemon.GetCharHP();

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

        public static List<int> MakePokemon(int ID)
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

        public static int? AttackDamage(int MoveID, int PKID)
        {
            Random rand = new Random();
            int? Damage;
            int? Power = MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Power;
            float crit = 1;
            float STAB = 1;
            float? critDamage = crit;

            if ((float)rand.NextDouble() >= 1 / 24)
            {
                crit = 1.5f;
            }

            if (PokemonElements.LoadPokemon(PKID).Types[0].Type == MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Type || PokemonElements.LoadPokemon(PKID).Types[1].Type == MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Type)
            {
                STAB = 1.5f;
            }


            if (MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Damage_Class.Name == "physical")
            {
                Damage = Convert.ToInt32(Math.Floor((decimal)(((((((2 / level) / 5) + 2) * Power * (MakePokemon(PKID)[1] / 10)) / 50) + 2) * critDamage * rand.Next(85, 100) / 100 * STAB)));
            }
            else if (MoveElements.LoadMove(PokemonElements.LoadPokemon(PKID).Moves[MoveID].Move).Damage_Class.Name == "special")
            {
                Damage = Convert.ToInt32(Math.Floor((decimal)(((((((2 / level) / 5) + 2) * Power * (31 / 10)) / 50) + 2) * critDamage * rand.Next(85, 100) / 100 * STAB)));
            }
            else
            {
                Damage = 0;
            }

            return Damage;
        }
    }
}
