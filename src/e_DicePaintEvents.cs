namespace yatzy_project;

public partial class YatzyForm{

    private void generateRandomDiceLocations(){

        // kun throwDice_btn on painettu, kutsutaan funktiota, joka arpoo
        // sijainnit noppakuville
        //
        // näin tehdään, koska jos random kutsutaisiin paint eventissä,
        // random aiheuttaisi hankaluuksia kuvien "staattisuudessa"
        // koska paint event on ikään kuin "silmukka" joka odttaa ja aktivoituu
        // heti kun näytölle on piirrettävä

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

            pointX = rng.Next(0, diceWindow.Size.Width-(img_width*2));
            pointY = rng.Next(0, diceWindow.Size.Height-(img_height*2));

            image_dimensions.X = pointX;
            image_dimensions.Y = pointY;

            storedRectangles.Add(image_dimensions);

        }

        storedRectangles = fixOverlapping(storedRectangles, img_width, img_height);

        // annetaan storedRectangles eli noppakuvien ulottuvuudet diceWindow_Paint fuctiolle piirrettäväksi
        diceWindow.Paint += (sender, e) => diceWindow_Paint(sender, e, storedRectangles);
        
    }

    private static List<Rectangle> fixOverlapping(List<Rectangle> rectangles, int width, int height){

        for(int index = 0; index < rectangles.Count(); index++){

            // käydään jokainen suorakulmio läpi, jotta voidaan välttyä kuvien päällekkäisyydeltä
            foreach(Rectangle rect in rectangles.Where((a,b) => b != index).ToList()){ // lambda, joka ohittaa "tämän hetkisen" kierroksen suorakulmion (index), jotta vältytään "itseeän" vertaamasta "itseensä"

                if(rectangles[index].IntersectsWith(rect)){

                    // en ymmärrä tätä enkä ota credtittiä näistä
                    // https://math.stackexchange.com/questions/99565/simplest-way-to-calculate-the-intersect-area-of-two-rectangles
                    int x_overlap = Math.Max(0, Math.Min(rectangles[index].Right, rect.Right) - Math.Max(rectangles[index].Left, rect.Left));
                    int y_overlap = Math.Max(0, Math.Min(rectangles[index].Bottom, rect.Bottom) - Math.Max(rectangles[index].Top, rect.Top));

                    if(x_overlap > 5){
                        rectangles[index] = new Rectangle(rectangles[index].X + x_overlap, rectangles[index].Y, width, height);
                    }
                    else if(y_overlap > 5){
                        rectangles[index] = new Rectangle(rectangles[index].X, rectangles[index].Y + y_overlap / 2, width, height);
                    }
                    else if(x_overlap > 5 && y_overlap > 5){
                        rectangles[index] = new Rectangle(rectangles[index].X + x_overlap, rectangles[index].Y + y_overlap, width, height);
                    }

                }

            }

        }

        return rectangles;
    }


    // diceWindow ei tarkoita oikeaa ikkunaa, vaan paneelia, johon heitetyt nopat maalataan
    private void diceWindow_Paint(object? sender, PaintEventArgs e, List<Rectangle>dimensions)
    {
        for(int index = 0; index < dimensions.Count(); index++){
            // ainosataan valitsemattomat nopat piirretään, 
            // koska ei haluta piirtää jokaista noppa turhaan vaikka käyttäjä olisi jo valinnut vaikka yhden nopan
            if(!dice_selected[index]){
                e.Graphics.DrawImage(dices[index].DrawDice(), dimensions[index]); // kuvien sijoittaminen suorakulmioiden mukaan
            }
        }

        dimensions.Clear();

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
}