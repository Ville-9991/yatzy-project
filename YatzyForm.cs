namespace yatzy_project;

public partial class YatzyForm : Form
{
    public YatzyForm()
    {
        InitializeComponent();
    }

    // alustetaan (listaksi) viisi noppaa, joilla on kuusi sivua, 
    // jotta niiden metodeja/arvoja voidaan käyttää myöhemmin
    Dice[] dices = {new Dice(), new Dice(), new Dice(), new Dice(), new Dice()};
    private bool[] dices_thrown = {false, false, false, false, false};
    private bool[] dice_selected = {false, false, false, false, false};
    private int[] results = {0, 0, 0, 0, 0};

    private void throwDice_btn_Click(object sender, EventArgs e)
    {
        int throws_left = Int32.Parse(allowedNumberOfThrows.Text); // heittoja on aluksi kolme
        
        if (throws_left  == 1){
            throwDice_btn.Enabled = false;
        }

        for(int dice_number = 0; dice_number < dices.Count(); dice_number++){
            dices[dice_number].rollDice();
        }

        allowedNumberOfThrows.Text = Convert.ToString(throws_left -1);

        enableDiceButtons();

        diceWindow.Visible = true;
        diceWindow.Invalidate();

    }

    private void enableDiceButtons(){

        for(int i = 0; i < dices_thrown.Count(); i++){
            dices_thrown[i] = true;
        }

        var dice_button_list = getAllPictureBoxes();

        int index = 0;
        foreach(PictureBox dice_button in dice_button_list){

            if(!dice_selected[index]){
                // ainoastaan valitsemattomat painikkeet aktivoidaan, 
                // koska muuten käyttäjä voi painaa nappia myös silloinkin kun ei saisi
                dice_button.Invalidate();

                dice_button.Enabled = true;
                dice_button.Visible = true;
            }
            else if (dice_selected[index]){
                dice_button.Enabled = false;
                dice_button.Visible = false;
            }

            index++;
        }
    }

    private List<PictureBox> getAllPictureBoxes(){
        // dice buttoneita on monta, joten niistä on hyvä tehdä lista
        // helpompaa käsittelyä varten
        List<PictureBox> pictureBoxes = new List<PictureBox>();

        foreach (PictureBox control in diceResultsWindow.Controls){
            pictureBoxes.Add(control);
        }
        return pictureBoxes;
    }

    // leveys ja pituus ovat luokan sisäisesti "globaaleja", 
    // jotta niitä voi käyttää kaikissa funktioissa
    private int img_width = 75;
    private int img_height = 75;

