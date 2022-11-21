namespace yatzy_project;

public partial class YatzyForm{
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