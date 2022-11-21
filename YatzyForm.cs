namespace yatzy_project;

public partial class YatzyForm : Form
{
    public YatzyForm()
    {
        InitializeComponent();

        Init_DiceButtonEvents();
        Init_CategoryEvents();
    }

    // alustetaan (listaksi) viisi noppaa, joilla on kuusi sivua, 
    // jotta niiden metodeja/arvoja voidaan käyttää myöhemmin
    Dice[] dices = {new Dice(), new Dice(), new Dice(), new Dice(), new Dice()};
    // diceButton (paint ja click) eventeille merkki siitä
    // että nopan voi piirtää
    private bool[] dices_thrown = new bool[5];
    private bool[] dice_selected = new bool[5];
    private int[] results = new int[5]; // yksittäisten noppien tulokset
    private int[] results_to_be_accepted = new int[5]; // käyttäjän valitsemat nopat/tulokset
    private int[] category_score = new int[15]; // pöytäkirjan piseteet kategorioittain

    // mahdolliset kategoriat, joita tavoitella
    // (aluksi kaikki false, mutta mikäli ohjelma löytää noppien tuloksista mahdollisen, kategoria on true)
    private bool[] possible_combination = new bool[15];
    private bool[] category_selected = new bool[15];

    // kategoria lukitaan sen myötä kun käyttäjä valitsee tavoittelemansa kategorian
    private bool[] category_locked = new bool[15];
    // "category_completed", joka osoittaa onko kategoria käyty läpi ja määrittää sen lukituksen.
    // Lukitus pysyy niin kauna kunnes koko peli on pelattu loppuun
    private bool[] category_completed = new bool[15];
    // tarvitaan sen varalta mikäli käyttäjä valitsee
    // tavoittelemattoman kategorian heitettyään nopat,
    // jotta voidaan näyttää käyttäjälle ikkunna, jossa kerrotaan
    // kategorian olevan tavoittelematon
    private bool round_started = false;
    // leveys ja pituus ovat luokan sisäisesti "globaaleja", 
    // jotta niitä voi käyttää kaikissa funktioissa
    private int img_width = 75;
    private int img_height = 75;

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

        round_started = true;

        enableDiceButtons();
        lockAllCategories();

        // Dice luokan value on aluksi 1, ja sen drawDice metodi,
        // piirtää nopan value arvolla (tässä tapauksessa viisi 1-arvoista noppaa)
        // heti kun diceWindow_Paint eventti latautuu, joten diceWindow on aluksi false
        diceWindow.Visible = true;
        diceWindow.Invalidate();

        combinationsPanel.Invalidate();

        displayDiceValues();
        
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

        // kategorioita ei lukita ennen kun käyttäjä on valinnut
        // kategorian ja heittänyt noppaa
        for(int index = 0; index < category_selected.Count(); index++){
            if(category_selected[index]){
                any_selected = true;
            }
        }

