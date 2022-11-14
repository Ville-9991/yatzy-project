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
    private int[] results = {0, 0, 0, 0, 0}; // yksittäisten noppien tulokset
    private int[] results_to_be_accepted = {0, 0, 0, 0, 0}; // käyttäjän valitsemat nopat/tulokset
    // private int[] category_score = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}; // pöytäkirjan piseteet kategorioittain (15 eri kategoriaa)
    // private int subtotal = 0;
    // private int grand_total = 0;
    // private int bonus = 0;

    // mahdolliset kategoriat, joita tavoitella (aluksi kaikki false, mutta mikäli ohjelma löytää noppien tuloksista mahdollisen, kategoria on true)
    private bool[] possible_combination = {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
    private bool[] category_selected = {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};

    // kategoria lukitaan sen myötä kun käyttäjä valitsee tavoittelemansa kategorian, kunnes koko peli on pelattu loppuun
    private bool[] category_locked = {false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};

    private void throwDice_btn_Click(object sender, EventArgs e)
    {
        int throws_left = Int32.Parse(allowedNumberOfThrows.Text); // heittoja on aluksi kolme
        
        if (throws_left  == 1){
            throwDice_btn.Enabled = false;
        }

        for(int index = 0; index < dices.Count(); index++){
            dices[index].rollDice();
            results[index] = dices[index].value;
        }

        allowedNumberOfThrows.Text = Convert.ToString(throws_left -1);

        enableDiceButtons();

        diceWindow.Visible = true;
        diceWindow.Invalidate();

        combinationsPanel.Invalidate();
        
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
            results_to_be_accepted[0] = results[0]; // ja tallennetaan nopan arvo tuloksiin

            // rajaa painikkeen vaikutusalueen, jotta koko diceResultsWindowta ei uudelleen piirrettä
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[0]);
        }

        else{ // mikäli käyttäjä painaa sitä toisen kerran, pyyhitään merkintä ja nollataan results indeksi
            dice_selected[0] = false;
            results_to_be_accepted[0] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[0]);
        }
    }

    private void diceButton2_Click(object sender, EventArgs e){
        if(!dice_selected[1]){
            dice_selected[1] = true;
            results_to_be_accepted[1] = results[1];
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[1]);
        }

        else{
            dice_selected[1] = false;
            results_to_be_accepted[1] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[1]);
        }
    }

    private void diceButton3_Click(object sender, EventArgs e){
        if(!dice_selected[2]){
            dice_selected[2] = true;
            results_to_be_accepted[2] = results[2];
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[2]);
        }

        else{
            dice_selected[2] = false;
            results_to_be_accepted[2] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[2]);
        }
    }

    private void diceButton4_Click(object sender, EventArgs e){
        if(!dice_selected[3]){
            dice_selected[3] = true;
            results_to_be_accepted[3] = results[3];
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[3]);
        }

        else{
            dice_selected[3] = false;
            results_to_be_accepted[3] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[3]);
        }
    }

    private void diceButton5_Click(object sender, EventArgs e){
        if(!dice_selected[4]){
            dice_selected[4] = true;
            results_to_be_accepted[4] = results[4];
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[4]);
        }

        else{
            dice_selected[4] = false;
            results_to_be_accepted[4] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[4]);
        }
    }
    #endregion

    // diceResultsWindow_Paint => highlightSelected_Paint
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
                e.Graphics.DrawImage(new Bitmap(filename: $"img\\Dice{results_to_be_accepted[index]}.png"), border_list[index]);
            }
        }
        
    }

    private void checkPossibleCategoryCombinations(){

        // asetetaan kaikki kategoriat aluksi false, jotta joka tarkastus kerralla käyttäjä saa oikeaa tietoa, 
        // ettei vahingossa näytetä true, joka olisi ollut vaan edelliseltä kierrokselta
        for(int index = 0; index < possible_combination.Count(); index++){
            possible_combination[index] = false;
        }

        Array.Sort(results);

        // pöytäkirjan yläosa
        foreach(int num in results){
            if(num == 1){ // ykköset
                possible_combination[0] = true;
            }
            else if(num == 2){ // kakkoset
                possible_combination[1] = true;
            }
            else if(num == 3){ // kolmoset
                possible_combination[2] = true;
            }
            else if(num == 4){ // neloset
                possible_combination[3] = true;
            }
            else if(num == 5){ // viitoset
                possible_combination[4] = true;
            }
            else if(num == 6){ // kuutoset
                possible_combination[5] = true;
            }
        }

        // pöytäkirjan alaosa

        HashSet<int> dublicates = new HashSet<int>(results);

        int[] small_straight = {1, 2, 3, 4, 5};
        int[] big_straight = {2, 3, 4, 5, 6};

        if(dublicates.Count() == 4){ // pari
            possible_combination[6] = true;
        }
        // else if(dublicates.Count() == 3){ // kaksi paria
        //     possible_combination[7] = true;
        // }
        // else if(dublicates.Count() == 3){ // kolme samaa
        //     possible_combination[8] = true;
        // }
        else if(dublicates.Count() == 2){ // neljä samaa
            possible_combination[9] = true;
        }
        else if(results == small_straight){ // pieni suora
            possible_combination[10] = true;
        }
        else if(results == big_straight){ // iso suora
            possible_combination[11] = true;
        }
        // else if(){ // täyskäsi
        //     possible_combination[12] = true;
        // }
        else if(results.Any()){ // sattuma
            possible_combination[13] = true;
        }
        else if(dublicates.Count() == 1){ // yatzy
            possible_combination[14] = true;
        }

    }

    private void combinationsPanel_Paint(object sender, PaintEventArgs e)
    {
        checkPossibleCategoryCombinations();

        var categoires = getAllCategoryLabels();

        for(int index = 0; index < categoires.Count(); index++){
            if(possible_combination[index]){
                categoires[index].ForeColor = Color.Green;
            }
            else{
                categoires[index].ForeColor = Color.Black;
            }
        }
    }

    private List<Label> getAllCategoryLabels(){
        // sama homma kuten dice buttonien kanssa, mutta category/combination labeleita on paljon enemmän
        // joten on vain parempi tehdä yksi iso lista ja käsitellä niitä indeksittäin

        List<Label> CategoryLabels = new List<Label>();

        foreach (Label label in upperCategories_Panel.Controls){
            CategoryLabels.Add(label);
        }

        foreach (Label label in bottomCategories_Panel.Controls){
            CategoryLabels.Add(label);
        }
        return CategoryLabels; // pituus on 15 elementtiä (14 kun aloitetaan 0:sta...)
    }
}