    private void diceWindow_Paint(object sender, PaintEventArgs e)
    {

        int pointX;
        int pointY;

        // luodaan lista, johon otetaan talteen suorakulmioiden mitat,
        // jotta voidaan verrata niiden päällekkäisyyttä
        // ja yrittää välttää sitä
        List<Rectangle> storedRectangles = new List<Rectangle>();

        Rectangle image_dimensions = new Rectangle(0, 0, img_width, img_height);

        Random rng = new Random(); // siajinnit on satunnaisia, jotta voidaan simuloida 2d noppien "autenttisuus"

        for(int index = 0; index < dices.Count(); index++){
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

        for(int index = 0; index < dices.Count(); index++){
            if(!dice_selected[index]){ // ainosataan valitsemattomat nopat piirretään, koska ei haluta piirtää jokaista noppa turhaan vaikka käyttäjä olisi jo valinnut vaikka yhden nopan
                e.Graphics.DrawImage(dices[index].DrawDice(), storedRectangles[index]); // kuvien sijoittaminen suorakulmioiden mukaan
            }
        }

        storedRectangles.Clear();

        // TODO kuvien tallessa pitäminen
        // on keksittävä jokin keino miten kuvat voi pitää tallessa käyttäjän valinnan mukaan

    }

    #region Dice Button Paint events
    private void diceButton1_Paint(object sender, PaintEventArgs e){
        if(dices_thrown[0] && !dice_selected[0]){
            e.Graphics.DrawImage(dices[0].DrawDice(), diceButtonImageBoundary());
            dices_thrown[0] = false;
        }
    }

    private void diceButton2_Paint(object sender, PaintEventArgs e){
        if(dices_thrown[1]  && !dice_selected[1]){
            e.Graphics.DrawImage(dices[1].DrawDice(), diceButtonImageBoundary());
            dices_thrown[1] = false;
        }
    }

    private void diceButton3_Paint(object sender, PaintEventArgs e){
        if(dices_thrown[2]  && !dice_selected[2]){
            e.Graphics.DrawImage(dices[2].DrawDice(), diceButtonImageBoundary());
            dices_thrown[2] = false;
        }
    }

    private void diceButton4_Paint(object sender, PaintEventArgs e){
        if(dices_thrown[3] && !dice_selected[3]){
            e.Graphics.DrawImage(dices[3].DrawDice(), diceButtonImageBoundary());
            dices_thrown[3] = false;
        }
    }

    private void diceButton5_Paint(object sender, PaintEventArgs e){
        if(dices_thrown[4]  && !dice_selected[4]){
            e.Graphics.DrawImage(dices[4].DrawDice(), diceButtonImageBoundary());
            dices_thrown[4] = false;
        }
    }
    #endregion

    // funktio joka luo ääriviivat noppa painikkeille
    private List<Rectangle> createDiceButtonBorders(){
        var diceButton_list = getAllPictureBoxes();
        Rectangle border = new Rectangle();
        List<Rectangle> border_list = new List<Rectangle>();

        foreach(PictureBox dice_button in diceButton_list){
            border.X = dice_button.Location.X - 5;
            border.Y = dice_button.Location.Y - 5;
            border.Width = dice_button.Width + 10;
            border.Height = dice_button.Height + 10;

            border_list.Add(border);
        }

        return border_list;
    }

    // apu funktio, joka luo noppa kuville rajat, jotta niitä ei tarvitse kaikkia käsin kirjoittaa
    private Rectangle diceButtonImageBoundary(){
        Rectangle boundary = new Rectangle(0, 0, img_width, img_height);
        return boundary;
    }

    // noppien valinnat/painikkeiden toiminnat
    #region Dice Button click functions
    private void diceButton1_Click(object sender, EventArgs e){
        if(!dice_selected[0]){
            dice_selected[0] = true; // kun nappia painetaan, annetaan merkki että noppa on valittu
            results[0] = dices[0].value; // ja tallennetaan nopan arvo tuloksiin

            // rajaa painikkeen vaikutusalueen, jotta koko diceResultsWindowta ei uudelleen piirrettä
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[0]);
        }

        else{ // mikäli käyttäjä painaa sitä toisen kerran, pyyhitään merkintä ja nollataan results indeksi
            dice_selected[0] = false;
            results[0] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[0]);
        }
    }

    private void diceButton2_Click(object sender, EventArgs e){
        if(!dice_selected[1]){
            dice_selected[1] = true;
            results[1] = dices[1].value;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[1]);
        }

        else{
            dice_selected[1] = false;
            results[1] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[1]);
        }
    }

    private void diceButton3_Click(object sender, EventArgs e){
        if(!dice_selected[2]){
            dice_selected[2] = true;
            results[2] = dices[2].value;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[2]);
        }

        else{
            dice_selected[2] = false;
            results[2] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[2]);
        }
    }

    private void diceButton4_Click(object sender, EventArgs e){
        if(!dice_selected[3]){
            dice_selected[3] = true;
            results[3] = dices[3].value;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[3]);
        }

        else{
            dice_selected[3] = false;
            results[3] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[3]);
        }
    }

    private void diceButton5_Click(object sender, EventArgs e){
        if(!dice_selected[4]){
            dice_selected[4] = true;
            results[4] = dices[4].value;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[4]);
        }

        else{
            dice_selected[4] = false;
            results[4] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[4]);
        }
    }
    #endregion

    private void highlightSelected_Paint(object sender, PaintEventArgs e)
    {

        var diceButton_list = getAllPictureBoxes();
        Rectangle border = new Rectangle();
        List<Rectangle> border_list = new List<Rectangle>();

        foreach(PictureBox dice_button in diceButton_list){
            border.X = dice_button.Location.X;
            border.Y = dice_button.Location.Y;
            border.Width = dice_button.Width;
            border.Height = dice_button.Height;

            border_list.Add(border);
        }

        Pen pen = new Pen(Color.Blue, 5);

        for(int index = 0; index < dice_selected.Count(); index++){
            if (dice_selected[index]){
                e.Graphics.DrawRectangle(pen, createDiceButtonBorders()[index]);
                e.Graphics.DrawImage(new Bitmap(filename: $"img\\Dice{results[index]}.png"), border_list[index]);
            }
        }
        
    }

}