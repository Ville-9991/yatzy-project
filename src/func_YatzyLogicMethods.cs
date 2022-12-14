namespace yatzy_project;

public partial class YatzyForm{

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

            // tehdään ensiksi tarkastus, että mitä arvoja käytetään
            var accepted_results = resultsForScoring(dice_selected, results, results_to_be_accepted);
            // tarkastetaan toisen kerran, onko yhdistelmät mahdollisa
            checkIfPossibleForScoring(accepted_results);
            // laitetaan tuloksen järjestykseen
            // esiintymis kerran mukaan
            var occurance_times_ordered = countOccurances(accepted_results.ToArray());

            // pöytäkirjan yläosa

            // etsitään listan joukosta arvo, katsotaan onko kategoria mahdollinen
            // ja summataan arvo itsellään
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

            // alaosassa käytetään pisteytyksessä esiintymis määrä listan
            // ensimmäista (ja toista) arvoa (Item1)
            else if(categoryID == 6 && possible_combination[6]){ // pari

                // joskus voi käydä niin että käyttäjä saa useamman parin, joista toiset ovat arvokkaampia (ne ovat listassa jälkimmäisä)
                // joten annetaan pisteisiin ne arvokaammat nopat
                if(occurance_times_ordered[1].Item1 > occurance_times_ordered[0].Item1){
                    score = occurance_times_ordered[1].Item1 *2; // arvo kertaa 2
                }
                else{
                    score = occurance_times_ordered[0].Item1 *2;
                }
            }
            else if(categoryID == 7 && possible_combination[7]){ // kaksi paria
                // arvo1 kertaa 2 + arvo2 kertaa 2
                score = (occurance_times_ordered[0].Item1 *2) + (occurance_times_ordered[1].Item1 *2);
            }
            else if(categoryID == 8 && possible_combination[8]){ // kolme samaa
                score = occurance_times_ordered[0].Item1 *3; // arvo kertaa 3
            }
            else if(categoryID == 9 && possible_combination[9]){ // neljä samaa
                score = occurance_times_ordered[0].Item1 *4; // arvo kertaa 4
            }
            else if(categoryID == 10 && possible_combination[10]){ // pieni suora
                score = 15; // aina 15 pistettä
            }
            else if(categoryID == 11 && possible_combination[11]){ // iso suora
                score = 20; // aina 20 pistettä
            }
            else if(categoryID == 12 && possible_combination[12]){ // täyskäsi
                score = (occurance_times_ordered[0].Item1 *3) + (occurance_times_ordered[1].Item1 *2);
            }
            else if(categoryID == 13 && possible_combination[13]){ // sattuma
                score = accepted_results.Sum(); // pisteet = on arvojen summa
            }
            else if(categoryID == 14 && possible_combination[14]){ // yazty
                score = 50; // aina 50 pistettä
            }

