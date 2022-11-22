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

}