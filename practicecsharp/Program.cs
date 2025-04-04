
public interface ICharacter
{
    void Attack();
    void Defend();

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

public class Wizard : ICharacter
{
    public void Attack()
    {
        Console.WriteLine("The Wizard Attacks");
    }
    public void Defend()
    {
        Console.WriteLine("The Wizard defends");
    }
}


public class Game
{
    public static void Main()
    {
        ICharacter knight = new Knight();
        ICharacter wizard = new Wizard();


        knight.Attack();
        knight.Defend();

        wizard.Attack();
        wizard.Defend();

    }






}
