
using System.Reflection.PortableExecutable;

public interface ICharacter
{
    void Attack();
    void Defend();

}

public interface ISpecialAbility
{

    void UseSpecial();

}






public class Knight : ICharacter
{
    public void Attack()
    {
        Console.WriteLine("The Knight Attacks");
    }
    public void Defend()
    {
        Console.WriteLine("The Knight defends");
    }
}

public class Wizard : ICharacter, ISpecialAbility
{
    public void Attack()
    {
        Console.WriteLine("The Wizard Attacks");
    }
    public void Defend()
    {
        Console.WriteLine("The Wizard defends");
    }
    public void UseSpecial()
    {
        Console.WriteLine("The Wizard Now uses It's special ability");
    }
}

public class Mage : ICharacter, ISpecialAbility
{
    public void Attack()
    {
        Console.WriteLine("The Mage Attacks");
    }
    public void Defend()
    {
        Console.WriteLine("The Mage defends");
    }
    public void UseSpecial()
    {
        Console.WriteLine("The Mage Now uses It's special ability");
    }
}






public class Game
{
    public static void Main()
    {
        ICharacter knight = new Knight();
        Mage mage = new Mage();
        Wizard wizard = new Wizard();

        List<ICharacter> characters = new List<ICharacter>();
        characters.Add(knight);
        characters.Add(mage);
        characters.Add(wizard);


        foreach (ICharacter character in characters)
        {
            character.Attack();
            character.Defend();

            if (character is ISpecialAbility special)
            {
                special.UseSpecial();
            }
            Console.WriteLine("");

        }








    }






}
