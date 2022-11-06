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
        diceResultsWindow.Invalidate();
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

        for(int index = 0; index < diceList.Count(); index++){
            // suorakulmioiden mittojen määrittäminen/sijaintin arvonta

            pointX = rng.Next(0, diceWindow.Size.Width-(img_width*2));
            pointY = rng.Next(0, diceWindow.Size.Height-(img_height*2));

            image_dimensions.X = pointX;
            image_dimensions.Y = pointY;

            storedRectangles.Add(image_dimensions);

            if (index != 0){
                foreach(Rectangle rect in storedRectangles.ToList()){

                    if(storedRectangles[index].IntersectsWith(rect)){

                        if(storedRectangles[index].X < rect.X && storedRectangles[index].Y > rect.Y){
                            storedRectangles[index] = new Rectangle(rect.X + 50, rect.Y, img_width, img_height);
                        }

                        else if(storedRectangles[index].X > rect.X && storedRectangles[index].Y < rect.Y){
                            storedRectangles[index] = new Rectangle(rect.X, rect.Y + 50, img_width, img_height);
                        }

                        else if(storedRectangles[index].X == rect.X && storedRectangles[index].Y == rect.Y){
                            storedRectangles[index] = new Rectangle(rect.X + 50, rect.Y + 50, img_width, img_height);
                        }

                    }

                }
            }

        }

        for(int index = 0; index < diceList.Count(); index++){
            // kuvien sijoittaminen suorakulmioiden mukaan

            Bitmap img = new Bitmap(filename: $"img\\Dice{diceList[index].dice_value}.png");
            e.Graphics.DrawImage(img, storedRectangles[index]);
        }

        storedRectangles.Clear();
        diceList.Clear(); // noppalista on tyhjennettävä, muuten joka kerralla luodaan aina lisää noppia...

    }

    private void diceResultsWindow_Paint(object sender, PaintEventArgs e)
    {

        int img_width = 75;
        int img_height = 75;
        int pointX = img_width/4;
        int pointY = diceResultsWindow.Height-img_height;

        // muuttuja, joka tekee hieman väliä seuraaville kuville
        // älä muuta. Toimii vain 1:1 kuville
        int margin = (((img_width/2)*2)+img_width/4); // 112,5

        List<Rectangle> storedRectangles = new List<Rectangle>();
        Rectangle image_dimensions = new Rectangle(pointX, pointY, img_width, img_height);

        List<int> diceResultList = new List<int>();

        foreach(Dice dice in diceList){
            diceResultList.Add(dice.dice_value);
        }

        // diceList.Sort();
        for(int index = 0; index < diceResultList.Count(); index++){
            Bitmap img = new Bitmap(filename: $"img\\Dice{diceResultList[index]}.png");

            storedRectangles.Add(image_dimensions);
            
            if(index == 0){
                e.Graphics.DrawImage(img, storedRectangles[index]);
            }
            else{
                storedRectangles[index] = new Rectangle(storedRectangles[index-1].X + margin, pointY, img_width, img_height);
                e.Graphics.DrawImage(img, storedRectangles[index]);
            }
            
        }
        
    }
}

class Dice{ // luokka, joka ottaa talteen nopan arvon, jotta sitä voidaan käyttää muissakin "eventeissä"
    public int dice_value {get; set;}

    public Dice(int value){
        dice_value = value;
    }

}