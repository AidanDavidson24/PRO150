namespace Poke_Adventures.Models
{
    public class AttackFunction
    {
        static bool IsAttack = false;

        public static int? Attack(int? curHP, string attackingPokemon, string defendingPokemon, int move)
        {
            int? currentHP = curHP;

            int? damage = PokemonModel.AttackDamage(MoveElements.LoadMove(PokemonElements.LoadPokemon(attackingPokemon).Moves[move].Move).ID, attackingPokemon, defendingPokemon);

            System.Diagnostics.Debug.WriteLine(PokemonModel.AttackDamage(5, PlayerModel.PlayerTeam[0].Name, PlayerModel.PlayerTeam[1].Name) + " Move");

            System.Diagnostics.Debug.WriteLine(currentHP + " Enemy HP");

            int? newHP = currentHP -= damage;

            System.Diagnostics.Debug.WriteLine(currentHP + " Enemy HP");

            return newHP;
        }

        public static int? EnemyAttack(int? curHP)
        {
            List<int> Moves = new List<int> 
            {
                MoveElements.LoadMove(PokemonElements.LoadPokemon(PlayerModel.PlayerTeam[1].Name).Moves[2].Move).ID,
                MoveElements.LoadMove(PokemonElements.LoadPokemon(PlayerModel.PlayerTeam[1].Name).Moves[4].Move).ID,
                MoveElements.LoadMove(PokemonElements.LoadPokemon(PlayerModel.PlayerTeam[1].Name).Moves[5].Move).ID,
                MoveElements.LoadMove(PokemonElements.LoadPokemon(PlayerModel.PlayerTeam[1].Name).Moves[6].Move).ID
            };
            Random random = new Random();

            int? currentHP = curHP;

            int? damage = PokemonModel.AttackDamage(Moves[random.Next(Moves.Count())], PlayerModel.PlayerTeam[1].Name, PlayerModel.PlayerTeam[4].Name);

            System.Diagnostics.Debug.WriteLine(PokemonModel.AttackDamage(5, PlayerModel.PlayerTeam[1].Name, PlayerModel.PlayerTeam[4].Name) + " Move");
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
                //PokemonModel.EnemyHP = Attack(PokemonModel.EnemyHP);
                return PokemonModel.EnemyHP;
            }
            else
            {
                return PokemonModel.EnemyHP;
            }

        }

        public static bool Damage(string PKID, string otherPokemon, int move)
        {
            PokemonModel.EnemyHP = AttackFunction.Attack(PokemonModel.EnemyHP, PKID, otherPokemon, move);

            return true;
        }
    }
}