        // kun noppaa on heitetty ja käyttäjä on valinnut
        // kategorian ennen heittoa, kategoriat lukitaan kierroksen ajaksi
        if(any_selected){
            for(int index = 0; index < category_locked.Count(); index++){
                category_locked[index] = true;
            }
        }

    }

    private void displayDiceValues(){
        // Näyttää noppien arvot käyttäjän mieleksi,
        // ilman että hänen tarvitsee laskea noppien silmiä

        // noppien arvon "Text" on alustettu 0:ksi, joten "Visble" on aluksi false
        diceValues_Panel.Visible = true;

        int index = 0;
        // Sama perjaate kuten diceButtonien ja kategorien kanssa;
        // niitä monta, joten on parempi käsitellä niitä indexittäin
        foreach (Label diceValue_label in diceValues_Panel.Controls){

            if(dice_selected[index]){ // käyttäjän valinnan mukaan näytetään käyttäjän valitsemat nopan arvot
                diceValue_label.Text = Convert.ToString(results_to_be_accepted[index]);
            }
            else{
                diceValue_label.Text = Convert.ToString(results[index]);
            }

            index++;
        }
    }

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

                    if(storedRectangles[index].X < rect.X & storedRectangles[index].Y > rect.Y){
                        storedRectangles[index] = new Rectangle(storedRectangles[index].X + 50, storedRectangles[index].Y, img_width, img_height);
                    }

                    else if(storedRectangles[index].X > rect.X & storedRectangles[index].Y < rect.Y){
                        storedRectangles[index] = new Rectangle(storedRectangles[index].X, storedRectangles[index].Y + 50, img_width, img_height);
                    }

                    else if(storedRectangles[index].X == rect.X & storedRectangles[index].Y == rect.Y){
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

    }

    // diceResultsWindow_Paint -> highlightSelected_Paint
    private void highlightSelected_Paint(object sender, PaintEventArgs e)
    {

        var diceButton_list = getAllDiceButtons();
        Rectangle border = new Rectangle();
        List<Rectangle> border_list = new List<Rectangle>();

        // luo maalattavalle käyttäjän valitsemat nopalle rajat
        // joita viitataan indexittäin
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
                    Console.WriteLine("Kuva tiedostoa viittaava indeksi ei latautunut...");
                }
            }
        }
        
    }

    // tässä kontekstissa sanat kategoria (category) ja yhdistelämä (combination)
    // merkitsee samaa asiaa
    private void combinationsPanel_Paint(object sender, PaintEventArgs e)
    {
        // ensiksi noudetaan käyttäjän pisteet, jonka jälkeen tarkastetaan onko yhdistelmä mahdollinen
        checkIfPossibleForScoring(resultsForScoring(dice_selected, results, results_to_be_accepted));

        var categoires = getAllCategoryLabels();

        bool any_selected = false;
        for(int index = 0; index < category_selected.Count(); index++){
            if(category_selected[index]){
                any_selected = true;
            }
        }

        for(int index = 0; index < categoires.Count(); index++){
            // monta ehtoa, mutta ne ovat tärkeitä, jotta voidaan näyttää oikeita värejä
            // yhdistemien valinnan ja lukituksen mukaan

            // kategoria pitää olla mahdollinen
            // ainoastaan ei valitut kategoriat
            // eikä kategoria voi myöskään olla lukittuna
            // varmuuden vuoksi tehdään neljäs tarkastus että mikään ei ole valittuna
            if(possible_combination[index] & !category_selected[index] & !category_locked[index] & !any_selected){
                // vain tuolloin korostetaan vihreällä värillä
                categoires[index].ForeColor = Color.Green;
            }
            else if(!possible_combination[index] & !category_locked[index]){
                categoires[index].ForeColor = Color.Black;
            }
        }

        for(int index = 0; index < category_selected.Count(); index++){
            // ainoastaa valitut kategoriat korostetaan sinisellä
            if (category_selected[index] & !category_locked[index]){
                categoires[index].ForeColor = Color.Blue;
            }
            else if(!category_selected[index] & !possible_combination[index] & !category_completed[index] & !any_selected){
                categoires[index].ForeColor = Color.Black;
            }
        }

        for(int index = 0; index < category_locked.Count(); index++){
            // kun kategoria on valittuna ja noppaa on heitetty
            // kategoriat lukitaan, joten on hyvä korostaa tämä käyttäjälle
            // omalla värillään
            if(category_locked[index] & !category_selected[index] & !category_completed[index]){
                categoires[index].ForeColor = Color.SlateGray;
            }
        }

        enableAcceptBtn();
    }

    private void enableAcceptBtn(){

        // käyttäjän on valittava kategoria
        // ennen kuin annetaan hänen painaa acceptResults_buttonia
        if(category_selected.Contains(true))
            acceptResults_btn.Enabled = true;
        else
            acceptResults_btn.Enabled = false;
    }

    private void acceptResults_btn_Click(object sender, EventArgs e)
    {
        round_started = false;

        var categoires = getAllCategoryLabels();

        for(int index = 0; index < category_locked.Count(); index++){
            // ainoastaan ei suoritetuista kategorioista poistetaan
            // lukitus
            if(!category_completed[index]){
                category_locked[index] = false;
            }
        }

        for(int index = 0; index < category_selected.Count(); index++){
            if(category_selected[index]){
                // ainoastaan edellisellä kierroksella valittu kategoria lukitaan
                category_locked[index] = true;
                category_completed[index] = true;
            }
            
            if(category_completed[index]){
                // suoritetuille kategoriolle on hyvä laitaa
                // selkeä väri
                categoires[index].ForeColor = Color.LightGray;
            }
        }

        applyScore();
        softReset();

        if(category_completed.All(x => x == true)){
            finishTheSession();
        }

    }

    private void softReset(){

        // kuten nimi kertoo
        // palauttaa kaikki muuttujat takaisin
        // alustettuun muotoon
        // uuden kierroksen aloittamamiseksi

        deselectAllCategories();

        allowedNumberOfThrows.Text = Convert.ToString(3);

        for(int index = 0; index < dice_selected.Count(); index++){ // count = 5
            dice_selected[index] = false;
            dices_thrown[index] = false;
            dices[index].value = 0;
            results[index] = 0;
            results_to_be_accepted[index] = 0;
        }

        var dice_button_list = getAllDiceButtons();

        for(int index = 0; index < dice_button_list.Count(); index++){ // count = 5
            dice_button_list[index].Enabled = false;
            dice_button_list[index].Invalidate();
        }

        for(int index = 0; index < possible_combination.Count(); index++){ // count = 15
            possible_combination[index] = false;
        }

        diceValues_Panel.Visible = false;

        diceWindow.Visible = false;
        diceResultsWindow.Invalidate();
        throwDice_btn.Enabled = true;
        acceptResults_btn.Enabled = false;

        combinationsPanel.Invalidate();
    }

    private void finishTheSession(){

        // ikkuna joka näyttää käyttäjälle pisteitensä tuloksen
        // ja kysyy haluaako hän pelata uudelleen
        string message = $"Pisteitesi tulos: {summa_resultsLabel.Text} \n\nHaluatko pelata uudelleen?";
        const string title = "Game Over";

        const MessageBoxButtons buttons = MessageBoxButtons.YesNo;

        DialogResult result = MessageBox.Show(message, title, buttons);
        if (result == DialogResult.Yes) {

        var labels = getAllResultsLabels();
        var categoires = getAllCategoryLabels();

        // poistaa lukitusen kaikista kategorioista ja nollaa pisteytyksen
        // uutta peliä varten
        for(int index = 0; index < category_completed.Count(); index++){
            category_locked[index] = false;
            category_completed[index] = false;
            category_score[index] = 0;

            labels[index].Text = Convert.ToString(0);
        }

        valisumma_resultsLabel.Text = Convert.ToString(0);
        bonus_resultsLabel.Text = Convert.ToString(0);
        summa_resultsLabel.Text = Convert.ToString(0);

        combinationsPanel.Invalidate();

        }

        else{
            Application.Exit();
        }
    }
}