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
    private bool[] dices_thrown = new bool[5];
    private bool[] dice_selected = new bool[5];
    private int[] results = new int[5]; // yksittäisten noppien tulokset
    private int[] results_to_be_accepted = new int[5]; // käyttäjän valitsemat nopat/tulokset
    private int[] category_score = new int[15]; // pöytäkirjan piseteet kategorioittain
    // private int subtotal = 0;
    // private int grand_total = 0;
    // private int bonus = 0;

    // mahdolliset kategoriat, joita tavoitella (aluksi kaikki false, mutta mikäli ohjelma löytää noppien tuloksista mahdollisen, kategoria on true)
    private bool[] possible_combination = new bool[15];
    private bool[] category_selected = new bool[15];

    // kategoria lukitaan sen myötä kun käyttäjä valitsee tavoittelemansa kategorian
    private bool[] category_locked = new bool[15];
    // TODO tee array "category_complete", joka osoittaa onko kategoria käyty läpi ja määrittää sen lukituksen.
    // Lukitus pysyy niin kauna kunnes koko peli on pelattu loppuun
    private bool[] category_completed = new bool[15];

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
        lockAllCategories();

        diceWindow.Visible = true;
        diceWindow.Invalidate();

        combinationsPanel.Invalidate();
        
    }

    private void enableDiceButtons(){

        for(int i = 0; i < dices_thrown.Count(); i++){
            dices_thrown[i] = true;
        }

        var dice_button_list = getAllDiceButtons();

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

    private void lockAllCategories(){
        bool any_selected = false;

        for(int index = 0; index < category_selected.Count(); index++){
            if(category_selected[index]){
                any_selected = true;
            }
        }

        if(any_selected){
            for(int index = 0; index < category_locked.Count(); index++){
                category_locked[index] = true;
            }
        }

    }

    private List<PictureBox> getAllDiceButtons(){
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
            // suorakulmioiden mittojen määrittäminen/sijainnin arvonta

            // TODO ikkunan pienennettyä, ohjelma lataa funktion uudellen, eli arpoo noppien sijainnit joka kerta eri paikkaan kun ikkuna suljetaan tai avataan
            // koita keksiä keino miten tältä voisi välttyä että kuvat pysyisivät "paikallaan"
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
        var diceButton_list = getAllDiceButtons();
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
            combinationsPanel.Invalidate();
        }

        else{ // mikäli käyttäjä painaa sitä toisen kerran, pyyhitään merkintä ja nollataan results indeksi
            dice_selected[0] = false;
            results_to_be_accepted[0] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[0]);
            combinationsPanel.Invalidate();
        }
    }

    private void diceButton2_Click(object sender, EventArgs e){
        if(!dice_selected[1]){
            dice_selected[1] = true;
            results_to_be_accepted[1] = results[1];
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[1]);
            combinationsPanel.Invalidate();
        }

        else{
            dice_selected[1] = false;
            results_to_be_accepted[1] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[1]);
            combinationsPanel.Invalidate();
        }
    }

    private void diceButton3_Click(object sender, EventArgs e){
        if(!dice_selected[2]){
            dice_selected[2] = true;
            results_to_be_accepted[2] = results[2];
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[2]);
            combinationsPanel.Invalidate();
        }

        else{
            dice_selected[2] = false;
            results_to_be_accepted[2] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[2]);
            combinationsPanel.Invalidate();
        }
    }

    private void diceButton4_Click(object sender, EventArgs e){
        if(!dice_selected[3]){
            dice_selected[3] = true;
            results_to_be_accepted[3] = results[3];
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[3]);
            combinationsPanel.Invalidate();
        }

        else{
            dice_selected[3] = false;
            results_to_be_accepted[3] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[3]);
            combinationsPanel.Invalidate();
        }
    }

    private void diceButton5_Click(object sender, EventArgs e){
        if(!dice_selected[4]){
            dice_selected[4] = true;
            results_to_be_accepted[4] = results[4];
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[4]);
            combinationsPanel.Invalidate();
        }

        else{
            dice_selected[4] = false;
            results_to_be_accepted[4] = 0;
            this.diceResultsWindow.Invalidate(createDiceButtonBorders()[4]);
            combinationsPanel.Invalidate();
        }
    }
    #endregion

    // diceResultsWindow_Paint -> highlightSelected_Paint
    private void highlightSelected_Paint(object sender, PaintEventArgs e)
    {

        var diceButton_list = getAllDiceButtons();
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
                try{
                    e.Graphics.DrawImage(new Bitmap(filename: $"img\\Dice{results_to_be_accepted[index]}.png"), border_list[index]);
                }
                catch{
                    System.Console.WriteLine("Kuva tiedostoa viittaava indeksi ei latautunut...");
                }
            }
        }
        
    }

    private void combinationsPanel_Paint(object sender, PaintEventArgs e)
    {

        checkIfPossibleForScoring(resultsForScoring(dice_selected, results, results_to_be_accepted));

        var categoires = getAllCategoryLabels();

        bool any_selected = false;
        for(int index = 0; index < category_selected.Count(); index++){
            if(category_selected[index]){
                any_selected = true;
            }
        }

        for(int index = 0; index < categoires.Count(); index++){
            if(possible_combination[index] && !category_selected[index] && !category_locked[index] && !any_selected){
                categoires[index].ForeColor = Color.Green;
            }
            else if(!possible_combination[index] && !category_locked[index]){
                categoires[index].ForeColor = Color.Black;
            }
        }

        for(int index = 0; index < category_selected.Count(); index++){
            if (category_selected[index] && !category_locked[index]){
                categoires[index].ForeColor = Color.Blue;
            }
            
        }

        enableAcceptBtn();
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

    private void enableAcceptBtn(){

        if(category_selected.Contains(true)){
            acceptResults_btn.Enabled = true;
        }
        else{
            acceptResults_btn.Enabled = false;
        }
    }

    private void acceptResults_btn_Click(object sender, EventArgs e)
    {

        var categoires = getAllCategoryLabels();

        for(int index = 0; index < category_locked.Count(); index++){
            if(!category_completed[index]){
                category_locked[index] = false;
            }
        }

        for(int index = 0; index < category_selected.Count(); index++){
            if(category_selected[index]){

                category_locked[index] = true; // ainoastaan edellisellä kierroksella valittu kategoria lukitaan
                category_completed[index] = true;
            }
            
            if(category_completed[index]){
                categoires[index].ForeColor = Color.LightGray;
            }
        }

        applyScore();
        softReset();

    }

    private List<Label> getAllResultsLabels(){
        List<Label> resultLabels = new List<Label>();

        foreach(Label label in upperResultsContainer.Controls){
            resultLabels.Add(label);
        }

        foreach(Label label in bottomResultsContainer.Controls){
            resultLabels.Add(label);
        }

        resultLabels.Remove(valisumma_resultsLabel);
        resultLabels.Remove(bonus_resultsLabel);
        resultLabels.Remove(summa_resultsLabel);

        return resultLabels;
    }

    private void softReset(){

        deselectAllCategories();

        allowedNumberOfThrows.Text = Convert.ToString(3);

        for(int index = 0; index < dice_selected.Count(); index++){
            dice_selected[index] = false;
            dices_thrown[index] = false;
            dices[index].value = 0;
            results[index] = 0;
            results_to_be_accepted[index] = 0;
        }

        var dice_button_list = getAllDiceButtons();

        for(int index = 0; index < dice_button_list.Count(); index++){
            dice_button_list[index].Enabled = false;
            dice_button_list[index].Invalidate();
        }

        for(int index = 0; index < possible_combination.Count(); index++){
            possible_combination[index] = false;
        }

        diceWindow.Visible = false;
        diceResultsWindow.Invalidate();
        throwDice_btn.Enabled = true;
        acceptResults_btn.Enabled = false;
    }
}