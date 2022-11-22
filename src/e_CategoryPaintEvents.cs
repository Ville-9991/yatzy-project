namespace yatzy_project;

public partial class YatzyForm{
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
            if(possible_combination[index] && !category_selected[index] && !category_locked[index] && !any_selected){
                // vain tuolloin korostetaan vihreällä värillä
                categoires[index].ForeColor = Color.Green;
            }
            else if(!possible_combination[index] && !category_locked[index]){
                categoires[index].ForeColor = Color.Black;
            }
        }

        for(int index = 0; index < category_selected.Count(); index++){
            // ainoastaa valitut kategoriat korostetaan sinisellä
            if (category_selected[index] && !category_locked[index]){
                categoires[index].ForeColor = Color.Blue;
            }
            else if(!category_selected[index] && !possible_combination[index] && !category_completed[index] && !any_selected){
                categoires[index].ForeColor = Color.Black;
            }
        }

        for(int index = 0; index < category_locked.Count(); index++){
            // kun kategoria on valittuna ja noppaa on heitetty
            // kategoriat lukitaan, joten on hyvä korostaa tämä käyttäjälle
            // omalla värillään
            if(category_locked[index] && !category_selected[index] && !category_completed[index]){
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
}