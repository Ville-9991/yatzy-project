namespace yatzy_project;

public partial class YatzyForm{

    private List<Label> getAllCategoryLabels(){
    // sama homma kuten dice buttonien kanssa, mutta category/combination labeleita on paljon enemmän
    // joten on vain parempi tehdä yksi iso lista ja käsitellä niitä indeksittäin

    List<Label> CategoryLabels = new List<Label>();

    foreach (Label label in upperCategories_Panel.Controls){
        CategoryLabels.Add(label);
    }

    foreach (Label label in bottomCategories_Panel.Controls){
        CategoryLabels.Add(label);
    }
    return CategoryLabels; // pituus on 15 elementtiä (14 kun aloitetaan 0:sta...)
    }

    private void Init_CategoryEvents(){
        List<Label> categories = getAllCategoryLabels();

        foreach(Label category in categories){
            //
            // categoryCombination_Click
            //
            category.Click += (sender, e) => {
                // lambda, joka luo jokaiselle 15:lle katgorialle
                // "EventListener" -toiminnon painelluksen varalle
                Label? categoryClickEvent = sender as Label;

                int index = checkWhichCategoryWasClicked(categoryClickEvent);

                // näytettään käyttäjälle ikkuna, missä kerrottaan että kategoria on tavoittelematon
                if(!possible_combination[index] && !category_selected[index] && !category_locked[index] && round_started){
                    string message = $"Kategoria '{categoryClickEvent?.Text}' voi olla tavoittelematon noppien arvon perusteella. \n\nJos hyäksyt tulokset, voit saada 0 pistettä.";
                    const string title = "Tavoittelematon yhdistelmä";

                    const MessageBoxButtons buttons = MessageBoxButtons.OK;

                    DialogResult result = MessageBox.Show(message, title, buttons);
                }

                if(!category_selected[index] && !category_locked[index]){ // suoritetaan vain silloin kun kategoria ei ole valittuna tai lukittuna
                deselectAllCategories(); // laitetaan kaikki kategoria painikkeet false (myös tämä), koska vain yhtä kategoriaa voi tavoitella kerrallaan

                category_selected[index] = true; // laitetaan merkki että kategoria on valittuna
                this.combinationsPanel.Invalidate(createCategoryBorders()[index]);
                }

                else if (category_selected[index] && !category_locked[index]){
                    category_selected[index] = false;
                    this.combinationsPanel.Invalidate(createCategoryBorders()[index]);
                }
            };
        }
    }

    private int checkWhichCategoryWasClicked(Label? category){

        if(category != null){
            var categoryLabels = getAllCategoryLabels();

            for(int index = 0; index < categoryLabels.Count(); index++){
                if(categoryLabels[index] == category){
                    return index;
                }
            }
        }

        return 0;
    }

    private void deselectAllCategories(){
        for(int index = 0; index < category_selected.Count(); index++){
            category_selected[index] = false;
        }
    }

    private List<Rectangle> createCategoryBorders(){
        // funktio joka luo rajat noppa kategoria painikkeille
        // jota käytetään myöhemmin kun katgorian alue uudelleen maalataan
        // näin tehdään jotta combinationsPanel_Paint pystyy suorittamaan
        // sille määrätyt toiminnot
        var categoires = getAllCategoryLabels();

        Rectangle border = new Rectangle();
        List<Rectangle> border_list = new List<Rectangle>();

        foreach(Label category in categoires){

            border.X = category.Location.X;
            border.X = category.Location.Y;

            border.Width = category.Width;
            border.Height = category.Height;

            border_list.Add(border);
        }

        return border_list;
    }
}