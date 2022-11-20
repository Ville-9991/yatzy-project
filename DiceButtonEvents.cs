namespace yatzy_project;

public partial class YatzyForm{

    // private void diceButtonClick(object sender, EventArgs e){

    // }

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
}