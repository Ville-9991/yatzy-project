namespace yatzy_project;

public partial class YatzyForm{

    private static int[] resultsToBeComparedWith(bool[] selected_dices, int[] initial_results, int[] user_results){
        // luo listan sen mukaan mitä nopan tuloksia verrataan kategorioittan
        // jos käyttäjä on valinnut nopan käytetään valittujen noppien arvoja, muuten käytetään alku arvoja

        // TODO luo lopullinen vertailu käyttäjän hyväksytyille nopille

        List<int> results_for_comparison = new List<int>();

        for(int index = 0; index < selected_dices.Count(); index++){
            if(selected_dices[index]){
                results_for_comparison.Add(user_results[index]);
            }
            else{
                results_for_comparison.Add(initial_results[index]);
            }
        }
        return results_for_comparison.ToArray();
    }

    private void checkPossibleCategoryCombinations(int[] current_results){ // current_results pituus on aina 5

        // asetetaan kaikki kategoriat aluksi false, jotta joka tarkastus kerralla käyttäjä saa oikeaa tietoa, 
        // ettei vahingossa näytetä true, joka olisi ollut vaan edelliseltä kierrokselta
        for(int index = 0; index < possible_combination.Count(); index++){
            possible_combination[index] = false;
        }

        if(current_results[0] == 0){
            // koska results alustetaan aina viitenä 0:na, joka on 5 samaa eli "yatzy"
            // estetään käyttäjältä mahdollisuus hyväksikäyttää tätä puutetta...
            return;
        }

        // pöytäkirjan yläosa
        foreach(int num in current_results){
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
        
        var occurance_times_ordered = countOccurances(current_results);
        HashSet<int> dublicates = new HashSet<int>(current_results);

        int[] small_straight = {1, 2, 3, 4, 5};
        int[] big_straight = {2, 3, 4, 5, 6};

        if(occurance_times_ordered[1].Item2 == 2 && dublicates.Count() == 4){ // pari
            possible_combination[6] = true;
        }
        if((occurance_times_ordered[1].Item2 == 2 && occurance_times_ordered[2].Item2 == 2) && dublicates.Count() == 3){ // kaksi paria
            possible_combination[7] = true;
        }
        if(occurance_times_ordered[1].Item2 == 3 && dublicates.Count() != 2){ // kolme samaa
            possible_combination[8] = true;
        }
        if(occurance_times_ordered[1].Item2 == 4){ // neljä samaa
            possible_combination[9] = true;
        }
        if(current_results.SequenceEqual(small_straight)){ // pieni suora
            possible_combination[10] = true;
        }
        if(current_results.SequenceEqual(big_straight)){ // iso suora
            possible_combination[11] = true;
        }
        if((occurance_times_ordered[1].Item2 == 3 && occurance_times_ordered[2].Item2 == 2) && dublicates.Count() == 2){ // täyskäsi
                possible_combination[12] = true;
        }
        if(dublicates.Count() == 1){ // yatzy
            possible_combination[14] = true;
        }

        // mennään vasta viimeisenä tänne
        if(current_results.Any()){ // sattuma
            possible_combination[13] = true;
        }

    }

    private void applyScore(){

        var labels = getAllResultsLabels();

        for(int index = 0; index < category_locked.Count(); index++){
            if(category_locked[index] && category_score[index] == 0){
                category_score[index] = checkScoring(index);
                labels[index].Text = Convert.ToString(category_score[index]);
            }
        }

        int checkScoring(int categoryID){
            int score = 0;

            var accepted_results = resultsForScoring(dice_selected, results, results_to_be_accepted);
            checkIfPossibleForScoring(accepted_results);
            var occurance_times_ordered = countOccurances(accepted_results.ToArray());

            // pöytäkirjan yläosa

            if(categoryID == 0 && possible_combination[0]){
                score = accepted_results.Where((a, b) => a == 1).Sum();
            }
            else if(categoryID == 1 && possible_combination[1]){
                score = accepted_results.Where((a, b) => a == 2).Sum();
            }
            else if(categoryID == 2 && possible_combination[2]){
                score = accepted_results.Where((a, b) => a == 3).Sum();
            }
            else if(categoryID == 3 && possible_combination[3]){
                score = accepted_results.Where((a, b) => a == 4).Sum();
            }
            else if(categoryID == 4 && possible_combination[4]){
                score = accepted_results.Where((a, b) => a == 5).Sum();
            }
            else if(categoryID == 5 && possible_combination[5]){
                score = accepted_results.Where((a, b) => a == 6).Sum();
            }

            // pöytäkirjan alaosa

            else if(categoryID == 6 && possible_combination[6] && occurance_times_ordered[0].Item2 == 2){ // pari
                score = occurance_times_ordered[1].Item1 *2;
            }
            else if(categoryID == 7 && possible_combination[7] && (occurance_times_ordered[0].Item2 == 2 && occurance_times_ordered[1].Item2 == 2)){ // kaksi paria
                score = (occurance_times_ordered[1].Item1 *2) + (occurance_times_ordered[2].Item1 *2);
            }
            else if(categoryID == 8 && possible_combination[8] && occurance_times_ordered[0].Item2 == 3){ // kolme samaa
                score = occurance_times_ordered[1].Item1 *3;
            }
            else if(categoryID == 9 && possible_combination[9] && occurance_times_ordered[0].Item2 == 4){ // neljä samaa
                score = occurance_times_ordered[1].Item1 *4;
            }
            else if(categoryID == 10 && possible_combination[10]){ // pieni suora
                score = 15;
            }
            else if(categoryID == 11 && possible_combination[11]){ // iso suora
                score = 20;
            }
            else if(categoryID == 12 && possible_combination[12] && (occurance_times_ordered[0].Item2 == 3 && occurance_times_ordered[1].Item2 == 2)){ // täyskäsi
                score = (occurance_times_ordered[1].Item1 *3) + (occurance_times_ordered[2].Item1 *2);
            }
            else if(categoryID == 13 && possible_combination[13]){ // sattuma
                score = accepted_results.Sum();
            }
            else if(categoryID == 14 && possible_combination[14]){ // yazty
                score = 50;
            }

            return score;
        }

    }

    private static List<(int, int)> countOccurances(int[] numbers){
        /// <summary>
        /// input -> int[]
        /// Example input:
        /// {9, 5, 5, 9, 5, 5}
        ///
        /// output -> List<(int, int)>
        /// Example output:
        /// (5, 4), (9, 2), (0, 1)
        ///
        /// Metodi laskee numeroiden esiintymis määrän jokossa (int[] array_of_numbers).
        ///
        /// Palauttaa Listan, jossa Item1 = kokonaisluku : Item2 = kokonaisluvun esiitymis määrä
        /// Lista on järjestetty suurimmasta pienimäpään Item2:n mukaan (Esiintymis määrän mukaan)
        /// </summary>

        int highest_value = numbers.Max();
        int[] int_array = numbers.Append(0).ToArray();

        int[] occurrence_count = new int[int_array.Count()];

        for (int count = 0; count < int_array.Length; count++){
            for (int index = 0; index < int_array.Length; index++){
                if (int_array[index] == count){
                    occurrence_count[count]++;
                }
            }
        }

        List<(int, int)> occurance_times = new List<(int, int)>();

        for (int x = 0; x < int_array.Length; x++){
        occurance_times.Add((x, occurrence_count[x]));
        }

        var occurance_times_ordered = occurance_times.OrderByDescending(a => a.Item2).ToList();

        return occurance_times_ordered;
    }

    private int[] resultsForScoring(bool[] selected_dices, int[] initial_results, int[] user_results){
        List<int> values = new List<int>();

        for(int index = 0; index < 5; index++){
            if(selected_dices[index]){
                values.Add(user_results[index]);
            }
            else{
                values.Add(initial_results[index]);
            }
        }

        int[] results_for_scoring = values.ToArray();
        var occurances_counted = countOccurances(results_for_scoring);

        if(category_selected[6]){ // jos pari

            for(int index = 0; index < results_for_scoring.Count(); index++){
                results_for_scoring[index] = 0;
            }

            results_for_scoring[0] = occurances_counted[1].Item1;
            results_for_scoring[1] = occurances_counted[1].Item1;

            return results_for_scoring;
        }

        if(category_selected[7]){ // jos kaksi paria

            for(int index = 0; index < results_for_scoring.Count(); index++){
                results_for_scoring[index] = 0;
            }

            results_for_scoring[0] = occurances_counted[1].Item1;
            results_for_scoring[1] = occurances_counted[1].Item1;

            results_for_scoring[3] = occurances_counted[2].Item1;
            results_for_scoring[4] = occurances_counted[2].Item1;

            return results_for_scoring;
        }

        if(category_selected[8]){ // jos kolme samaa

            for(int index = 0; index < results_for_scoring.Count(); index++){
                results_for_scoring[index] = 0;
            }

            for(int index = 0; index < 3; index++){
                results_for_scoring[index] = occurances_counted[1].Item1;
            }

            return results_for_scoring;
        }

        if(category_selected[9]){ // jos neljä samaa

            results_for_scoring[5] = 0;

            for(int index = 0; index < 4; index++){
                results_for_scoring[index] = occurances_counted[1].Item1;
            }

            return results_for_scoring;
        }

        if(category_selected[12]){ // jos täyskäsi

            results_for_scoring[5] = 0;

            for(int index = 0; index < 3; index++){
                results_for_scoring[index] = occurances_counted[1].Item1;
            }

            results_for_scoring[3] = occurances_counted[2].Item1;
            results_for_scoring[4] = occurances_counted[2].Item1;


            return results_for_scoring;
        }

        return results_for_scoring;

    }

    private void checkIfPossibleForScoring(int[] current_results){ // current_results pituus on aina 5

        // asetetaan kaikki kategoriat aluksi false, jotta joka tarkastus kerralla käyttäjä saa oikeaa tietoa, 
        // ettei vahingossa näytetä true, joka olisi ollut vaan edelliseltä kierrokselta
        for(int index = 0; index < possible_combination.Count(); index++){
            possible_combination[index] = false;
        }

        // pöytäkirjan yläosa
        foreach(int num in current_results){
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
        
        var occurance_times_ordered = countOccurances(current_results);
        HashSet<int> dublicates = new HashSet<int>(current_results);

        int[] small_straight = {1, 2, 3, 4, 5};
        int[] big_straight = {2, 3, 4, 5, 6};

        if(occurance_times_ordered[0].Item2 == 2){ // pari
            possible_combination[6] = true;
        }
        if((occurance_times_ordered[0].Item2 == 2 && occurance_times_ordered[1].Item2 == 2)){ // kaksi paria
            possible_combination[7] = true;
        }
        if(occurance_times_ordered[0].Item2 == 3){ // kolme samaa
            possible_combination[8] = true;
        }
        if(occurance_times_ordered[0].Item2 == 4){ // neljä samaa
            possible_combination[9] = true;
        }
        if(current_results.SequenceEqual(small_straight)){ // pieni suora
            possible_combination[10] = true;
        }
        if(current_results.SequenceEqual(big_straight)){ // iso suora
            possible_combination[11] = true;
        }
        if((occurance_times_ordered[0].Item2 == 3 && occurance_times_ordered[1].Item2 == 2) && dublicates.Count() == 2){ // täyskäsi
                possible_combination[12] = true;
        }
        if(dublicates.Count() == 1){ // yatzy
            possible_combination[14] = true;
        }

        // mennään vasta viimeisenä tänne
        if(current_results.Any()){ // sattuma
            possible_combination[13] = true;
        }

    }
    
}