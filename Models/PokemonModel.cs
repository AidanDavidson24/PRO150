namespace Poke_Adventures.Models
{
    public class PokemonModel
    {
        public static int HP;
        public static int ATK;
        public static int DEF;
        public static int SPA;
        public static int SPD;
        public static int SPE;
        private static int IV;
        private static int EV;
        public static int level = 10;
        static Random rand = new Random();

        public static List<int> MakePokemon(int ID)
        {
            List<int> stats = new List<int>();
            IV = rand.Next(0, 31);
            EV = rand.Next(0, 255);

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

        public static int? AttackDamage(int ID)
        {
            int? Damage = 0;
            int? Power = MoveElements.LoadMove(PokemonElements.LoadPokemon(ID).Moves[ID].Move).Power;
            float crit = 1;
            float STAB = 1;
            float? critDamage = crit;

            if((float)rand.NextDouble() >= 1 / 24)
            {
                crit = 1.5f;
            }

            if (PokemonElements.LoadPokemon(ID).Types[0].Type == MoveElements.LoadMove(PokemonElements.LoadPokemon(ID).Moves[ID].Move).Type || PokemonElements.LoadPokemon(ID).Types[1].Type == MoveElements.LoadMove(PokemonElements.LoadPokemon(ID).Moves[ID].Move).Type)
            {
                STAB = 1.5f;
            }


            if (MoveElements.LoadMove(PokemonElements.LoadPokemon(ID).Moves[ID].Move).Damage_Class.Name == "physical")
            {
                Damage = Convert.ToInt32(((((((2 / level) / 5) + 2) * Power * (ATK / DEF)) / 50) + 2) * critDamage * rand.Next(85,100) * STAB);
            }

            return Damage;
        }
    }
}
