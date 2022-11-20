namespace yatzy_project;

public partial class YatzyForm{

    private List<PictureBox> getAllDiceButtons(){
        // dice buttoneita on monta, joten niistä on hyvä tehdä lista
        // helpompaa käsittelyä varten
        List<PictureBox> pictureBoxes = new List<PictureBox>();

        foreach (PictureBox control in diceResultsWindow.Controls){
            pictureBoxes.Add(control);
        }
        return pictureBoxes;
    }

    private void Init_DiceButtonEvents(){
        List<PictureBox> diceButton_list = getAllDiceButtons();

        foreach(PictureBox button in diceButton_list){
            //
            // diceButton_Click event
            //
            button.Click += (sender, e) => {

                PictureBox? buttonEvent = sender as PictureBox;

                int index = checkWhichButtonEventWasTriggered(buttonEvent);

                if(!dice_selected[index]){
                    dice_selected[index] = true; // kun nappia painetaan, annetaan merkki että noppa on valittu
                    results_to_be_accepted[index] = results[index]; // ja tallennetaan nopan arvo tuloksiin

                    // rajaa painikkeen vaikutusalueen, jotta koko diceResultsWindowta ei uudelleen piirrettä
                    this.diceResultsWindow.Invalidate(createDiceButtonBorders()[index]);
                    combinationsPanel.Invalidate();
                }

                else{ // mikäli käyttäjä painaa sitä toisen kerran, pyyhitään merkintä ja nollataan results indeksi
                    dice_selected[index] = false;
                    results_to_be_accepted[index] = 0;
                    this.diceResultsWindow.Invalidate(createDiceButtonBorders()[index]);
                    combinationsPanel.Invalidate();
                }
            };

            //
            // diceButton_Paint event
            //
            button.Paint += (sender, e) => {

                PictureBox? buttonEvent = sender as PictureBox;

                int index = checkWhichButtonEventWasTriggered(buttonEvent);

                if(dices_thrown[index] & !dice_selected[index]){
                e.Graphics.DrawImage(dices[index].DrawDice(), diceButtonImageBoundary());
                dices_thrown[index] = false;
                }
            };
            
        }
    }

    // palauttaa indexin, jota käytetään muiden listojen käsittelyssä
    // noppa painikkeen eventin mukaan
    private int checkWhichButtonEventWasTriggered(PictureBox? buttonEvent){

        if(buttonEvent != null){
            var diceButton_list = getAllDiceButtons();

            for(int index = 0; index < diceButton_list.Count(); index++){
                if(diceButton_list[index] == buttonEvent){
                    return index;
                }
            }
        }

        return 0;
    }

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
}