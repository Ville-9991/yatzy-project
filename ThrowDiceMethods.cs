namespace yatzy_project;

public partial class YatzyForm{
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
}