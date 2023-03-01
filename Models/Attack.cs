namespace Poke_Adventures.Models
{
    public class AttackFunction
    {
        static bool IsAttack = false;

        public static int? Attack(int? curHP)
        {
            int? currentHP = curHP;

            int? damage = PokemonModel.AttackDamage(MoveElements.LoadMove(PokemonElements.LoadPokemon(PlayerModel.Team()[3]).Moves[0].Move).ID, PlayerModel.Team()[0], PlayerModel.Team()[1]);

            System.Diagnostics.Debug.WriteLine(PokemonModel.AttackDamage(5, PlayerModel.Team()[0], PlayerModel.Team()[1]) + " Move");

            System.Diagnostics.Debug.WriteLine(currentHP + " Enemy HP");

            int? newHP = currentHP -= damage;

            System.Diagnostics.Debug.WriteLine(currentHP + " Enemy HP");

            return newHP;
        }

        public static int? EnemyAttack(int? curHP)
        {
            List<int> Moves = new List<int> 
            {
                MoveElements.LoadMove(PokemonElements.LoadPokemon(PlayerModel.Team()[1]).Moves[2].Move).ID,
                MoveElements.LoadMove(PokemonElements.LoadPokemon(PlayerModel.Team()[1]).Moves[4].Move).ID,
                MoveElements.LoadMove(PokemonElements.LoadPokemon(PlayerModel.Team()[1]).Moves[5].Move).ID,
                MoveElements.LoadMove(PokemonElements.LoadPokemon(PlayerModel.Team()[1]).Moves[6].Move).ID
            };
            Random random = new Random();

            int? currentHP = curHP;

            int? damage = PokemonModel.AttackDamage(Moves[random.Next(Moves.Count())], PlayerModel.Team()[1], PlayerModel.Team()[4]);

            System.Diagnostics.Debug.WriteLine(PokemonModel.AttackDamage(5, PlayerModel.Team()[1], PlayerModel.Team()[4]) + " Move");
            System.Diagnostics.Debug.WriteLine(Moves[random.Next(Moves.Count())] + " Moves");

            System.Diagnostics.Debug.WriteLine(currentHP + " Char HP");

            int? newHP = currentHP -= damage;

            System.Diagnostics.Debug.WriteLine(currentHP + " Char HP");

            return newHP;
        }

        public static int? ApplyDamage()
        {
            if (IsAttack)
            {
                IsAttack = false;
                return PokemonModel.EnemyHP;
            }
            else if(!IsAttack)
            {
                IsAttack = true;
                PokemonModel.EnemyHP = Attack(PokemonModel.EnemyHP);
                return PokemonModel.EnemyHP;
            }
            else
            {
                return PokemonModel.EnemyHP;
            }

        }
    }
}