            return score;
        } // scroring

        // yläkategorian summa
        // lasketaan category_score:n 0-5 ensimmäistä indexiä yhteen
        valisumma_resultsLabel.Text = Convert.ToString(category_score.Where((x, y) => y < 6).Sum());

        if(Int32.Parse(valisumma_resultsLabel.Text) >= 63){
            // jos yläosan summa on 63 pistettä tai enemmän
            // bonus pisteet on aina 50
            bonus_resultsLabel.Text = Convert.ToString(50);
        }

        // kaikkien kategorioiden yhteen laskettu summa
        summa_resultsLabel.Text = Convert.ToString(category_score.Sum() + Int32.Parse(bonus_resultsLabel.Text));

    }

    private List<Label> getAllResultsLabels(){
        // kuten diceButtonit ja category labelit
        // results labeleita on monta
        // joten niitä on parempi käsitellä
        // indexittäin
        List<Label> resultLabels = new List<Label>();

        foreach(Label label in upperResultsContainer.Controls){
            resultLabels.Add(label);
        }

        foreach(Label label in bottomResultsContainer.Controls){
            resultLabels.Add(label);
        }

        // näitä kolmea kuitenkin on käsiteltävä yksitellen
        // koska ne ovat controls-collectionin "keskellä"
        // ja kaikki muut category labelit/scoret on jo alustettu 15:sta joten
        // johdon mukaisuuden voksi resultsLabels.Count() on myös 15
        resultLabels.Remove(valisumma_resultsLabel);
        resultLabels.Remove(bonus_resultsLabel);
        resultLabels.Remove(summa_resultsLabel);

        return resultLabels;
    }

    private static List<(int, int)> countOccurances(int[] numbers){
        /// <summary>
        /// input -> int[]
        /// Example input:
        /// {5, 4, 4, 3, 1}
        ///
        /// output -> List<(int, int)>
        /// Example output:
        /// (4, 2), (1, 1), (3, 1), (5, 1), (2, 0)
        ///
        /// Metodi laskee numeroiden esiintymis määrän jokossa (int[] array_of_numbers).
        ///
        /// Palauttaa Listan, jossa Item1 = kokonaisluku : Item2 = kokonaisluvun esiitymis määrä
        /// Lista on järjestetty suurimmasta pienimäpään Item2:n mukaan (Esiintymis määrän mukaan)
        /// 
        /// Aloittaa laskennan nollasta, eli myös lisää 0:n esiintymis kerran
        /// Mutta yatzy pelissä ei hauluta nollaa mukaan, joten se poistetaan
        /// aina ulostulosta
        /// </summary>

        int highest_value = numbers.Max();
        int[] int_array;

        if (highest_value != 6){
            // koska laskenta alkaa
            // nollasta, tarvitaan ylimääräinen
            // luku listan loppuun
            // mieluiten 0, koska se poistetaan myöhemmin
            // listasta
            int_array = numbers.Append(0).ToArray();
        }

        else{
            // perjaatteessa, mitä suurempia numeroita
            // listassa, sitä enemmän nollia pitäisi lisätä perään
            // tässä kuitenkin rittää 6:n kohdalla yksi ylimääräinen
            // 0 lisää
            int_array = numbers.Append(0).Append(0).ToArray();
        }


        int[] occurrence_count = new int[int_array.Count()];

        // käy 0-4 kertaa (0-5, jos listassa esiintyy 6)
        // ja laskee numeroiden esiintymis määrän
        for (int count = 0; count < int_array.Length; count++){
            for (int index = 0; index < int_array.Length; index++){
                if (int_array[index] == count){
                    occurrence_count[count]++;
                }
            }
        }

        List<(int, int)> occurance_times = new List<(int, int)>();

        for (int x = 0; x < int_array.Length; x++){
            // laskenta alkaa nollasta
            // Item1 = x:n arvo
            // Item2 = kuinka monta kertaa x esiintyy listasa
            occurance_times.Add((x, occurrence_count[x]));
        }

        // laitetaan listan järjestys laskevaan järjestykseen
        // esiintymis määrän perusteella
        // eli ne numerot joita esiintyy eniten
        // ovat listan alussa
        var occurance_times_ordered = occurance_times.OrderByDescending(a => a.Item2).ToList();

        // poistetaan nollat, koska ne aiheittaa enemmän haitaa kuin hyötyä
        // ohjelman muissa toiminnoissa
        occurance_times_ordered.RemoveAll(x => x.Item1 == 0);

        return occurance_times_ordered;
    }

    private static int[] resultsForScoring(bool[] selected_dices, int[] initial_results, int[] user_results){
        List<int> values = new List<int>();

        for(int index = 0; index < 5; index++){
            // lajitellaan tulokset käyttäjän valinnan mukaan
            if(selected_dices[index]){
                values.Add(user_results[index]);
            }
            else{
                values.Add(initial_results[index]);
            }
        }

        int[] results_for_scoring = values.ToArray();

        return results_for_scoring;

    }

    private void checkIfPossibleForScoring(int[] current_results){ // current_results pituus on aina 5

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
        
        // tarkastukset tehdään eniten esiintyvien numeroiden mukaan
        // (listan nollannes arvo)
        var occurance_times_ordered = countOccurances(current_results);

        // yatzyn voi myös tarkastaa:
        // occurance_times_ordered[0].Item2 == 5
        // mutta set.Count() == 1 on varmempi
        HashSet<int> set = new HashSet<int>(current_results);

        int[] small_straight = {1, 2, 3, 4, 5};
        int[] big_straight = {2, 3, 4, 5, 6};

        if(occurance_times_ordered[0].Item2 >= 2){ // pari
            possible_combination[6] = true;
        }
        if((occurance_times_ordered[0].Item2 >= 2 && occurance_times_ordered[1].Item2 == 2)){ // kaksi paria
            possible_combination[7] = true;
        }
        if(occurance_times_ordered[0].Item2 >= 3){ // kolme samaa
            possible_combination[8] = true;
        }
        if(occurance_times_ordered[0].Item2 >= 4){ // neljä samaa
            possible_combination[9] = true;
        }
        if(Enumerable.SequenceEqual(current_results.OrderBy(x => x), small_straight.OrderBy(x => x))){ // pieni suora
            possible_combination[10] = true;
        }
        if(Enumerable.SequenceEqual(current_results.OrderBy(x => x), big_straight.OrderBy(x => x))){ // iso suora
            possible_combination[11] = true;
        }
        if((occurance_times_ordered[0].Item2 == 3 && occurance_times_ordered[1].Item2 == 2)){ // täyskäsi
                possible_combination[12] = true;
        }
        if(set.Count() == 1){ // yatzy
            possible_combination[14] = true;
        }

        // mennään vasta viimeisenä tänne
        if(current_results.Any()){ // sattuma
            possible_combination[13] = true;
        }

    }
    
}