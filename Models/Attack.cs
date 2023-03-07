using System.Diagnostics;

namespace Poke_Adventures.Models
{
    public class AttackFunction
    {

        public static int? Attack(int? curHP, string attackingPokemon, string defendingPokemon, int move)
        {
            int? currentHP = curHP;

            //int? damage = PokemonModel.AttackDamage(MoveElements.LoadMove(PokemonElements.LoadPokemon(attackingPokemon).Moves[move].Move).ID, attackingPokemon, defendingPokemon);
            int? damage = PokemonModel.AttackDamage(move, attackingPokemon, defendingPokemon);

            //int damage = 10;
            Debug.WriteLine(damage + " Damage");

            System.Diagnostics.Debug.WriteLine(PokemonModel.AttackDamage(move, PlayerModel.PlayerTeam[0].Name, PlayerModel.PlayerTeam[1].Name) + " Move");

            System.Diagnostics.Debug.WriteLine(currentHP + " Enemy HP");

            int? newHP = currentHP -= damage;

            System.Diagnostics.Debug.WriteLine(currentHP + " Enemy HP");

            return newHP;
        }

        public static int? EnemyAttack(int? curHP)
        {
            List<int> Moves = new List<int> 
            {
                MoveElements.LoadMove(PokemonElements.LoadPokemon(TrainerModel.TrainerTeam[0].Name).Moves[0].Move).ID,
                MoveElements.LoadMove(PokemonElements.LoadPokemon(TrainerModel.TrainerTeam[0].Name).Moves[1].Move).ID,
                MoveElements.LoadMove(PokemonElements.LoadPokemon(TrainerModel.TrainerTeam[0].Name).Moves[2].Move).ID,
                MoveElements.LoadMove(PokemonElements.LoadPokemon(TrainerModel.TrainerTeam[0].Name).Moves[3].Move).ID
            };
            Random random = new Random();

            int? currentHP = curHP;

            int? damage = PokemonModel.AttackDamage(Moves[random.Next(Moves.Count())], TrainerModel.TrainerTeam[0].Name, PlayerModel.PlayerTeam[0].Name);

            //System.Diagnostics.Debug.WriteLine(PokemonModel.AttackDamage(5, PlayerModel.PlayerTeam[1].Name, PlayerModel.PlayerTeam[4].Name) + " Move");
            //System.Diagnostics.Debug.WriteLine(Moves[random.Next(Moves.Count())] + " Moves");

            System.Diagnostics.Debug.WriteLine(currentHP + " Char HP");

            int? newHP = currentHP -= damage;

            System.Diagnostics.Debug.WriteLine(currentHP + " Char HP");

            return PokemonModel.PlayerHP = newHP;
        }

        public static int? Damage(string PKID, string otherPokemon, int move)
        {
            return PokemonModel.EnemyHP = Attack(PokemonModel.EnemyHP, PKID, otherPokemon, move);
        }

        public static int? WildDamage(int CurWildHP, string PKID, string otherPokemon, int move)
        {
            return PokemonModel.WildHP = Attack(CurWildHP, PKID, otherPokemon, move);
        }
    }
}