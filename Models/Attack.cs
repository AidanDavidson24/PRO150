
namespace Poke_Adventures.Models
{
    public class AttackFunction
    {
        public static int? Attack(int? charHP)
        {
            
            int? currentHP = charHP;

            //var damage = PokemonModel.AttackDamage(MoveElements.LoadMove().ID, 4);



            var damage = 10;

            System.Diagnostics.Debug.WriteLine(currentHP + " HP");

            int? newHP = currentHP -= damage;

            System.Diagnostics.Debug.WriteLine(currentHP + " HP");

            return newHP;
        }
    }
}