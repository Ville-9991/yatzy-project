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

        diceWindow.Invalidate();

        diceButton1.Invalidate();
        diceButton2.Invalidate();
        diceButton3.Invalidate();
        diceButton4.Invalidate();
        diceButton5.Invalidate();

        allowedNumberOfThrows.Text = Convert.ToString(throws_left -1);

    }

    private int throwDice(){
        Random rng = new Random();
        int value = rng.Next(1, 7);
        return value;
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

    private void diceButton1_Paint(object sender, PaintEventArgs e){
        try{ // koska paint event latautuu heti, eikä kuvaa/listan elementtejä ole vielä "olemassakaan" ennen kuin noppaa heitetään
            // tulee error, jokka "voidaan" ohittaa
            e.Graphics.DrawImage(diceImageList[0].dice_image, 0, 0, img_width, img_height);
        }
        catch{
            return;
        }
    }

    private void diceButton2_Paint(object sender, PaintEventArgs e){
        try{
            e.Graphics.DrawImage(diceImageList[1].dice_image, 0, 0, img_width, img_height);
        }
        catch{
            return;
        }
    }

    private void diceButton3_Paint(object sender, PaintEventArgs e){
        try{
            e.Graphics.DrawImage(diceImageList[2].dice_image, 0, 0, img_width, img_height);
        }
        catch{
            return;
        }
    }

    private void diceButton4_Paint(object sender, PaintEventArgs e){
        try{
            e.Graphics.DrawImage(diceImageList[3].dice_image, 0, 0, img_width, img_height);
        }
        catch{
            return;
        }
    }

    private void diceButton5_Paint(object sender, PaintEventArgs e){
        try{
            e.Graphics.DrawImage(diceImageList[4].dice_image, 0, 0, img_width, img_height);
        }
        catch{
            return;
        }
    }
}

class Dice{ // luokka, joka ottaa talteen nopan arvon, jotta sitä voidaan käyttää muissakin eventeissä
    public int dice_value {get; set;}

    public Dice(int value){
        dice_value = value;
    }

}

class DiceImage{ // luokka, joka ottaa talteen bitmap olion, jolla on filename mukana
    public Bitmap dice_image {get; set;}

    public DiceImage(Bitmap bitmap_file_path){
        dice_image = bitmap_file_path;
    }
}