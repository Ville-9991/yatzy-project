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
        diceResultList.Clear();

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

        int pointX;
        int pointY;
        int img_width = 75;
        int img_height = 75;

        // luodaan lista, johon otetaan talteen suorakulmioiden mitat,
        // jotta voidaan verrata niiden päällekkäisyyttä
        // yrittää välttää sitä
        List<Rectangle> storedRectangles = new List<Rectangle>();

        Rectangle image_dimensions = new Rectangle(0, 0, img_width, img_height);

        Random rng = new Random(); // siajinnit on satunnaisia, jotta voidaan simuloida 2d noppien "autenttisuus"

        // lisätään tyhjä rectangle listaan, jotta if tarkastus voi ohittaa sen myöhemmin
        // storedRectangles.Add(image_dimensions);

        for(int index = 0; index < diceList.Count(); index++){
            Bitmap img = new Bitmap(filename: $"img\\Dice{diceList[index].dice_value}.png");

            pointX = rng.Next(0, diceWindow.Size.Width-img_width);
            pointY = rng.Next(0, diceWindow.Size.Height-img_height);

            image_dimensions.X = pointX;
            image_dimensions.Y = pointY;

            storedRectangles.Add(image_dimensions);

            if(index == 0){
                // ekalla kierroksella voi mennä suoraan tänne, koska ei ole tarvetta tarkastaa
                // kuvien päällekäisyyttä
                e.Graphics.DrawImage(img, storedRectangles[index]);
            }
            else{

                foreach(var rect in storedRectangles.ToList()){

                // tämän tarkastuksen takia kierrokset oli eroteltava, koska muuten kuvaa ei piirrettä
                // (ensimmäisellä kierroksella ehto on aina tosi)
                if(image_dimensions.IntersectsWith(rect)){ 

                    int colliding_item = storedRectangles.FindIndex(r => r == rect);
                    if (colliding_item != -1){
                        // en käytä nyt enempää aikaa hiusten repimiseen ja random sijaintien päällekkäisyyden tarkastamiseen/korjaamiseen
                        // saa luvan kelvata
                        storedRectangles[colliding_item] = new Rectangle(rng.Next(0, img_width), rng.Next(0, img_height), img_width, img_height);
                    }
                    
                }

                else{
                    e.Graphics.DrawImage(img, storedRectangles[index]);
                }

            }
                
            }

        }

        storedRectangles.Clear();
        diceList.Clear(); // noppalista on tyhjennettävä, muuten joka kerralla luodaan aina lisää noppia...

    }
    
}

class Dice{ // luokka, joka ottaa talteen nopan arvon, jotta sitä voidaan käyttää muissakin "eventeissä"
    public int dice_value {get; set;}

    public Dice(int value){
        dice_value = value;
    }

}