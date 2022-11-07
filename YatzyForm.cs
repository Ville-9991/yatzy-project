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
            diceImageList.Add(new DiceImage(new Bitmap(filename: $"img\\Dice{diceResultList[index]}.png")));
        }

        diceResultList.Clear();

        allowedNumberOfThrows.Text = Convert.ToString(throws_left -1);

        enableDiceButtons();

    }

    private int throwDice(){
        Random rng = new Random();
        int value = rng.Next(1, 7);
        return value;
    }

    private bool dice_IsThrown = false;

    private void enableDiceButtons(){

        dice_IsThrown = true;
        diceWindow.Invalidate();

        var dice_button_list = getAllPictureBoxes();

        foreach(PictureBox dice_button in dice_button_list){
            dice_button.Invalidate();
            dice_button.Enabled = true;
        }
    }

    private List<PictureBox> getAllPictureBoxes(){
        List<PictureBox> pictureBoxes = new List<PictureBox>();

        foreach (PictureBox control in diceResultsWindow.Controls){
            pictureBoxes.Add(control);
        }
        return pictureBoxes;
    }

    // leveys ja pituus ovat luokan sisäisesti "globaaleja", jotta niitä voi käyttää kaikissa funktioissa
    private int img_width = 75;
    private int img_height = 75;

    private void diceWindow_Paint(object sender, PaintEventArgs e)
    {

        int pointX;
        int pointY;

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

            // käydään jokainen suorakulmio läpi, jotta voidaan välttyä kuvien päällekkäisyydeltä
            foreach(Rectangle rect in storedRectangles.Where((a,b) => b != index).ToList()){ // lambda, joka ohittaa "tämän hetkisen" kierroksen suorakulmion (index), jotta vältytään "itseeän" vertaamasta "itseensä"

                if(storedRectangles[index].IntersectsWith(rect)){

                    if(storedRectangles[index].X < rect.X && storedRectangles[index].Y > rect.Y){
                        storedRectangles[index] = new Rectangle(storedRectangles[index].X + 50, storedRectangles[index].Y, img_width, img_height);
                    }

                    else if(storedRectangles[index].X > rect.X && storedRectangles[index].Y < rect.Y){
                        storedRectangles[index] = new Rectangle(storedRectangles[index].X, storedRectangles[index].Y + 50, img_width, img_height);
                    }

                    else if(storedRectangles[index].X == rect.X && storedRectangles[index].Y == rect.Y){
                        storedRectangles[index] = new Rectangle(storedRectangles[index].X + 50, storedRectangles[index].Y + 50, img_width, img_height);
                    }

                }

            }

        }

        for(int index = 0; index < diceList.Count(); index++){
            Bitmap img = new Bitmap(filename: $"img\\Dice{diceList[index].dice_value}.png");
            e.Graphics.DrawImage(img, storedRectangles[index]); // kuvien sijoittaminen suorakulmioiden mukaan
        }

        storedRectangles.Clear();
        diceList.Clear(); // noppalista on tyhjennettävä, muuten joka kerralla luodaan aina lisää noppia...

        // TODO kuvien tallessa pitäminen
        diceImageList.Clear(); // samoin myös kuvalista, mutta on keksittävä jokin keino miten kuvat voi pitää tallessa käyttäjän valinnan mukaan

    }

    List<DiceImage> diceImageList = new List<DiceImage>();

    #region Dice Button Paint events
    private void diceButton1_Paint(object sender, PaintEventArgs e){
             // koska paint event latautuu heti, eikä kuvaa/listan elementtejä ole vielä "olemassakaan" ennen kuin noppaa heitetään
            // tulee error, jokka "voidaan" ohittaa
            if(dice_IsThrown){
                e.Graphics.DrawImage(diceImageList[0].dice_image, 0, 0, img_width, img_height);
            }
    }

    // private void resultsWindow_mouseDown_Event(object sender, MouseEventArgs e)
    // {
    //     Console.WriteLine(Cursor.Position);
    // }

    private void diceButton2_Paint(object sender, PaintEventArgs e){
        if(dice_IsThrown){
            e.Graphics.DrawImage(diceImageList[1].dice_image, 0, 0, img_width, img_height);
        }
    }

    private void diceButton3_Paint(object sender, PaintEventArgs e){
        if(dice_IsThrown){
            e.Graphics.DrawImage(diceImageList[2].dice_image, 0, 0, img_width, img_height);
        }
    }

    private void diceButton4_Paint(object sender, PaintEventArgs e){
        if(dice_IsThrown){
            e.Graphics.DrawImage(diceImageList[3].dice_image, 0, 0, img_width, img_height);
        }
    }

    private void diceButton5_Paint(object sender, PaintEventArgs e){
        if(dice_IsThrown){
            e.Graphics.DrawImage(diceImageList[4].dice_image, 0, 0, img_width, img_height);
        }
    }
    #endregion

    // #region Dice Button click functions
    // private void diceButton1_Click(object sender, EventArgs e){
    //     diceButton1.Enabled = false;
    //     Console.WriteLine("test");
    // }

    // private void diceButton2_Click(object sender, EventArgs e){
    //     diceButton2.Enabled = false;
    // }

    // private void diceButton3_Click(object sender, EventArgs e){
    //     diceButton3.Enabled = false;
    // }

    // private void diceButton4_Click(object sender, EventArgs e){
    //     diceButton4.Enabled = false;
    // }

    // private void diceButton5_Click(object sender, EventArgs e){
    //     diceButton5.Enabled = false;
    // }
    // #endregion

    private bool[] dice_selected = {false, false, false, false, false};

    #region Custom Classes
    class Dice{ // luokka, joka ottaa talteen nopan arvon, jotta sitä voidaan käyttää muissakin eventeissä
        public int dice_value {get; set;}
        public bool selected = false;
        // public int posiotionX {get; set;}
        // public int posiotionY {get; set;}
        // public int width {get; set;}
        // public int height {get; set;}
 

        public Dice(int dice_value){
            this.dice_value = dice_value;
        }

        public void DrawDice(){

            Bitmap dice_image = new Bitmap(filename: $"img\\Dice{this.dice_value}.png");

            // YatzyForm form = new YatzyForm();

            // // if(selected){
                
            // // }
        }

        // private void CheckIfDiceIsClicked(Point location){
        //     if 
        // }

    }

    class DiceImage{ // luokka, joka ottaa talteen bitmap olion, jolla on filename mukana
        public Bitmap dice_image {get; set;}

        public DiceImage(Bitmap bitmap_file_path){
            dice_image = bitmap_file_path;
        }
    }
    #endregion
}