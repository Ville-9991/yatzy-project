namespace yatzy_project;

public partial class YatzyForm : Form
{
    public YatzyForm()
    {
        InitializeComponent();
    }

    // alustetaan Dice-luokasta lista, jotta voidaan ottaan talteen useampia noppien arvoja ja käyttää nitä myöhemmin
    List<Dice> diceList = new List<Dice>();

    private void throwDice_btn_Click(object sender, EventArgs e)
    {
        
        int dice_result = throwDice();
        diceList.Add(new Dice(dice_result));
        diceWindow.Invalidate();
    }

    private int throwDice(){
        Random rng = new Random();
        int value = rng.Next(1, 7);
        return value;
    }

    private void diceWindow_Paint(object sender, PaintEventArgs e)
    {

        Random rng = new Random();
        int locationX = rng.Next(0, 500);
        int locationY = rng.Next(0, 250);

        foreach(Dice dice in diceList){
            Bitmap img = new Bitmap(filename: $"img\\Dice{dice.dice_value}.png");
            e.Graphics.DrawImage(img, locationX, locationY);
        }

        diceList.Clear(); // noppalista on tyhjennettävä, muuten joka kerralla luodaan aina lisää noppia...

    }
    
}

class Dice{ // luokka, joka ottaa talteen nopan arvon, jotta sitä voidaan käyttää muissakin "eventeissä"
    public int dice_value {get; set;}

    public Dice(int value){
        dice_value = value;
    }

}