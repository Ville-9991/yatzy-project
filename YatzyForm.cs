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
        int throws_left = Int32.Parse(allowedNumberOfThrows.Text); // heittoja on aluksi kolme
        
        if (throws_left  == 1){
            throwDice_btn.Enabled = false;
        }

        List<int> diceResultList = new List<int>();

        for(int number_of_dice = 0; number_of_dice < 5; number_of_dice++){
            int dice_result = throwDice();
            diceResultList.Add(dice_result);
        }

        for(int index = 0; index < diceResultList.Count(); index++){
            diceList.Add(new Dice(diceResultList[index]));
        }

        diceWindow.Invalidate();


        allowedNumberOfThrows.Text = Convert.ToString(throws_left -1);

    }

    private int throwDice(){
        Random rng = new Random();
        int value = rng.Next(1, 7);
        return value;
    }

    private void diceWindow_Paint(object sender, PaintEventArgs e)
    {

        Random rng = new Random();

        for(int index = 0; index < diceList.Count(); index++){

            int locationX = rng.Next(0, 500);
            int locationY = rng.Next(0, 250);

            Bitmap img = new Bitmap(filename: $"img\\Dice{diceList[index].dice_value}.png");
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